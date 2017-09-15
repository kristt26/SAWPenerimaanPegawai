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
    public class DataNilaiVM:nilai
    {
        public CollectionView SourceDataNilai { get; set; }
        public List<nilai> DataNilai = new List<nilai>();
        private nilai _selected;
        private string _Cari;

        public CommandHandler TambahNilai { get; set; }
        public CommandHandler CommandEdit { get; set; }
        public CommandHandler DeleteCommand { get; set; }
        public string Cari
        {
            get { return _Cari; }
            set
            {
                _Cari = value;
                OnPropertyChange("Cari");
                SourceDataNilai.Refresh();
            }
        }
        public DataNilaiVM()
        {
            using (var db = new OcphDbContext())
            {
                DataNilai = (from a in db.Nilais.Select()
                             join b in db.Pelamars.Select() on a.IdPelamar equals b.IdPelamar
                             select new nilai { IdNilai=a.IdNilai, IdPelamar = a.IdPelamar, Nama = b.Nama, KodeRegistrasi = b.KodeRegistrasi, Berkas = a.Berkas, Kesehatan = a.Kesehatan, Akademik = a.Akademik, Psikotes = a.Psikotes, Wawancara = a.Wawancara }).ToList();
                SourceDataNilai = (CollectionView)CollectionViewSource.GetDefaultView(DataNilai);
                SourceDataNilai.Filter = FilterAction;
                SourceDataNilai.Refresh();
                TambahNilai = new CommandHandler { CanExecuteAction = TambahNilaiValidation, ExecuteAction = ProsesTambah };
                CommandEdit = new CommandHandler { CanExecuteAction = CommandEditValidate, ExecuteAction = CommandEditAction };
                DeleteCommand = new CommandHandler { CanExecuteAction = DeleteCommandValidate, ExecuteAction = DeleteCommandAction };
            }
        }

        private bool FilterAction(object obj)
        {
            var item = obj as nilai;
            if (!string.IsNullOrEmpty(Cari))
            {
                if (item.IdPelamar.ToString().ToLower().Contains(Cari.ToLower()) || item.KodeRegistrasi.ToString().ToLower().Contains(Cari.ToLower()) || item.Nama.ToString().ToLower().Contains(Cari.ToLower()))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        private void CommandEditAction(object obj)
        {
            var form = new EditNilai();
            var vm = new EditNilaiVM(Selected) { WindowClose = form.Close };
            form.DataContext = vm;
            form.ShowDialog();
            SourceDataNilai.Refresh();
            //form.DataContext = vm;
        }

        private bool CommandEditValidate(object obj)
        {
            return true;
        }

        private void DeleteCommandAction(object obj)
        {
            using (var db = new OcphDbContext())
            {
                var DeleteNilai = db.Nilais.Delete(o => o.IdNilai == Selected.IdNilai);
                if (DeleteNilai)
                {
                    DataNilai.Remove(Selected);
                    SourceDataNilai.Refresh();
                }
            }
        }

        private bool DeleteCommandValidate(object obj)
        {
            return true;
        }

        private void ProsesTambah(object obj)
        {
            var Form = new AddNilai();
            var VM = new AddNilaiVM(DataNilai) { WindowClose = Form.Close };
            Form.DataContext = VM;
            Form.ShowDialog();
            SourceDataNilai.Refresh();
        }

        public nilai Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChange("Selected");
            }
        }
        

        private bool TambahNilaiValidation(object obj)
        {
            return true;
        }
    }
}
