using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAWPenerimaanPegawai.Common;
using System.Windows.Data;

namespace SAWPenerimaanPegawai.ViewModel
{
    public class HasilVM:PelamarMatriks
    {
        private SAWMethod Methode;
        public CollectionView SourceHasilSAW { get; private set; }
        public List<PelamarMatriks> DataMetode = new List<PelamarMatriks>();
        private List<pelamar> _DataPelamar;

        public HasilVM(SAWMethod methode, List<pelamar> dataPelamar)
        {
            this.Methode = methode;
            _DataPelamar = dataPelamar;
            DataHasil = this.Methode.hasilSAW;
            var TempPelamarMatriks = new List<PelamarMatriks>();
            var TempPelamar = new List<pelamar>();
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
            
        }
        
        public Action WindowClose { get; internal set; }
        public List<PelamarMatriks> DataHasil { get; private set; }
        public List<PelamarMatriks> DataSourve { get; set; }
    }
}
