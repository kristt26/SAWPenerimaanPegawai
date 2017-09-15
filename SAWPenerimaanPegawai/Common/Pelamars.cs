using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWPenerimaanPegawai.Common
{
    class Pelamars
    {
        public Berkas _Berkass { get; set; }
        public TestKesehatan _Kesehatans { get; set; }
        public Akademik _Akademiks { get; set; }
        public Psikotes _Psikotess { get; set; }
        public TestWawancara _Wawancaras { get; set; }
        public int IdPelamar { get; set; }
        public string Nama { get; set; }
        public string KodeRegistrasi { get; set; }
        public double NilaiAkhir { get; set; }
    }
}
