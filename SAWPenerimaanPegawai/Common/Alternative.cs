using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWPenerimaanPegawai.Common
{
    public class Alternative
    {
        public int Id { get; set; }
        public string CriteriaCode { get; set; }
        public string Name { get; set; }
        public double Bobot { get; set; }
        public int Rank { get; set; }
        public int KodeRegistrasi { get; set; }
    }
}
