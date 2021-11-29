using Accord.Math;
using Accord.Statistics.Models.Regression.Linear;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlatarApp.Model
{
    public abstract class IcpMsFile : InputDataFile
    {
        public readonly char DELIMITER = ',';      

        public IcpMsFile(string fullPath) : base(fullPath)
        {
            
        }                                                   
    }
}
