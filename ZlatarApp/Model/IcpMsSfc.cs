using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ZlatarApp.Utils;
using Point = System.Windows.Point;

namespace ZlatarApp.Model
{
    public class IcpMsSfc
    {
        public IcpMsMacroList IcpMsMLTreated { get; set; }
        public SfcMergedFile SfcMergedTreated { get; set; }

        public IcpMsSfc(IcpMsMacroList icpMsMLTreated, SfcMergedFile sfcMergedTreated)
        {
            IcpMsMLTreated = icpMsMLTreated;
            SfcMergedTreated = sfcMergedTreated;
        }


        internal async Task SaveFiles(string flowrate, string shift, string surface, string delay)
        {
            
            DateTime date = Helpers.GetDateFromFileName(Path.GetFileName(IcpMsMLTreated.FullPath));

            await SfcMergedTreated.SaveTreated(CreateTreatedMergedFilePath(date));
            await IcpMsMLTreated.SaveFinalTreatment();
            await IcpMsMLTreated.SaveFinalTreatmentSingleFiles();

            string elements = "";
            IcpMsMLTreated.ElementNames.ForEach(e => elements += e + ",");
            elements = elements.Remove(elements.Length - 1);
            await SaveIcpMsSfcFile(date, elements, flowrate, shift, surface, delay);
        }

        private string CreateTreatedMergedFilePath(DateTime date)
        {
            string ml = Path.GetFileName(IcpMsMLTreated.FullPath).Split('-')[3];

            string measurementDateFolder = Path.Combine(Helpers.AppFolderPath, date.ToString("yyyy_MM_dd"));
            string sfcFolder = Path.Combine(measurementDateFolder, Helpers.SFC_DIR);
            string sfcTreatedMergedFolder = Path.Combine(sfcFolder, Helpers.SFC_TREATED_DIR);
            Directory.CreateDirectory(sfcTreatedMergedFolder);
            string mergedFilePath = Path.Combine(sfcTreatedMergedFolder, date.ToString("yyyy_MM_dd") + "_" + ml + "_MergedFile-Treated.txt");

            return mergedFilePath;
        }

        private async Task SaveIcpMsSfcFile(DateTime date, string elements, string flowrate, string shift, string surface, string delay)
        {
            string path = CreateIcpMsSfcPath(date);
            char DELIMITER = ',';
            string[] elementsNames = elements.Split(',');
            string elNames = "";
            foreach (var el in elementsNames)
            {
                string name = "";
                for(int i = 0; i < el.Length; i++)
                {
                    if (Char.IsNumber(el[i]))
                        break;
                    else
                        name += el[i];
                }
                elNames += name + ",";
            }
            elNames = elNames.Substring(0, elNames.Length - 1);

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    date = DateTime.Now;
                    writer.WriteLine("Date: " + date.ToShortDateString() + DELIMITER + "Time: " + date.ToShortTimeString());
                    writer.WriteLine("Electrolyte: " + SfcMergedTreated.Electrolyte);
                    writer.WriteLine("Flowrate: " + double.Parse(flowrate).ToString("F12", CultureInfo.InvariantCulture) + " μl/s" + DELIMITER + "Shift: " + double.Parse(shift).ToString("F12", CultureInfo.InvariantCulture) + " V" + DELIMITER + "Surface: " + double.Parse(surface).ToString("F12", CultureInfo.InvariantCulture)+ " cm^2" + DELIMITER + "Delay: -" + delay + "s");
                    writer.WriteLine("TimeSfc" + DELIMITER + "Vf" + DELIMITER + "j" + DELIMITER + "TimeIcpMs" + DELIMITER + elNames);
                    for (int i = 0; i < SfcMergedTreated.TimeInSec.Count; i++)
                    {
                        writer.Write(SfcMergedTreated.TimeInSec[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                        writer.Write(SfcMergedTreated.Vf[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);                       

                        if (i * IcpMsMLTreated.ElementNames.Count < IcpMsMLTreated.AllPoints.Count)
                        {
                            writer.Write(SfcMergedTreated.Im[i].ToString("F12", CultureInfo.InvariantCulture) + DELIMITER);
                            writer.Write(IcpMsMLTreated.AllPoints[i * IcpMsMLTreated.ElementNames.Count].X.ToString(CultureInfo.InvariantCulture) + DELIMITER); //Time
                            for (int j = 0; j < elements.Split(DELIMITER).Count(); j++)
                            {
                                if(j == elements.Split(DELIMITER).Count() - 1)
                                    writer.WriteLine(IcpMsMLTreated.AllPoints[(i * IcpMsMLTreated.ElementNames.Count) + IcpMsMLTreated.ElementNames.IndexOf(elements.Split(DELIMITER)[j])].Y.ToString("0.########e+00", CultureInfo.InvariantCulture)); //elements
                                else
                                    writer.Write(IcpMsMLTreated.AllPoints[(i * IcpMsMLTreated.ElementNames.Count) + IcpMsMLTreated.ElementNames.IndexOf(elements.Split(DELIMITER)[j])].Y.ToString("0.########e+00", CultureInfo.InvariantCulture) + DELIMITER);
                            }
                        }
                        else
                        {
                            writer.WriteLine(SfcMergedTreated.Im[i].ToString("F12", CultureInfo.InvariantCulture));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private string CreateIcpMsSfcPath(DateTime date)
        {
            string ml = Path.GetFileName(IcpMsMLTreated.FullPath).Split('-')[3];

            string measurementDateFolder = Path.Combine(Helpers.AppFolderPath, date.ToString("yyyy_MM_dd"));
            string icpMsSfcFolder = Path.Combine(measurementDateFolder, Helpers.ICP_MS_SFC_DIR);
            Directory.CreateDirectory(icpMsSfcFolder);

            string fileName = date.ToString("yyyy_MM_dd") + "_" + ml + "_" + "ICP-MS_SFC.xl";           

            return Path.Combine(icpMsSfcFolder, fileName);
        }
    }
}
