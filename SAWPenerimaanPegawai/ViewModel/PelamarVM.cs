using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewApp.ViewModels;

namespace SAWPenerimaanPegawai.ViewModel
{
    public class PelamarVM: pelamar
    {
        private List<pelamar> dataPelamar;

        public PelamarVM(List<pelamar> dataPelamar)
        {
            this.dataPelamar = dataPelamar;
            TglLahir = DateTime.Now;
            TambahCommand = new CommandHandler { CanExecuteAction = TambahValidate, ExecuteAction = ProsesTambah };
            BatalCommand = new CommandHandler { CanExecuteAction = BatalValidation, ExecuteAction = BatalAction };
        }

        private void BatalAction(object obj)
        {
            WindowClose();
        }

        private bool BatalValidation(object obj)
        {
            return true;
        }

        private void ProsesTambah(object obj)
        {
            using (var db = new OcphDbContext())
            {
                var Pelamar = (pelamar)this;
                this.ClonePelamar = (pelamar)Pelamar.Clone();
                var InsertPelamar = db.Pelamars.InsertAndGetLastID(ClonePelamar);
                if(InsertPelamar>0)
                {
                    try
                    {
                        ClonePelamar.IdPelamar = InsertPelamar;
                        this.dataPelamar.Add(ClonePelamar);
                        WindowClose();
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }

        private bool TambahValidate(object obj)
        {
            return true;
        }

        public Action WindowClose { get; internal set; }
        public CommandHandler TambahCommand { get; private set; }
        public CommandHandler BatalCommand { get; set; }
        public pelamar ClonePelamar { get; set; }
        public string Error => throw new NotImplementedException();
    }
}
