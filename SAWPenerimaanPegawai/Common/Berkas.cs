using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAWPenerimaanPegawai.Helper.EnumCollection;

namespace SAWPenerimaanPegawai.Common
{
    public class Berkas:Alternative
    {
        private Criteria criteria = new Criteria();
        private StatusBerkas _nilai;

        public StatusBerkas Nilai
        {
            set
            {
                _nilai = value;
                if (value == StatusBerkas.Lengkap)
                {
                    this.Rank = 2;
                }
                else
                    this.Rank = 1;

            }
        }

        public List<Range> Ranks { get; private set; }
    }
}
