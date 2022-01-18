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
    public enum NormalizationEnum
    {
        Geometric,
        Mass
    }

    public class SfcGamry : SfcFile
    {
        private string _date = "";

        public readonly char DELIMITER = '\t';

        public List<double> TimeInSec { get; set; }
        public List<double> Vf { get; set; }
        public List<double> Im { get; set; }
        //public List<double> Overloads { get; set; }

        public SfcGamry(string fullPath) : base(fullPath)
        {
            TimeInSec = new List<double>();
            Vf = new List<double>();
            Im = new List<double>();
            //Overloads = new List<double>();

            SetValues();
        }

        public override void SetValues()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FullPath))
                {
                    if (!FullPath.ToLower().Contains("merged"))
                    {
                        while (!reader.EndOfStream)
                        {
                            string[] line = reader.ReadLine().Split(DELIMITER);

                            for (int i = 0; i < line.Length; i++)
                            {
                                if (line[i].ToLower().Contains("date"))
                                {
                                    _date = line[i].Split(':')[1].Split('.')[2] + "_" + line[i].Split(':')[1].Split('.')[1] + "_" + line[i].Split(':')[1].Split('.')[0];
                                }
                            }
                            if (_date != "")
                                break;
                        }
                    }
                    else
                    {
                        _date = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(FullPath))).Split('\\').Last();
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
                        //Overloads.Add(Helpers.ParseStrToDouble(line[line.Length - 1]));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override async Task GeometricNormalization(double shift, double surface)
        {
            List<double> VfHelper = new List<double>();
            foreach (var item in Vf)
            {
                VfHelper.Add(item + shift);
            }

            List<double> ImHelper = new List<double>();
            foreach (var item in Im)
            {
                ImHelper.Add((item * 1000) / surface);
            }

            string dir = Path.Combine(Helpers.AppFolderPath, _date, Helpers.SFC_DIR, "Geometric Normalization");
            Directory.CreateDirectory(dir);
            await Save(Path.Combine(dir, Path.GetFileName(FullPath).Split('.')[0] + "_GeomNorm.txt"), ImHelper, VfHelper, surface, NormalizationEnum.Geometric);
        }

        public override async Task MassNormalization(double shift, double mMicroGrams)
        {
            List<double> VfHelper = new List<double>();
            foreach (var item in Vf)
            {
                VfHelper.Add(item + shift);
            }

            double mGrams = mMicroGrams * 0.000001;
            List<double> ImHelper = new List<double>();
            foreach (var item in Im)
            {
                ImHelper.Add(item / mGrams);
            }

            string dir = Path.Combine(Helpers.AppFolderPath, _date, Helpers.SFC_DIR, "Mass Normalization");
            Directory.CreateDirectory(dir);
            await Save(Path.Combine(dir, Path.GetFileName(FullPath).Split('.')[0] + "_MassNorm.txt"), ImHelper, VfHelper, mGrams, NormalizationEnum.Mass);
        }

        public override async Task Save(string path, List<double> Im, List<double> Vf, double value, NormalizationEnum normalizationEnum)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    var date = DateTime.Now;
                    writer.Write("Date: " + date.ToShortDateString() + "\tTime: " + date.ToShortTimeString() + "\t");

                    if (normalizationEnum == NormalizationEnum.Geometric)
                    {
                        writer.WriteLine("Surface: " + value + "cm^2");
                        writer.WriteLine($"t/s{DELIMITER}Vf{DELIMITER}mA cm^2");
                    }
                    else if (normalizationEnum == NormalizationEnum.Mass)
                    {
                        writer.WriteLine("Mass: " + value + "g");
                        writer.WriteLine($"t/s{DELIMITER}Vf{DELIMITER}A g^-1");
                    }


                    for (int i = 0; i < TimeInSec.Count; i++)
                    {
                        writer.Write(TimeInSec[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.Write(Vf[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.WriteLine(Im[i].ToString("F12", CultureInfo.InvariantCulture));
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
