using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZlatarApp.Model
{
    public abstract class InputDataFile
    {
        public string FullPath { get; set; }

        public InputDataFile(string fullPath)
        {
            FullPath = fullPath;
        }
    }
}
