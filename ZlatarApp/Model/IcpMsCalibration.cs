using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlatarApp.Model
{
    public class IcpMsCalibration : IcpMsFile
    {
        public List<Element> ElementsAndIs { get; set; }

        public IcpMsCalibration(string fullPath) : base(fullPath)
        {
            ElementsAndIs = new List<Element>();
            SetElementValues();
        }

        private void SetElementValues()
        {
            List<string> elementsValues = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(FullPath))
                {
                    do
                    {
                        string[] str = reader.ReadLine().Split(',');
                        if (str[0].ToLower().Contains("time in seconds") || str[0].Contains("t/s"))
                        {
                            for (int i = 1; i < str.Length; i++)
                            {
                                ElementsAndIs.Add(new Element { Name = str[i] });
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
                            elementsValues.Add(line[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            CalculateElementsValues(elementsValues);
        }

        private async void CalculateElementsValues(List<string> elementsValues)
        {
            for (int i = 0; i < ElementsAndIs.Count; i++)
            {
                double totalSum = 0;
                List<double> values = new List<double>(); //Only this element values

                for (int j = i; j < elementsValues.Count; j += ElementsAndIs.Count)
                {
                    values.Add(Utils.Helpers.ParseStrToDouble(elementsValues[j]));
                    totalSum += Utils.Helpers.ParseStrToDouble(elementsValues[j]);
                }
                ElementsAndIs[i].AverageValue = totalSum / values.Count;
                ElementsAndIs[i].StandardDeviation = await CalculateStandardDeviation(ElementsAndIs[i].AverageValue, values);
                ElementsAndIs[i].RelativeStDeviation = (ElementsAndIs[i].StandardDeviation / ElementsAndIs[i].AverageValue) * 100;
            }
        }

        private async Task<double> CalculateStandardDeviation(double averageValue, List<double> elementValues)
        {
            double SumOfSquares = 0;

            foreach (double val in elementValues)
            {
                SumOfSquares += Math.Pow(val - averageValue, 2);
            }

            return Math.Sqrt(SumOfSquares / (elementValues.Count - 1));
        }

    }
}
