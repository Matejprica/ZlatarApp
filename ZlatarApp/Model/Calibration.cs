using Accord.Statistics.Models.Regression.Linear;
using LiveCharts.Defaults;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using ZlatarApp.Utils;
using Point = System.Windows.Point;

namespace ZlatarApp.Model
{
    public class Calibration
    {
        public string CalibrationDate { get; set; }
        public Dictionary<string, string> ElementLinearEquation { get; set; }
        public Dictionary<string, double> ElementRSquared { get; set; }
        public Dictionary<string, List<Point>> ElementChartPoints { get; set; }
        public Dictionary<string, List<Point>> ElementPoints { get; set; }
        public List<Element> ElementsAndIs { get; set; }
        public List<string> Elements { get; set; }
        public List<Element> Blank1 { get; set; }
        public List<Element> Blank2 { get; set; }
        public List<Element> S1 { get; set; }
        public List<Element> S2 { get; set; }
        public List<Element> S3 { get; set; }
        public string CalibrationPath { get; set; }


        public Calibration(List<Element> blank1, List<Element> blank2, List<Element> s1, List<Element> s2, List<Element> s3, string calibrationDate)
        {
            CalibrationDate = calibrationDate;
            ElementLinearEquation = new Dictionary<string, string>();
            ElementRSquared = new Dictionary<string, double>();
            ElementPoints = new Dictionary<string, List<Point>>();
            ElementChartPoints = new Dictionary<string, List<Point>>();
            ElementsAndIs = blank1;
            Elements = new List<string>();

            Blank1 = blank1;           
            Blank2 = blank2;
            S1 = s1;
            S2 = s2;
            S3 = s3;

            CalculateLinearEquationAndRSquared();
            FilterElements();       
        }

        public void CalculateLinearEquationAndRSquared()
        {
            foreach (Element element in ElementsAndIs)
            {
                double avg1 = Blank1.Find(el => el.Name == element.Name).AverageValue;
                double avg2 = Blank2 != null ? Blank2.Find(el => el.Name == element.Name).AverageValue : avg1;

                Point point1 = new Point(0, (avg1 + avg2) / 2);
                Point point2 = new Point(0.5, S1.Find(el => el.Name == element.Name).AverageValue);
                Point point3 = new Point(1, S2.Find(el => el.Name == element.Name).AverageValue);
                Point point4 = new Point(5, S3.Find(el => el.Name == element.Name).AverageValue);
                ElementPoints.Add(element.Name, new List<Point> { point1, point2, point3, point4});

                double[] inputs = { point1.X, point2.X, point3.X, point4.X };
                double[] outputs = { point1.Y, point2.Y, point3.Y, point4.Y };

                OrdinaryLeastSquares ordinaryLeastSquares = new OrdinaryLeastSquares();

                SimpleLinearRegression simpleLinearRegression = ordinaryLeastSquares.Learn(inputs, outputs);

                double intercept = simpleLinearRegression.Intercept;
                double slope = simpleLinearRegression.Slope;

                string linearEquation = intercept < 0 ?
                    linearEquation = Math.Round(slope, 8).ToString("F12", CultureInfo.InvariantCulture) + "x - " + Math.Abs(Math.Round(intercept, 8)).ToString("F12", CultureInfo.InvariantCulture) :
                    linearEquation = Math.Round(slope, 8).ToString("F12", CultureInfo.InvariantCulture) + "x + " + Math.Abs(Math.Round(intercept, 8)).ToString("F12", CultureInfo.InvariantCulture);

                ElementLinearEquation.Add(element.Name, linearEquation);
                ElementRSquared.Add(element.Name, Math.Round(simpleLinearRegression.CoefficientOfDetermination(inputs.ToArray(), outputs.ToArray()), 8));

                Point pointChart1 = new Point(point1.X, (point1.X * simpleLinearRegression.Slope) + simpleLinearRegression.Intercept);
                Point pointChart2 = new Point(point2.X, (point2.X * simpleLinearRegression.Slope) + simpleLinearRegression.Intercept);
                Point pointChart3 = new Point(point3.X, (point3.X * simpleLinearRegression.Slope) + simpleLinearRegression.Intercept);
                Point pointChart4 = new Point(point4.X, (point4.X * simpleLinearRegression.Slope) + simpleLinearRegression.Intercept);

                ElementChartPoints.Add(element.Name, new List<Point>() { pointChart1, pointChart2, pointChart3, pointChart4});
            }
        }

        private void FilterElements()
        {
            foreach (Element element in ElementsAndIs)
            {
                if (ElementRSquared[element.Name] > 0.99 &&
                    Helpers.ParseStrToDouble(ElementLinearEquation[element.Name].Split('x').Last().Trim()) < 1 &&
                    Helpers.ParseStrToDouble(ElementLinearEquation[element.Name].Split('x').First().Split('=').Last().Trim()) < 1)
                    Elements.Add(element.Name);
            }
        }

        public List<Point> GetPoints(string elementName)
        {
            return ElementChartPoints[elementName];
        }

        public async Task Save()
        {
            string macroListFolder = Path.Combine(Helpers.AppFolderPath, CalibrationDate);
            Directory.CreateDirectory(macroListFolder);
            string calibrationFolder = Path.Combine(macroListFolder, Helpers.CALIBRATION_DIR);
            Directory.CreateDirectory(calibrationFolder);
            string elements = "";
            Elements.ForEach(el => elements += el + "_");
            string fileName = "Calibration_" + elements + "(" + (Helpers.SameNameFilesInFolder(calibrationFolder, elements) + 1) + ")" + ".txt";
            CalibrationPath = Path.Combine(calibrationFolder, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(CalibrationPath))
                {
                    writer.WriteLine("Date: " + DateTime.Now.Date.ToString("yyyy_MM_dd") + "\tTime: " + DateTime.Now.ToShortTimeString());
                    foreach (string name in Elements)
                    {
                        writer.WriteLine(name + "\ty = " + ElementLinearEquation[name] + "\tR^2 = " + ElementRSquared[name]);
                    }
                    writer.WriteLine();
                    writer.WriteLine("File\tElement\tMedian\tSD\tRSD");
                    List<List<Element>> files = new List<List<Element>>
                    {
                        Blank1
                    };
                    if (Blank2 != null)
                        files.Add(Blank2);
                    files.Add(S1);
                    files.Add(S2);
                    files.Add(S3);


                    foreach (Element element in Blank1)
                    {
                        writer.WriteLine(nameof(Blank1) + ".xl" + "\t" + element.Name + "\t" +
                            element.AverageValue.ToString("0.########e+00") + "\t" +
                            element.StandardDeviation.ToString("0.########e+00") + "\t" +
                            Math.Round(element.RelativeStDeviation, 2) + "%");
                    }
                    if (Blank2 != null)
                        foreach (Element element in Blank2)
                        {
                            writer.WriteLine(nameof(Blank2) + ".xl" + "\t" + element.Name + "\t" +
                                element.AverageValue.ToString("0.########e+00") + "\t" +
                                element.StandardDeviation.ToString("0.########e+00") + "\t" +
                                Math.Round(element.RelativeStDeviation, 2) + "%");
                        }
                    foreach (Element element in S1)
                    {
                        writer.WriteLine(nameof(S1) + ".xl" + "\t" + element.Name + "\t" +
                            element.AverageValue.ToString("0.########e+00") + "\t" +
                            element.StandardDeviation.ToString("0.########e+00") + "\t" +
                            Math.Round(element.RelativeStDeviation, 2) + "%");
                    }
                    foreach (Element element in S2)
                    {
                        writer.WriteLine(nameof(S2) + ".xl" + "\t" + element.Name + "\t" +
                            element.AverageValue.ToString("0.########e+00") + "\t" +
                            element.StandardDeviation.ToString("0.########e+00") + "\t" +
                            Math.Round(element.RelativeStDeviation, 2) + "%");
                    }
                    foreach (Element element in S3)
                    {
                        writer.WriteLine(nameof(S3) + ".xl" + "\t" + element.Name + "\t" +
                            element.AverageValue.ToString("0.########e+00") + "\t" +
                            element.StandardDeviation.ToString("0.########e+00") + "\t" +
                            Math.Round(element.RelativeStDeviation, 2) + "%");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
    }
}
