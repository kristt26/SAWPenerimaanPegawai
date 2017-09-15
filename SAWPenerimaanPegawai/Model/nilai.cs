using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using DAL;
using static SAWPenerimaanPegawai.Helper.EnumCollection;

namespace SAWPenerimaanPegawai
{
    [TableName("nilai")]
    public class nilai : BaseNotifyProperty, ICloneable
    {
        [PrimaryKey("IdNilai")]
        [DbColumn("IdNilai")]
        public int IdNilai
        {
            get { return _idnilai; }
            set
            {
                _idnilai = value;
                OnPropertyChange("IdNilai");
            }
        }

        [DbColumn("IdPelamar")]
        public int IdPelamar
        {
            get { return _idpelamar; }
            set
            {
                _idpelamar = value;
                OnPropertyChange("IdPelamar");
            }
        }

        [DbColumn("Berkas")]
        public StatusBerkas Berkas
        {
            get { return _berkas; }
            set
            {
                _berkas = value;
                OnPropertyChange("Berkas");
            }
        }

        [DbColumn("Kesehatan")]
        public Kesehatans Kesehatan
        {
            get { return _kesehatan; }
            set
            {
                _kesehatan = value;
                OnPropertyChange("Kesehatan");
            }
        }


        [DbColumn("Akademik")]
        public double Akademik
        {
            get { return _akademik; }
            set
            {
                _akademik = value;
                OnPropertyChange("Akademik");
            }
        }

        [DbColumn("Psikotes")]
        public double Psikotes
        {
            get { return _psikotes; }
            set
            {
                _psikotes = value;
                OnPropertyChange("Psikotes");
            }
        }

        [DbColumn("Wawancara")]
        public Wawancaras Wawancara
        {
            get { return _wawancara; }
            set
            {
                _wawancara = value;
                OnPropertyChange("Wawancara");
            }
        }

        public string Nama
        {
            get { return _Nama; }
            set
            {
                _Nama = value;
                OnPropertyChange("Nama");
            }
        }

        public string KodeRegistrasi
        {
            get { return _KodeRegistrasi; }
            set
            {
                _KodeRegistrasi = value;
                OnPropertyChange("KodeRegistrasi");
            }
        }
        private int _idnilai;
        private int _idpelamar;
        private StatusBerkas _berkas;
        private Kesehatans _kesehatan;
        private double _akademik;
        private double _psikotes;
        private Wawancaras _wawancara;
        private string _Nama;
        private string _KodeRegistrasi;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}


