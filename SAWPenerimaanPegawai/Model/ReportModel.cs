using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SAWPenerimaanPegawai.Helper.EnumCollection;

namespace SAWPenerimaanPegawai.Model
{
    public class ReportModel:BaseNotifyProperty, ICloneable
    {
        public string Nama { get; set; }
        public string KodeRegistrasi { get; set; }
        public double Akademik { get; set; }
        public string Berkas { get; set; }
        public string HasilKesehatan { get; set; }
        public string HasilWawancara { get; set; }
        public double Psikotes { get; set; }
        public double NilaiAkhir { get; set; }
        public string Tahun { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
