using Accord.Statistics.Models.Regression.Linear;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZlatarApp.Utils;

namespace ZlatarApp.Model
{
    public class SfcMergedFile
    {
        public readonly char DELIMITER = '\t';

        public List<double> TimeInSec { get; set; }
        public List<double> Vf { get; set; }
        public List<double> Im { get; set; }
        public List<double> Overloads { get; set; }
        public string Electrolyte { get; set; }

        public SfcMergedFile(string filePath)
        {
            TimeInSec = new List<double>();
            Vf = new List<double>();
            Im = new List<double>();
            Overloads = new List<double>();

            SetValues(filePath);
        }

        public SfcMergedFile(List<double> timeInSec, List<double> vf, List<double> im, List<double> overloads)
        {
            TimeInSec = timeInSec;
            Vf = vf;
            Im = im;
            Overloads = overloads;
        }

        
        private async Task SetValues(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string[] str = reader.ReadLine().Split('\t');
                    if (str.Length > 2 && str[2].ToLower().Contains("electrolyte:"))
                    {
                        Electrolyte = str[2].Split(':').Last().Trim();
                    }

                    Helpers.DropRowsUntilValuesSfc(reader);

                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(DELIMITER);

                        if (line[0] == "")
                            break;

                        TimeInSec.Add(Helpers.ParseStrToDouble(line[0]));
                        Vf.Add(Helpers.ParseStrToDouble(line[1]));
                        Im.Add(Helpers.ParseStrToDouble(line[2]));
                        if(line.Length == 4)
                            Overloads.Add(Helpers.ParseStrToDouble(line[3]));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }       

        public async Task<bool> Save(string electrolyte, string path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    var date = DateTime.Now;
                    writer.WriteLine("Date: " + date.ToShortDateString() + 
                        "\tTime: " + date.ToShortTimeString() + 
                        "\tElectrolyte: " + electrolyte);
                    writer.WriteLine($"t/s{DELIMITER}Vf/V{DELIMITER}Im/A{DELIMITER}Overloads");

                    for (int i = 0; i < TimeInSec.Count; i++)
                    {
                        writer.Write(TimeInSec[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.Write(Vf[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.Write(Im[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.WriteLine(Overloads[i].ToString("F12", CultureInfo.InvariantCulture));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Point> GetPeakAsync()
        {
            List<Point> pointsVf = new List<Point>();
            for (int i = 0; i < TimeInSec.Count; i++)
            {
                pointsVf.Add(new Point(TimeInSec[i], Vf[i]));
            }

            List<Point> derivatedPointsVf = await Helpers.DerivatePoints(pointsVf);

            return await CalculateSfcPeak(derivatedPointsVf);
        }

        private async Task<Point> CalculateSfcPeak(List<Point> points)
        {
            List<double> inputsDelta = new List<double>();
            List<double> outputsDelta = new List<double>();

            for (int i = points.Count - 1; i > points.Count - 101; i--)
            {
                inputsDelta.Add(points[i].X);
                outputsDelta.Add(points[i].Y);
            }

            OrdinaryLeastSquares ordinaryLeastSquares = new OrdinaryLeastSquares();
            SimpleLinearRegression simpleLinearRegression = ordinaryLeastSquares.Learn(inputsDelta.ToArray(), outputsDelta.ToArray());
            double slope = simpleLinearRegression.Slope;
            double intercept = simpleLinearRegression.Intercept;

            //Find all peaks in first file of the merge sequence ()
            List<Point> peaks = new List<Point>();

            int notPeakCounter = 0;

            for (int i = 0; i < 200; i++)
            {
                double y = Math.Abs((slope * points[i].X) + intercept);

                if (Math.Abs(points[i].Y - y) > 1000 * Math.Abs(y))
                {
                    peaks.Add(points[i]);
                    notPeakCounter = 0;
                }
                else
                {
                    notPeakCounter++;
                    if (notPeakCounter >= 10)
                        break;
                }
            }

            Point peak = new Point(0,0);
            if(peaks.Count >= 2)
            {
                if (peaks[peaks.Count - 2].Y > peaks[peaks.Count - 1].Y)
                    peak = await GetSfcPeakMax(peaks);
                else
                    peak = await GetSfcPeakMin(peaks);
            }

            return peak;
        }

        private async Task<Point> GetSfcPeakMax(List<Point> peaks)
        {
            Point peak = new Point();

            for (int i = peaks.Count - 1; i > 0; i--)
            {
                if (peaks[i - 1].Y > peaks[i].Y)
                    peak = peaks[i];
                else
                {
                    peak = peaks[i];
                    break;
                }
            }

            return peak;
        }

        private async Task<Point> GetSfcPeakMin(List<Point> peaks)
        {
            Point peak = new Point();

            for (int i = peaks.Count - 1; i > 0; i--)
            {
                if (peaks[i - 1].Y < peaks[i].Y)
                    peak = peaks[i];
                else
                {
                    peak = peaks[i];
                    break;
                }
            }

            return peak;
        }

        public async Task Treatment(double shift, double surface)
        {
            List<double> VfHelper = new List<double>();
            Vf.ForEach(i => VfHelper.Add(i));
            Vf.Clear();
            foreach (var item in VfHelper)
            {
                Vf.Add(item + shift);
            }

            List<double> ImHelper = new List<double>();
            Im.ForEach(i => ImHelper.Add(i));
            Im.Clear();
            foreach (var item in ImHelper)
            {
                Im.Add((item * 1000) / surface);
            }
        }

        public async Task SaveTreated(string mergedFilePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(mergedFilePath))
                {
                    writer.WriteLine("Date: " + DateTime.Now.Date.ToString("yyyy_MM_dd") + "\tTime: " + DateTime.Now.ToShortTimeString());
                    writer.WriteLine("t/s\tVf\tj");
                    for (int i = 0; i < TimeInSec.Count; i++)
                    {
                        writer.Write(TimeInSec[i].ToString("F12") + "\t");
                        writer.Write(Vf[i].ToString("F12") + "\t");
                        writer.Write(Im[i].ToString("F12") + Environment.NewLine);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
