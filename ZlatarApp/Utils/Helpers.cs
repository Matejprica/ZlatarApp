using Accord;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Windows.Point;

namespace ZlatarApp.Utils
{
    public static class Helpers
    {
        public const string CALIBRATION_DIR = "Calibration";

        public const string ICP_MS_DIR = "ICP-MS";
        public const string ICP_MS_FIRST_DIR = "ICP-MS First Treatment";
        public const string ICP_MS_FINAL_DIR = "ICP-MS Final Treatment";

        public const string SFC_DIR = "SFC";
        public const string SFC_MERGED_DIR = "SFC Merged Files";
        public const string SFC_TREATED_DIR = "SFC Treated Merged Files";

        public const string ICP_MS_SFC_DIR = "ICP-MS-SFC";


        public static double MachineDelayInSeconds { get; set; }
        public static string AppFolderPath { get; set; }
        public static string CalibrationFolderPath { get; set; }

        internal static void InitAppFolder()
        {
            if (Properties.Settings.Default["AppFolderPath"] == "")
                AppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DataTreatment9000");
            else
                AppFolderPath = Path.Combine(Properties.Settings.Default["AppFolderPath"].ToString(), "DataTreatment9000"); 
            Directory.CreateDirectory(AppFolderPath);           
        }

        internal static double ParseStrToDouble(string strNumber)
        {          
            if (strNumber.Contains("."))
                strNumber = strNumber.Replace('.', ',');

            if (strNumber == "")
                return 0;

            if (Double.TryParse(strNumber, out double res))
                return res;
            else
                throw new Exception("Invalid input! Expecting number");
        }

        internal static bool IcpMsCorrectFileNameFormat(string fileName)
        {
            bool format1 = IcpMsFileNameFormat(Path.GetFileName(fileName), '-');
            
            return format1;
        }

        private static bool IcpMsFileNameFormat(string fileName, char delimiter)
        {
            string[] name = fileName.Split(delimiter);
            if (name.Length <= 1)
                return false;

            if (int.TryParse(fileName.Split(delimiter)[0], out int year))
            {
                if(year.ToString().Length != 4)
                    return false;
            }
            if (int.TryParse(fileName.Split(delimiter)[1], out int month))
            {
                if (month.ToString().Length > 2)
                    return false;
            }
            if (int.TryParse(fileName.Split(delimiter)[2], out int day))
            {
                if (day.ToString().Length > 2)
                    return false;
            }
            return true;
        }

        internal static bool IcpMsFilesSameDate(List<string> fileNames)
        {
            DateTime date = GetDateFromFileName(fileNames.First());
            foreach (string name in fileNames)
            {
                if (name == "")
                    continue;
                if (date != GetDateFromFileName(name))
                    return false;
            }
            return true;
        }

        public static int SameNameFilesInFolder(string calibrationDir, string elements)
        {
            string[] files = Directory.GetFiles(calibrationDir);
            int counter = 0;

            foreach (var file in files)
            {
                if (Path.GetFileName(file).Contains("Calibration_" + elements))
                    counter++;
            }

            return counter;
        }         

        public static StringBuilder MergeFilesInFolder(string folderPath)
        {
            List<string> allFiles = Directory.GetFiles(folderPath).ToList();
            List<string> filesForMerge = new List<string>();           

            foreach (string file in allFiles)
            {
                if (Path.GetFileName(file).Contains("_Cyc"))
                {
                    filesForMerge.Add(file);
                }
            }
            
            StringBuilder stringBuilderMergedFile = new StringBuilder();
            ReadAllFiles(filesForMerge, stringBuilderMergedFile);
            return stringBuilderMergedFile;           
        }

        private static void ReadAllFiles(List<string> filesForMerge, StringBuilder stringBuilderMergedFile)
        {
            double delayBetweenFiles = 0;
            double lastFileTime = 0;
            double totalTimeInM = 0;
            string lastFileName = "";

            foreach (string file in filesForMerge)
            {
                if (lastFileName != "" &&
                    lastFileName.Split('_')[0] == Path.GetFileName(file).Split('_')[0] &&
                    lastFileName.Split('_')[1] == Path.GetFileName(file).Split('_')[1] &&
                    lastFileName.Split('_')[2] != Path.GetFileName(file).Split('_')[2])
                {
                    delayBetweenFiles += totalTimeInM + MachineDelayInSeconds;
                    totalTimeInM = 0;
                }

                try
                {
                    using (StreamReader reader = new StreamReader(file))
                    {                       
                        DropRowsUntilValuesSfc(reader);

                        while (!reader.EndOfStream)
                        {
                            string[] line = reader.ReadLine().Split('\t');

                            stringBuilderMergedFile.AppendLine(
                                (Double.Parse(line[0], CultureInfo.InvariantCulture) + delayBetweenFiles).ToString("F12", CultureInfo.InvariantCulture) +
                                "\t" + ParseStrToDouble(line[1]).ToString("F12", CultureInfo.InvariantCulture) +
                                "\t" + ParseStrToDouble(line[2]).ToString("F12", CultureInfo.InvariantCulture) +
                                "\t" + ParseStrToDouble(line[5]).ToString("F12", CultureInfo.InvariantCulture));

                            lastFileTime = ParseStrToDouble(line[0]);
                        }

                        totalTimeInM = lastFileTime;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                lastFileName = Path.GetFileName(file);
            }
        }

        internal static string GetDateFromSfcFiles(string folderPath)
        {
            List<string> allFiles = Directory.GetFiles(folderPath).ToList();
            string date = "";

            foreach (string file in allFiles)
            {
                if (Path.GetFileName(file).Contains("_Cyc"))
                {
                    date = GetDateFromSfcFile(file).ToString("yyyy_MM_dd");
                }
            }

            return date;
        }

        internal static string GetElectrolyteFromSfcFiles(string dir)
        {
            List<string> allFiles = Directory.GetFiles(dir).ToList();
            string electrolyte = "";

            foreach (string file in allFiles)
            {
                if (Path.GetFileName(file).Contains("_Cyc"))
                {
                    electrolyte = GetElectrolyteFromSfcFile(file);
                }
            }

            return electrolyte;
        }

        private static string GetElectrolyteFromSfcFile(string file)
        {
            string electrolyte = "";

            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split('\t');

                        foreach (string part in line)
                        {
                            if (part.ToLower().Contains("electrolyte:"))
                            {
                                electrolyte = part.Split(':').Last();
                            }
                        }

                        if (electrolyte != "")
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return electrolyte;
        }

        private static DateTime GetDateFromSfcFile(string file)
        {
            DateTime date = new DateTime();

            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split('\t');

                        foreach (string part in line)
                        {
                            if (part.Contains("Date:"))
                            {
                                date = new DateTime(int.Parse(part.Split(':')[1].Split('.')[2]),
                                    int.Parse(part.Split(':')[1].Split('.')[1]), 
                                    int.Parse(part.Split(':')[1].Split('.')[0]));
                            }
                        }

                        if (date.Year != 1)
                            break;
                    }
                }
            }          
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return date;
        }

        internal static string GetFileNameWithoutDate(string fileName)
        {
            try
            {
                string[] delimiterDash = fileName.Split('-');
                string[] delimiterUnderscore = fileName.Split('_');

                return delimiterDash.Length > 1 ? delimiterDash[3] : delimiterUnderscore[3];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        internal static DateTime GetDateFromFileName(string fileName)
        {
            try
            {
                string[] delimiterDash = fileName.Split('-');
                string[] delimiterUnderscore = fileName.Split('_');

                return delimiterDash.Length > 1 ?
                    new DateTime(int.Parse(delimiterDash[0]), int.Parse(delimiterDash[1]), int.Parse(delimiterDash[2])) :
                    new DateTime(int.Parse(delimiterUnderscore[0]), int.Parse(delimiterUnderscore[1]), int.Parse(delimiterUnderscore[2]));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task DropRowsUntilValuesSfc(StreamReader reader)
        {
            do
            {
                string[] str = reader.ReadLine().Split('\t');
                if ((str[0].ToLower().Contains("t/s") && str[2].ToLower().Contains("im/a")) || (str[0].ToLower().Contains("t/s") && str[2].ToLower().Contains("i/a")) || (str[0].ToLower().Contains("time") && str[2].ToLower().Contains("im")))
                    break;
            } while (!reader.EndOfStream);
        }

        public static async Task DropRowsUntilValuesSfcBioLogic(StreamReader reader)
        {
            do
            {
                string[] str = reader.ReadLine().Split(';');
                if (str[0].ToLower().Contains("time/s") && str[1].ToLower().Contains("ewe/v") || str[0].ToLower().Contains("t/s") && str[1].ToLower().Contains("ewe/v"))
                    break;
            } while (!reader.EndOfStream);
        }


        public static async Task DropRowsUntilValuesCalibrationFile(StreamReader reader)
        {
            do
            {
                string[] str = reader.ReadLine().Split('\t');
                if (str[0].ToLower().Contains("file") && str[1].ToLower().Contains("element"))
                    break;
            } while (!reader.EndOfStream);
        }

        public static async Task<List<Point>> DerivatePoints(List<Point> points)
        {
            List<Point> derivatedPoints = new List<Point>();
            for (int i = 0; i < points.Count; i++)
            {
                Point current = points[i];
                Point next;
                Point previous;
                if (i == 0)
                {
                    continue;
                }
                else if (i == points.Count - 1)
                {
                    continue;
                }
                else
                {
                    next = points[i + 1];
                    previous = points[i - 1]; ;
                }

                derivatedPoints.Add(new Point(current.X, 0.5 * (((next.Y - current.Y) / (next.X - current.X)) + ((current.Y - previous.Y) / (current.X - previous.X)))));

            }

            return derivatedPoints;
        }

        public static void ShowChart(List<Point> points)
        {
            LiveCharts.WinForms.CartesianChart chart = new LiveCharts.WinForms.CartesianChart();

            List<ObservablePoint> observablePoints = new List<ObservablePoint>();
            points.ForEach(p => observablePoints.Add(new ObservablePoint(p.X, p.Y)));

            chart.Series = new SeriesCollection {
                new LiveCharts.Wpf.LineSeries{
                    Values = observablePoints.AsGearedValues(),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    LineSmoothness = 0
                    }
                };
            chart.Tag = "bok";

            FormChart form = new FormChart(new List<LiveCharts.WinForms.CartesianChart> { chart });
            form.Show();
        }       
    }
}
