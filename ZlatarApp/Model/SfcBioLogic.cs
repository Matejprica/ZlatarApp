using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZlatarApp.Utils;

namespace ZlatarApp.Model
{
    public class SfcBioLogic : SfcFile
    {
        private string _date = "";

        public readonly char DELIMITER = ';';

        public List<double> TimeInSec { get; set; }
        public List<double> Ewe { get; set; }
        public List<double> I { get; set; }

        public SfcBioLogic(string fullPath) : base(fullPath)
        {
            TimeInSec = new List<double>();
            Ewe = new List<double>();
            I = new List<double>();

            SetValues();
        }

        public override void SetValues()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FullPath))
                {
                    _date = Path.GetFileName(FullPath).Split('_')[0] + "_"
                            + Path.GetFileName(FullPath).Split('_')[1] + "_"
                            + Path.GetFileName(FullPath).Split('_')[2];


                    Helpers.DropRowsUntilValuesSfcBioLogic(reader);

                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(DELIMITER);

                        if (line[0] == "")
                            break;

                        TimeInSec.Add(Helpers.ParseStrToDouble(line[0]));
                        Ewe.Add(Helpers.ParseStrToDouble(line[1]));
                        I.Add(Helpers.ParseStrToDouble(line[2]));
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
            List<double> EweHelper = new List<double>();
            foreach (var item in Ewe)
            {
                EweHelper.Add(item + shift);
            }

            List<double> ImHelper = new List<double>();
            foreach (var item in I)
            {
                ImHelper.Add(item / surface);
            }

            string dir = Path.Combine(Helpers.AppFolderPath, _date, Helpers.SFC_DIR, "Geometric Normalization");
            Directory.CreateDirectory(dir);
            await Save(Path.Combine(dir, Path.GetFileName(FullPath).Split('.')[0] + "_GeomNorm.txt"), ImHelper, EweHelper, surface, NormalizationEnum.Geometric);
        }

        public override async Task MassNormalization(double shift, double massMicroGrams)
        {
            List<double> VfHelper = new List<double>();
            foreach (var item in Ewe)
            {
                VfHelper.Add(item + shift);
            }

            double massGrams = massMicroGrams * 0.000001;
            List<double> ImHelper = new List<double>();
            //Current is in miliAmpers, convert it to Ampers by dividing with 1000
            foreach (var item in I)
            {
                ImHelper.Add((item / 1000) / massGrams);
            }

            string dir = Path.Combine(Helpers.AppFolderPath, _date, Helpers.SFC_DIR, "Mass Normalization");
            Directory.CreateDirectory(dir);
            await Save(Path.Combine(dir, Path.GetFileName(FullPath).Split('.')[0] + "_MassNorm.txt"), ImHelper, VfHelper, massGrams, NormalizationEnum.Mass);
        }

        public override async Task Save(string path, List<double> I, List<double> Ewe, double normalizationValue, NormalizationEnum normalizationEnum)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    var date = DateTime.Now;
                    writer.Write("Date: " + date.ToShortDateString() + "\tTime: " + date.ToShortTimeString() + "\t");

                    if (normalizationEnum == NormalizationEnum.Geometric)
                    {
                        writer.WriteLine("Surface: " + normalizationValue + "cm^2");
                        writer.WriteLine($"t/s{DELIMITER}Ewe/V{DELIMITER}mA cm^2");
                    }
                    else if (normalizationEnum == NormalizationEnum.Mass)
                    {
                        writer.WriteLine("Mass: " + normalizationValue + "g");
                        writer.WriteLine($"t/s{DELIMITER}Ewe/V{DELIMITER}A g^-1");
                    }


                    for (int i = 0; i < TimeInSec.Count; i++)
                    {
                        writer.Write(TimeInSec[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.Write(Ewe[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.WriteLine(I[i].ToString("F12", CultureInfo.InvariantCulture));
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


