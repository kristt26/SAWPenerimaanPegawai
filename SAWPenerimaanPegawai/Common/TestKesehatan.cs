using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAWPenerimaanPegawai.Helper.EnumCollection;

namespace SAWPenerimaanPegawai.Common
{
    public class TestKesehatan:Alternative
    {
        private Criteria criteria = new Criteria();
        private Kesehatans _nilai;
      
        public Kesehatans Nilai
        {
            set
            {
                _nilai = value;
                if (_nilai == Kesehatans.Tidak)
                    this.Rank = 1;
                else if (_nilai == Kesehatans.Sehat)
                    this.Rank = 2;
                else
                    this.Rank = 3;
            }
        }

        public List<Range> Ranks { get; private set; }
    }
}
