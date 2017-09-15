using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWPenerimaanPegawai.Common
{
    public static class CriteriaCollection
    {
        public static ObservableCollection<Criteria> BaseCriteria()
        {
            var Cristerias = new ObservableCollection<Criteria>();

            //instance Criteria 
            var c1 = new Criteria { Id = 1, Code = "C1", Bobot = 0.30, TypeAlternative = typeof(Berkas), Nama = "Kelengkapan Berkas" };
            var c2 = new Criteria { Id = 2, Code = "C2", Bobot = 0.20, TypeAlternative = typeof(TestKesehatan), Nama = "Kesehatan" };
            var c3 = new Criteria { Id = 3, Code = "C3", Bobot = 0.20, TypeAlternative = typeof(Akademik), Nama = "Akademik" };
            var c4 = new Criteria { Id = 4, Code = "C4", Bobot = 0.15, TypeAlternative = typeof(Psikotes), Nama = "Psikotes" };
            var c5 = new Criteria { Id = 5, Code = "C5", Bobot = 0.15, TypeAlternative = typeof(TestWawancara), Nama = "Wawancara" };

            Cristerias.Add(c1);
            Cristerias.Add(c2);
            Cristerias.Add(c3);
            Cristerias.Add(c4);
            Cristerias.Add(c5);

            return Cristerias;
        }

        public static Criteria GetById(int id)
        {
            return CriteriaCollection.BaseCriteria().Where(O => O.Id == id).FirstOrDefault();
        }
    }
}
