using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlatarApp.Model
{
    public class Element
    {
        public string Name { get; set; }
        public double AverageValue { get; set; }
        public double StandardDeviation { get; set; }
        public double RelativeStDeviation { get; set; }
    }
}
