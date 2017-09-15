using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAWPenerimaanPegawai.Helper.EnumCollection;

namespace SAWPenerimaanPegawai.Common
{
    public class PelamarMatriks:ICloneable
    {
        public double _Berkass { get; set; }
        public double _Kesehatans { get; set; }
        public double _Akademiks { get; set; }
        public double _Psikotess { get; set; }
        public double _Wawancaras { get; set; }
        public int IdPelamar { get; set; }
        public string Nama { get; set; }
        public string KodeRegistrasi { get; set; }
        public double NilaiAkhir { get; set; }
        public StatusBerkas Berkas { get; set; }
        public Kesehatans Kesehatan { get; set; }
        public Wawancaras Wawancara { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
