using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAWPenerimaanPegawai.Common;
using System.Windows.Data;
using ViewApp.ViewModels;
using SAWPenerimaanPegawai.Form;
using SAWPenerimaanPegawai.Model;
using System.Collections.ObjectModel;

namespace SAWPenerimaanPegawai.ViewModel
{
    public class HasilVM:PelamarMatriks
    {
        private SAWMethod Methode;
        public ObservableCollection<Criteria> Bobot { get; set; }
        public ObservableCollection<PelamarMatriks> MatriksKeputusan { get; set; }
        public ObservableCollection<PelamarMatriks> MatriksNormal { get; set; }
        public CollectionView SourceViewMatriksNormal { get; set; }
        public CollectionView SourceViewMatriksKeputusan { get; set; }
        public CollectionView SourceHasilSAW { get; private set; }
        public CollectionView SourceViewBobot { get; set; }
        public List<PelamarMatriks> DataMetode = new List<PelamarMatriks>();
        private List<pelamar> _DataPelamar;
        public CommandHandler Cetak { get; set; }
        public string Tahun { get; set; }

        public HasilVM(SAWMethod methode, List<pelamar> dataPelamar)
        {
            this.Methode = methode;
            _DataPelamar = dataPelamar;
            Bobot = new ObservableCollection<Criteria>();            
            foreach(var item in CriteriaCollection.BaseCriteria())
            {
                Bobot.Add(item);
            }
            SourceViewBobot = (CollectionView)CollectionViewSource.GetDefaultView(Bobot);
            SourceViewBobot.Refresh();

            MatriksKeputusan = new ObservableCollection<PelamarMatriks>();
            foreach(var item in this.Methode.Matriks_Keputusan)
            {
                MatriksKeputusan.Add(item);
            }
            SourceViewMatriksKeputusan = (CollectionView)CollectionViewSource.GetDefaultView(MatriksKeputusan);
            SourceViewMatriksKeputusan.Refresh();

            MatriksNormal = new ObservableCollection<PelamarMatriks>();
            foreach(var item in this.Methode.NilaiAlternatif)
            {
                MatriksNormal.Add(item);
            }
            SourceViewMatriksNormal = (CollectionView)CollectionViewSource.GetDefaultView(MatriksNormal);
            SourceViewMatriksNormal.Refresh();

            this.Tahun = _DataPelamar[0].Tahun;
            DataHasil = this.Methode.hasilSAW;
            var NewDataHasil = DataHasil.Clone();
            foreach(var item in _DataPelamar)
            {
                var TTempPelamarMatriks = NewDataHasil.Where(o => o.IdPelamar == item.IdPelamar).FirstOrDefault();
                TTempPelamarMatriks.KodeRegistrasi = item.KodeRegistrasi;
                TTempPelamarMatriks.Nama = item.Nama;
                TTempPelamarMatriks.Berkas = item.nilais.Berkas;
                TTempPelamarMatriks.Kesehatan = item.nilais.Kesehatan;
                TTempPelamarMatriks._Akademiks = item.nilais.Akademik;
                TTempPelamarMatriks._Psikotess = item.nilais.Psikotes;
                TTempPelamarMatriks.Wawancara= item.nilais.Wawancara;
                DataMetode.Add(TTempPelamarMatriks);
            }
            
            foreach(var item in DataHasil)
            {
                var TTempPelamarMatriks =DataMetode.Where(o => o.IdPelamar == item.IdPelamar).FirstOrDefault();
                TTempPelamarMatriks.NilaiAkhir = item.NilaiAkhir;
            }
            DataSourve = DataMetode.OrderByDescending(o => o.NilaiAkhir).ToList();
            SourceHasilSAW = (CollectionView)CollectionViewSource.GetDefaultView(DataSourve);
            SourceHasilSAW.Refresh();
            Cetak = new CommandHandler { CanExecuteAction = CetakValidate, ExecuteAction = CetakAction };
           
           
        }

        private void CetakAction(object obj)
        {
            var DataBaru = new List<ReportModel>();
            foreach (var item in DataSourve)
            {
                var r = new ReportModel
                {
                    Nama = item.Nama,
                    Akademik = item._Akademiks,
                    HasilKesehatan = item.Kesehatan.ToString(),
                    HasilWawancara = item.Wawancara.ToString(),
                    Berkas = item.Berkas.ToString(),
                    KodeRegistrasi = item.KodeRegistrasi,
                    Psikotes = item._Psikotess,
                    NilaiAkhir = item.NilaiAkhir,
                    Tahun = this.Tahun
                };
                DataBaru.Add(r);
            }

            var form = new Report(DataBaru);
            form.ShowDialog();
        }

        private bool CetakValidate(object obj)
        {
            return true;
        }
        
        public Action WindowClose { get; internal set; }
        public List<PelamarMatriks> DataHasil { get; private set; }
        public List<PelamarMatriks> DataSourve { get; set; }
    }
}
