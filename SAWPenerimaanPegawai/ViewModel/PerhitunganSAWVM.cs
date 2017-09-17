using DAL;
using SAWPenerimaanPegawai.Common;
using SAWPenerimaanPegawai.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ViewApp.ViewModels;

namespace SAWPenerimaanPegawai.ViewModel
{
    public class PerhitunganSAWVM:BaseNotifyProperty
    {
        public CommandHandler Proses { get; set; }
        public List<pelamar> DataPelamar = new List<pelamar>();
        public List<pelamar> _DataPelamar = new List<pelamar>();
        public SAWMethod Methode;
        public CollectionView SourceViewData { get; set; }
        private string _Tahun;

        public string TahunData
        {
            get { return _Tahun; }
            set
            {
                _Tahun = value;
                OnPropertyChange("IdPelamar");
                SourceViewData.Refresh();
            }
        }
        public PerhitunganSAWVM()
        {
            using (var db = new OcphDbContext())
            {
                DataPelamar = (from a in db.Pelamars.Select().ToList()
                                   join b in db.Nilais.Select() on a.IdPelamar equals b.IdPelamar into c
                                   from d in c.DefaultIfEmpty()
                                   select new pelamar { IdPelamar = a.IdPelamar, KodeRegistrasi = a.KodeRegistrasi, Nama = a.Nama, Sex = a.Sex, TTL = a.TTL, Alamat = a.Alamat, Kontak = a.Kontak, Email = a.Email, Pendidikan = a.Pendidikan, Tahun = a.Tahun, nilais = d }).ToList();
                SourceViewData = (CollectionView)CollectionViewSource.GetDefaultView(DataPelamar);
                SourceViewData.Filter = FilterAction;
                SourceViewData.Refresh();
                Proses = new CommandHandler { CanExecuteAction = ProsesValidate, ExecuteAction = ProsesAction };
            }
        }

        private bool FilterAction(object obj)
        {
            var item = obj as pelamar;
            if (!string.IsNullOrEmpty(TahunData))
            {
                if (item.Tahun.ToString().Equals(TahunData))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void ProsesAction(object obj)
        {
            var Data = DataPelamar.Clone().ToList();
            _DataPelamar = Data.Where(o => o.Tahun == TahunData).ToList();
            var Matriks = DataMatriks();
            var _Matriks = Matriks.Clone().ToList();
            Methode = new SAWMethod(_Matriks);
            var form = new Hasil();
            var vm = new HasilVM(Methode, _DataPelamar) { WindowClose = form.Close };
            form.DataContext = vm;
            form.ShowDialog();
            //SourceDataNilai.Refresh();
        }

        private bool ProsesValidate(object obj)
        {
            if (!string.IsNullOrEmpty(TahunData))
            {
                if (SourceViewData.Count == 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
       
        public List<PelamarMatriks> DataMatriks()
        {
            var _DataMatriks = new List<PelamarMatriks>();
            var _DataPelamar = DataPelamar.Clone().ToList();
            List<Pelamars> pelamar = new List<Pelamars>();
            foreach (var item in _DataPelamar.Where(o => o.Tahun == TahunData))
            {
                var a = new Pelamars
                {
                    _Berkass = new Berkas { Nilai = item.nilais.Berkas},
                    _Kesehatans = new TestKesehatan { Nilai = item.nilais.Kesehatan},
                    _Akademiks = new Akademik { Nilai = item.nilais.Akademik },
                    _Psikotess = new Psikotes { Nilai = item.nilais.Psikotes},
                    _Wawancaras = new TestWawancara { Nilai = item.nilais.Wawancara},
                    Nama = item.Nama,
                    KodeRegistrasi=item.KodeRegistrasi,
                    IdPelamar = item.IdPelamar
                };
                pelamar.Add(a);
            }
            foreach (var nilai in pelamar)
            {
                var a = new PelamarMatriks { _Berkass = nilai._Berkass.Rank, _Kesehatans = nilai._Kesehatans.Rank, _Akademiks= nilai._Akademiks.Rank, _Psikotess= nilai._Psikotess.Rank, _Wawancaras= nilai._Wawancaras.Rank, IdPelamar= nilai.IdPelamar, KodeRegistrasi= nilai.KodeRegistrasi, Nama=nilai.Nama};
                _DataMatriks.Add(a);
            }
            return _DataMatriks;
        }

    }
}
