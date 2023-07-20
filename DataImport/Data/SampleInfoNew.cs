using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace DataImport.Data
{
    public class SampleItem
    {
        public string Name { get; set; }

        public Dictionary<string,string> FactorValues { get; }=new Dictionary<string,string>();

        public double[] XAxis { get; set; }

        public double[] X { get; set; }
    }

}
