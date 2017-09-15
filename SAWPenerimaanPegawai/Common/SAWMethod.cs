using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWPenerimaanPegawai.Common
{
    public class SAWMethod
    {
        private List<PelamarMatriks> _Matriks;

        public SAWMethod(List<PelamarMatriks> SourceData)
        {
            this.Matriks_Keputusan = SourceData;
            this.NilaiAlternatif = MatriksNormal();
            this.hasilSAW = Hasil();

        }
        
        public List<PelamarMatriks> Matriks_Keputusan { get; private set; }
        public List<PelamarMatriks> NilaiAlternatif { get; private set; }
        public List<PelamarMatriks> hasilSAW { get; private set; }

        public List<PelamarMatriks> MatriksNormal()
        {
            var _NilaiAlternatif = Matriks_Keputusan.Clone().ToArray();
            foreach (var item in Matriks_Keputusan)
            {
                var tempPelamar = _NilaiAlternatif.Where(O => O.IdPelamar == item.IdPelamar).FirstOrDefault();
                tempPelamar._Berkass = item._Berkass / Matriks_Keputusan.Max(O => O._Berkass);
                tempPelamar._Kesehatans = item._Kesehatans / Matriks_Keputusan.Max(O => O._Kesehatans);
                tempPelamar._Akademiks = item._Akademiks/ Matriks_Keputusan.Max(O => O._Akademiks);
                tempPelamar._Psikotess= item._Psikotess/ Matriks_Keputusan.Max(O => O._Psikotess);
                tempPelamar._Wawancaras= item._Wawancaras/ Matriks_Keputusan.Max(O => O._Wawancaras);
            }

            return _NilaiAlternatif.ToList<PelamarMatriks>();
        }

        public List<PelamarMatriks> Hasil()
        {
            ObservableCollection<Criteria> criterias = CriteriaCollection.BaseCriteria();
            var hasilSAW = MatriksNormal().Clone().ToArray();
            foreach (var item in MatriksNormal())
            {
                //var tempPelamar = DataHasil.Where(O => O.IdPelamar == item.IdPelamar).FirstOrDefault();
                //tempPelamar.NilaiAkhir
                var tempSiswa = hasilSAW.Where(O => O.IdPelamar == item.IdPelamar).FirstOrDefault();
                tempSiswa.NilaiAkhir += item._Berkass * criterias.Where(O => O.Code == "C1").FirstOrDefault().Bobot;
                tempSiswa.NilaiAkhir += item._Kesehatans * criterias.Where(O => O.Code == "C2").FirstOrDefault().Bobot;
                tempSiswa.NilaiAkhir += item._Akademiks * criterias.Where(O => O.Code == "C3").FirstOrDefault().Bobot;
                tempSiswa.NilaiAkhir += item._Psikotess * criterias.Where(O => O.Code == "C4").FirstOrDefault().Bobot;
                tempSiswa.NilaiAkhir += item._Wawancaras * criterias.Where(O => O.Code == "C5").FirstOrDefault().Bobot;
                

            }
            return hasilSAW.ToList<PelamarMatriks>();
        }
    }
}
