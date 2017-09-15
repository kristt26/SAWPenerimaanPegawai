using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewApp.ViewModels;
using static SAWPenerimaanPegawai.Helper.EnumCollection;

namespace SAWPenerimaanPegawai.ViewModel
{
    public class EditNilaiVM:nilai
    {
        private nilai selected;
        public CommandHandler UpdateCommand { get; set; }
        public CommandHandler BatalCommand { get; set; }
        public List<Wawancaras> NilaiWawancara { get; set; }
        public List<Kesehatans> NilaiKesehatan { get; set; }

        public EditNilaiVM(nilai selected)
        {
            this.selected = selected;
            NilaiWawancara = new List<Wawancaras>();
            NilaiKesehatan = new List<Kesehatans>();
            NilaiWawancara.Add(Wawancaras.Tidak);
            NilaiWawancara.Add(Wawancaras.Kurang);
            NilaiWawancara.Add(Wawancaras.Cukup);
            NilaiWawancara.Add(Wawancaras.Siap);
            NilaiKesehatan.Add(Kesehatans.Tidak);
            NilaiKesehatan.Add(Kesehatans.Sehat);
            NilaiKesehatan.Add(Kesehatans.SehatJasmani);

            IdPelamar = this.selected.IdPelamar;
            Berkas = this.selected.Berkas;
            Kesehatan = this.selected.Kesehatan;
            Akademik = this.selected.Akademik;
            Psikotes = this.selected.Psikotes;
            Wawancara = this.selected.Wawancara;


            UpdateCommand = new CommandHandler { CanExecuteAction = UpdateCommandValidate, ExecuteAction = UpdateCommandAction };
            BatalCommand = new CommandHandler { CanExecuteAction = BatalCommandValidate, ExecuteAction = BatalCommandAction };
        }

        private void UpdateCommandAction(object obj)
        {
            using (var db = new OcphDbContext())
            {
                var UpdateNilai = db.Nilais.Update(o => new { o.Berkas, o.Kesehatan, o.Akademik, o.Psikotes, o.Wawancara }, this, o => o.IdNilai == this.selected.IdNilai);
                if(UpdateNilai)
                {
                    selected.IdPelamar = IdPelamar;
                    selected.Berkas = Berkas;
                    selected.Kesehatan = Kesehatan;
                    selected.Akademik = Akademik;
                    selected.Psikotes = Psikotes;
                    selected.Wawancara = Wawancara;
                    WindowClose();
                }
            }
        }

        private bool UpdateCommandValidate(object obj)
        {
            return true;
        }

        private void BatalCommandAction(object obj)
        {
            WindowClose();
        }

        private bool BatalCommandValidate(object obj)
        {
            return true;
        }

        public Action WindowClose { get; internal set; }
    }
}
