using DAL;
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
    public class DataPelamarVM:pelamar
    {
        public List<pelamar> DataPelamar = new List<pelamar>();
        private pelamar _selected;
        public CommandHandler CommandEdit { get; set; }
        public CommandHandler DeleteCommand { get; set; }
        private string _Cari;

        public CollectionView SourceViewPelamar { get; set; }
        public string Cari
        {
            get { return _Cari; }
            set
            {
                _Cari = value;
                OnPropertyChange("Cari");
                SourceViewPelamar.Refresh();
            }
        }
        public DataPelamarVM()  
        {
            TambahPelamar = new CommandHandler{ CanExecuteAction= TambahValidation, ExecuteAction=ProsesTambah};
            CommandEdit = new CommandHandler { CanExecuteAction = CommandEditValidate, ExecuteAction = CommandEditAction };
            DeleteCommand = new CommandHandler { CanExecuteAction = DeleteCommandValidate, ExecuteAction = DeleteCommandAction };
            using (var db = new OcphDbContext())
            {
                DataPelamar = db.Pelamars.Select().ToList();
                               //join b in db.Nilais.Select() on a.IdPelamar equals b.IdPelamar into c
                               //from d in c.DefaultIfEmpty()
                               //select new pelamar { IdPelamar = a.IdPelamar, KodeRegistrasi = a.KodeRegistrasi, Nama = a.Nama, Sex = a.Sex, TTL = a.TTL, Alamat = a.Alamat, Kontak = a.Kontak, Email = a.Email, Pendidikan = a.Pendidikan, Tahun = a.Tahun, nilais = d }).ToList();
                SourceViewPelamar = (CollectionView)CollectionViewSource.GetDefaultView(DataPelamar);
                SourceViewPelamar.Filter = FilterAction;
                SourceViewPelamar.Refresh();
            }
        }

        private void DeleteCommandAction(object obj)
        {
            using (var db = new OcphDbContext())
            {

                var DeletePelamar = db.Pelamars.Delete(o => o.IdPelamar == Selected.IdPelamar);
                if(DeletePelamar)
                {
                    var DeleteNilai = db.Nilais.Delete(o => o.IdPelamar == Selected.IdPelamar);
                    if(DeleteNilai)
                    DataPelamar.Remove(Selected);
                    SourceViewPelamar.Refresh();
                }
            }
        }

        private bool DeleteCommandValidate(object obj)
        {
            return true;
        }

        private void CommandEditAction(object obj)
        {
            var form = new EditPelamar();
            var vm = new EditPelamarVM(Selected) { WindowClose = form.Close };
            form.DataContext = vm;
            form.ShowDialog();
        }

        private bool CommandEditValidate(object obj)
        {
            return true;
        }

        private bool FilterAction(object obj)
        {
            var item = obj as pelamar;
            if (!string.IsNullOrEmpty(Cari))
            {
                if (item.IdPelamar.ToString().ToLower().Contains(Cari.ToLower()) || item.KodeRegistrasi.ToString().ToLower().Contains(Cari.ToLower()) || item.Nama.ToString().ToLower().Contains(Cari.ToLower()) || item.Sex.ToString().ToLower().Contains(Cari.ToLower()) || item.Alamat.ToString().ToLower().Contains(Cari.ToLower()) || item.TmpLahir.ToString().ToLower().Contains(Cari.ToLower()) || item.Tahun.ToString().ToLower().Contains(Cari.ToLower()))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        private void ProsesTambah(object obj)
        {
            var form = new AddPelamar();
            var vm = new PelamarVM(DataPelamar) { WindowClose = form.Close };
            form.DataContext = vm;
            form.ShowDialog();
            SourceViewPelamar.Refresh();
        }

        private bool TambahValidation(object obj)
        {
            return true;
        }

        public pelamar Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChange("Selected");
            }
        }

        public CommandHandler TambahPelamar { get; private set; }
    }
}
