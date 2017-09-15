using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewApp.ViewModels;

namespace SAWPenerimaanPegawai.ViewModel
{
    public class EditPelamarVM:pelamar
    {
        private pelamar selected;
        public CommandHandler UpdateCommand { get; set; }
        public CommandHandler BatalCommand { get; set; }

        public EditPelamarVM(pelamar selected)
        {
            this.selected = selected;
            IdPelamar = this.selected.IdPelamar;
            KodeRegistrasi = this.selected.KodeRegistrasi;
            Nama = this.selected.Nama;
            Sex = this.selected.Sex;
            Alamat = this.selected.Alamat;
            TmpLahir = this.selected.TmpLahir;
            TglLahir = this.selected.TglLahir;
            Kontak = this.selected.Kontak;
            Email = this.selected.Email;
            Pendidikan = this.selected.Pendidikan;
            Tahun = this.selected.Tahun;
            UpdateCommand = new CommandHandler { CanExecuteAction = UpdateCommandValidate, ExecuteAction = UpdateCommandAction };
            BatalCommand = new CommandHandler { CanExecuteAction = BatalCommandValidate, ExecuteAction = BatalCommandAction };
        }

        private void BatalCommandAction(object obj)
        {
            WindowClose();
        }

        private bool BatalCommandValidate(object obj)
        {
            return true;
        }

        private void UpdateCommandAction(object obj)
        {
            using (var db = new OcphDbContext())
            {
                var UpdatePelamar = db.Pelamars.Update(o=>new { o.KodeRegistrasi,o.Nama,o.Sex,o.Alamat,o.TglLahir,o.TmpLahir,o.Kontak,o.Email,o.Pendidikan,o.Tahun},this,o=>o.IdPelamar==this.IdPelamar);
                if(UpdatePelamar)
                {
                    selected.KodeRegistrasi = KodeRegistrasi;
                    selected.Nama = Nama;
                    selected.Sex = Sex;
                    selected.Alamat = Alamat;
                    selected.TmpLahir = TmpLahir;
                    selected.TglLahir = TglLahir;
                    selected.Kontak = Kontak;
                    selected.Email = Email;
                    selected.Pendidikan = Pendidikan;
                    selected.Tahun = Tahun;
                    WindowClose();
                }
            }
        }

        private bool UpdateCommandValidate(object obj)
        {
            return true;
        }

        public Action WindowClose { get; internal set; }
    }
}
