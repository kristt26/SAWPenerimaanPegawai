using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWPenerimaanPegawai.Common
{
    public class Range
    {
        private int v1;
        private double v2;

        public Range(string name, int min, int max, int v1, double v2)
        {
            this.Name = name;
            this.Min = min;
            this.Max = max;
            this.Rank = v1;
            this.Bobot = v2;
        }


        public double Min { get; set; }
        public double Max { get; set; }
        public double Bobot { get; set; }
        public int Rank { get; set; }
        public string Name { get; private set; }
    }
}
