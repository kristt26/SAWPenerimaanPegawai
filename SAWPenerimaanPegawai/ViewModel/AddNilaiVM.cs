using DAL;
using System;
using System.Linq;
using System.Collections.Generic;
using ViewApp.ViewModels;
using static SAWPenerimaanPegawai.Helper.EnumCollection;

namespace SAWPenerimaanPegawai.ViewModel
{
    public class AddNilaiVM : nilai
    {
        private List<nilai> dataNilai;

        public Wawancaras HasilWawancara { get; set; }
        public Kesehatans HasilKesehatan { get; set; }
        public CommandHandler TambahCommand { get; set; }

        public List<Wawancaras> NilaiWawancara { get; set; }
        public List<Kesehatans> NilaiKesehatan { get; set; }
        public AddNilaiVM(List<nilai> dataNilai)
        {
            this.dataNilai = dataNilai;
            NilaiWawancara = new List<Wawancaras>();
            NilaiKesehatan = new List<Kesehatans>();
            NilaiWawancara.Add(Wawancaras.Tidak);
            NilaiWawancara.Add(Wawancaras.Kurang);
            NilaiWawancara.Add(Wawancaras.Cukup);
            NilaiWawancara.Add(Wawancaras.Siap);
            NilaiKesehatan.Add(Kesehatans.Tidak);
            NilaiKesehatan.Add(Kesehatans.Sehat);
            NilaiKesehatan.Add(Kesehatans.SehatJasmani);
            TambahCommand = new CommandHandler { CanExecuteAction = AddCommandValidation, ExecuteAction = AddCommand };
        }

        private void AddCommand(object obj)
        {
            using (var db = new OcphDbContext())
            {
                List<pelamar> NewData = new List<pelamar>();
                var _DataNilai = (nilai)this;
                var CloneDataNilai = (nilai)_DataNilai.Clone();
                var InsertNilai = db.Nilais.InsertAndGetLastID(CloneDataNilai);
                try
                {

                    CloneDataNilai.IdNilai= InsertNilai;
                    NewData = db.Pelamars.Where(o => o.IdPelamar == CloneDataNilai.IdPelamar).ToList();
                    CloneDataNilai.Nama = NewData[0].Nama;
                    CloneDataNilai.KodeRegistrasi = NewData[0].KodeRegistrasi;
                    this.dataNilai.Add(CloneDataNilai);
                    WindowClose();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private bool AddCommandValidation(object obj)
        {
            return true;
        }

        public Action WindowClose { get; internal set; }
    }
}
