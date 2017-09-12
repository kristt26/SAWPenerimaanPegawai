using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using DAL;
 
 namespace SAWPenerimaanPegawai 
{ 
     [TableName("pelamar")] 
     public class pelamar:BaseNotifyProperty  
   {
          [PrimaryKey("IdPelamar")] 
          [DbColumn("IdPelamar")] 
          public int IdPelamar 
          { 
               get{return _idpelamar;} 
               set{ 
                      _idpelamar=value; 
                     OnPropertyChange("IdPelamar");
                     }
          } 

          [DbColumn("KodeRegistrasi")] 
          public string KodeRegistrasi 
          { 
               get{return _koderegistrasi;} 
               set{ 
                      _koderegistrasi=value; 
                     OnPropertyChange("KodeRegistrasi");
                     }
          } 

          [DbColumn("Nama")] 
          public string Nama 
          { 
               get{return _nama;} 
               set{ 
                      _nama=value; 
                     OnPropertyChange("Nama");
                     }
          } 

          [DbColumn("Sex")] 
          public string Sex 
          { 
               get{return _sex;} 
               set{ 
                      _sex=value; 
                     OnPropertyChange("Sex");
                     }
          } 

          [DbColumn("Alamat")] 
          public string Alamat 
          { 
               get{return _alamat;} 
               set{ 
                      _alamat=value; 
                     OnPropertyChange("Alamat");
                     }
          } 

          [DbColumn("TmpLahir")] 
          public string TmpLahir 
          { 
               get{return _tmplahir;} 
               set{ 
                      _tmplahir=value; 
                     OnPropertyChange("TmpLahir");
                     }
          } 

          [DbColumn("TglLahir")] 
          public DateTime TglLahir 
          { 
               get{return _tgllahir;} 
               set{ 
                      _tgllahir=value; 
                     OnPropertyChange("TglLahir");
                     }
          } 

          [DbColumn("Kontak")] 
          public string Kontak 
          { 
               get{return _kontak;} 
               set{ 
                      _kontak=value; 
                     OnPropertyChange("Kontak");
                     }
          } 

          [DbColumn("Email")] 
          public string Email 
          { 
               get{return _email;} 
               set{ 
                      _email=value; 
                     OnPropertyChange("Email");
                     }
          } 

          [DbColumn("Pendidikan")] 
          public string Pendidikan 
          { 
               get{return _pendidikan;} 
               set{ 
                      _pendidikan=value; 
                     OnPropertyChange("Pendidikan");
                     }
          } 

          [DbColumn("Tahun")] 
          public string Tahun 
          { 
               get{return _tahun;} 
               set{ 
                      _tahun=value; 
                     OnPropertyChange("Tahun");
                     }
          } 

          private int  _idpelamar;
           private string  _koderegistrasi;
           private string  _nama;
           private string  _sex;
           private string  _alamat;
           private string  _tmplahir;
           private DateTime  _tgllahir;
           private string  _kontak;
           private string  _email;
           private string  _pendidikan;
           private string  _tahun;
      }
}


