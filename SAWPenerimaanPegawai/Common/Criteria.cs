using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWPenerimaanPegawai.Common
{
    public class Criteria:ICloneable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nama { get; set; }
        public string Description { get; set; }
        public double Bobot { get; set; }
        public object UserValue { get; set; }

        public ObservableCollection<Alternative> Alternatives { get; set; }
        public Type TypeAlternative { get; internal set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
