using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlatarApp.Model
{
    public abstract class SfcFile : InputDataFile
    {
        protected SfcFile(string fullPath) : base(fullPath)
        {
        }

        public abstract void SetValues();

        public abstract Task GeometricNormalization(double shift, double surface);

        public abstract Task MassNormalization(double shift, double m);

        public abstract Task Save(string path, List<double> I, List<double> Ewe, double normalizationValue, NormalizationEnum normalizationEnum);
    }
}
