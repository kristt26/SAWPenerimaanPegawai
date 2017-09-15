using SAWPenerimaanPegawai.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWPenerimaanPegawai
{
    public static class ListExtention
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static double MaxOfProperty(this PelamarMatriks Pelamar)
        {
            double result = 0;
            foreach (var item in Pelamar.GetType().GetProperties().Where(O => O.Name != "IdPelamar"))
            {
                double a = (double)item.GetValue(Pelamar);
                if (a > result)
                    result = a;
            }
            return result;
        }

        public static double MinOfProperty(this PelamarMatriks Pelamar)
        {
            double result = 0;
            foreach (var item in Pelamar.GetType().GetProperties().Where(O => O.Name != "IdSiswa"))
            {
                double a = (double)item.GetValue(Pelamar);
                if (a < result)
                    result = a;
            }
            return result;
        }


    }

}
