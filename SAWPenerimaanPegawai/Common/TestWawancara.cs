using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAWPenerimaanPegawai.Helper.EnumCollection;

namespace SAWPenerimaanPegawai.Common
{
    public class TestWawancara:Alternative
    {
        private Criteria criteria = new Criteria();
        private Wawancaras _nilai;
        public Wawancaras Nilai
        {
            set
            {
                _nilai = value;
                if (_nilai == Wawancaras.Tidak)
                    this.Rank = 1;
                else if (_nilai == Wawancaras.Kurang)
                    this.Rank = 2;
                else if (_nilai == Wawancaras.Cukup)
                    this.Rank = 3;
                else
                    this.Rank = 4;

            }
        }

        public List<Range> Ranks { get; private set; }
    }
}
