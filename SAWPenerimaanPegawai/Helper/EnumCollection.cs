using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWPenerimaanPegawai.Helper
{
    public class EnumCollection
    {
        public enum StatusBerkas
        {
            None, Lengkap, Tidak
        }
        public enum Kesehatans
        {
            Tidak,Sehat,SehatJasmani
        }
        public enum Wawancaras
        {
            Tidak, Kurang, Cukup, Siap
        }
    }
}
