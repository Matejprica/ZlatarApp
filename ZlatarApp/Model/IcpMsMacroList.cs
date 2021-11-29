using Accord.Math;
using Accord.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZlatarApp.Utils;
using Point = System.Windows.Point;

namespace ZlatarApp.Model
{
    public class IcpMsMacroList : IcpMsFile
    {
        public List<Point> AllPoints { get; set; }
        public List<string> ElementNames { get; set; }
        public List<int> ElementIndex { get; set; }
        public Dictionary<string, Point> ElementPeak { get; set; }

        public IcpMsMacroList(string fullPath) : base(fullPath)
        {
            AllPoints = new List<Point>();
            ElementNames = new List<string>();
            ElementIndex = new List<int>();
            ElementPeak = new Dictionary<string, Point>();

            SetValues();
        }

        private async Task SetValues()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FullPath))
                {
                    do
                    {
                        string[] str = reader.ReadLine().Split(DELIMITER);
                        if (str[0].ToLower().Contains("time in seconds") || str[0].Contains("t/s"))
                        {
                            for (int i = 1; i < str.Length; i++)
                            {
                                ElementNames.Add(str[i]);
                            }
                            break;
                        }

                    } while (!reader.EndOfStream);

                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(DELIMITER);

                        if (line[0] == "")
                            break;

                        for (int i = 1; i < line.Length; i++)
                        {
                            AllPoints.Add(new Point(Helpers.ParseStrToDouble(line[0]), Helpers.ParseStrToDouble(line[i])));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task CalibrationTreatment(Calibration calibration)
        {
            List<Point> elementsPoints = await GetAllElementPoints(calibration);
            ElementNames.Clear();
            calibration.Elements.ForEach(e => ElementNames.Add(e));
            Dictionary<string, double> elementMin = new Dictionary<string, double>();

            for (int i = 0; i < elementsPoints.Count; i++)
            {
                string element = calibration.Elements[i % calibration.Elements.Count];

                double intercept = Helpers.ParseStrToDouble(calibration.ElementLinearEquation[element].Split('x').Last());
                double slope = Helpers.ParseStrToDouble(calibration.ElementLinearEquation[element].Split('x').First());

                if (IsPeak(element, elementsPoints[i], calibration))
                    if (!ElementPeak.ContainsKey(element))
                        ElementPeak.Add(element, elementsPoints[i]);
                    //else
                        //ElementPeak[element] = elementsPoints[i];

                elementsPoints[i] = new Point(elementsPoints[i].X, (elementsPoints[i].Y - Math.Abs(intercept)) / slope);

                double y = elementsPoints[i].Y;

                if (i < calibration.Elements.Count)
                    elementMin.Add(element, y);
                else
                    elementMin[element] = y < elementMin[element] ? y : elementMin[element];

            }

            for (int i = 0; i < elementsPoints.Count; i++)
            {
                string element = calibration.Elements[i % calibration.Elements.Count];
                double min = elementMin[element];
                elementsPoints[i] = new Point(elementsPoints[i].X, elementsPoints[i].Y - min);
            }

            AllPoints.Clear();
            AllPoints = elementsPoints;
        }

        private bool IsPeak(string element, Point point, Calibration calibration)
        {
            double blankAvg = calibration.ElementPoints[element][0].Y;
            double blankAvgTimes3 = blankAvg * 3;
            double fivePercent = blankAvgTimes3 * 0.1;
            double upperBoundry = blankAvgTimes3 + fivePercent;
            double lowerBoundry = blankAvgTimes3 - fivePercent;

            if (upperBoundry > point.Y && point.Y > lowerBoundry)
                return true;
            else
                return false;

            /*
            if (point.X > 35 && point.X < 45) //Trazi izmedu 35s i 45s
            {
                if (upperBoundry > point.Y && point.Y > lowerBoundry)
                    return true;
                else
                    return false;
            }
            else
                return false;
                */
        }

        private async Task<List<Point>> GetAllElementPoints(Calibration calibration)
        {           
            List<Point> elementsPoints = new List<Point>();

            for (int i = 0; i < ElementNames.Count; i++)
            {
                if (calibration.Elements.Contains(ElementNames[i]))
                    ElementIndex.Add(i);
            }

            for (int i = 0; i < AllPoints.Count; i++)
            {
                if(ElementIndex.Contains(i % ElementNames.Count))
                    elementsPoints.Add(AllPoints[i]);
            }
            return elementsPoints;
        }              

        public async Task SaveTreated()
        {
            string measurementDate = Path.Combine(Helpers.AppFolderPath, Helpers.GetDateFromFileName(Path.GetFileName(FullPath).Split(DELIMITER).First()).ToString("yyyy_MM_dd"));
            string icpMsFolder = Path.Combine(measurementDate, Helpers.ICP_MS_DIR);
            string icpMsFirstTreatment = Path.Combine(icpMsFolder, Helpers.ICP_MS_FIRST_DIR);
            Directory.CreateDirectory(icpMsFirstTreatment);

            string fileName = Path.GetFileName(FullPath).Split('.').First() + "-Treated.xl";
            string Ml = fileName.Split('L')[1].Split('-')[0];
            if(Ml.Length == 1) //fill Ml for data consistency and later list view sorting
            {
                Ml = "0" + Ml;
                fileName = fileName.Split('L')[0] + "L" + Ml + "-" + fileName.Split('-')[4];
            }

            string file = Path.Combine(icpMsFirstTreatment, fileName);

            string elementsString = "";
            ElementNames.ForEach(e => elementsString += e + ",");

            try
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine("Date: " + DateTime.Now.Date.ToString("yyyy_MM_dd") + "\tTime: " + DateTime.Now.ToShortTimeString());
                    writer.WriteLine("t/s," + elementsString.Remove(elementsString.Length - 1)); //remove last comma 


                    for (int i = 0; i < AllPoints.Count / ElementNames.Count; i++)
                    {
                        writer.Write(AllPoints[i * ElementNames.Count].X.ToString(CultureInfo.InvariantCulture) + DELIMITER); //Time
                        for (int j = 0; j < ElementNames.Count; j++)
                        {
                            if (j == ElementNames.Count - 1)
                                writer.Write(AllPoints[(i * ElementNames.Count) + j].Y.ToString("0.########e+00", CultureInfo.InvariantCulture) + Environment.NewLine);
                            else
                                writer.Write(AllPoints[(i * ElementNames.Count) + j].Y.ToString("0.########e+00", CultureInfo.InvariantCulture) + ",");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Point> GetPeakAsync(Calibration calibration)
        {
            
            Point peak = new Point();
            
            List<Point> elementPoints = new List<Point>();
            foreach (var element in calibration.Elements)
            {
                List<Point> derivatedPoints = await Utils.Helpers.DerivatePoints(AllPoints);
                double blankAvgVal = calibration.ElementsAndIs.Where(el => el.Name == element).FirstOrDefault().AverageValue;

                for (int i = 0; i < derivatedPoints.Count; i++)
                {
                    int counter = 1;
                    if (derivatedPoints[i].Y >= blankAvgVal * 3)
                    {
                        Point pom = derivatedPoints[i];
                        while (pom.Y < derivatedPoints[i + counter].Y)
                        {
                            pom = derivatedPoints[i + counter];
                            counter++;
                        }

                        if (counter != 1)
                            elementPoints.Add(derivatedPoints[i + counter - 1]);
                        else
                            elementPoints.Add(derivatedPoints[i]);
                        break;
                    }
                }

                if (element == "Ir193")
                {
                    peak = elementPoints.Last();
                }
            }
            
            return peak;            
        }

        public async Task FinalTreatment(double delay, double flowrate, double surface)
        {
            List<Point> treatedPoints = new List<Point>();
            AllPoints.ForEach(p => treatedPoints.Add(new Point(p.X - delay, (p.Y * flowrate) / (1000 * surface))));
            AllPoints = treatedPoints;
        }

        public async Task SaveFinalTreatment()
        {
            string filePath = GetFilePath();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    WriteHeader(writer, ElementNames);

                    for (int i = 0; i < AllPoints.Count / ElementNames.Count; i++)
                    {
                        for (int j = 0; j < ElementNames.Count; j++)
                        {
                            if (j == 0)
                            {
                                writer.Write(AllPoints[i * ElementNames.Count].X.ToString(CultureInfo.InvariantCulture) + ',');
                                writer.Write(AllPoints[i * ElementNames.Count].Y.ToString("0.########e+00", CultureInfo.InvariantCulture) + ',');
                            }
                            else if (j == ElementNames.Count - 1)
                                writer.WriteLine(AllPoints[(i * ElementNames.Count) + j].Y.ToString("0.########e+00", CultureInfo.InvariantCulture));
                            else writer.Write(AllPoints[(i * ElementNames.Count) + j].Y.ToString("0.########e+00", CultureInfo.InvariantCulture) + ',');
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void WriteHeader(StreamWriter writer, List<string> elementNames)
        {
            var date = DateTime.Now;
            writer.WriteLine("Date: " + date.Date.ToString("yyyy_MM_dd") + "\tTime: " + date.ToShortTimeString());

            string elements = "";
            foreach (var el in elementNames)
            {
                string name = "";
                for (int i = 0; i < el.Length; i++)
                {
                    if (Char.IsNumber(el[i]))
                        break;
                    else
                        name += el[i];
                }
                elements += name + ",";
            }
            elements = elements.Remove(elements.Length - 1);
            writer.WriteLine("t/s," + elements);
        }

        private string GetFilePath()
        {
            DateTime date = Helpers.GetDateFromFileName(Path.GetFileName(FullPath));
            string ml = Path.GetFileName(FullPath).Split('-')[3];

            string dir = Path.Combine(Helpers.AppFolderPath, date.ToString("yyyy_MM_dd"), Helpers.ICP_MS_DIR, Helpers.ICP_MS_FINAL_DIR, ml);

            Directory.CreateDirectory(dir);
            return Path.Combine(dir, date.ToString("yyyy-MM-dd") + "-" + ml + "-FinalTreatment.xl");
        }

        public async Task SaveFinalTreatmentSingleFiles()
        {           
            foreach (var element in ElementNames)
            {
                string filePath = GetFilePath();
                string path = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileName(filePath).Split('.').First() + "-" + element + ".xl";

                try
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        WriteHeader(writer, new List<string> { element });

                        for (int i = 0; i < AllPoints.Count / ElementNames.Count; i++)
                        {
                            writer.Write(AllPoints[(i * ElementNames.Count) + ElementNames.IndexOf(element)].X.ToString(CultureInfo.InvariantCulture) + ',');
                            writer.WriteLine(AllPoints[(i * ElementNames.Count) + ElementNames.IndexOf(element)].Y.ToString("0.########e+00", CultureInfo.InvariantCulture));
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
}
