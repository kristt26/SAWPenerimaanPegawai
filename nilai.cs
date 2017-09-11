using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using DAL;
 
 namespace SAWPenerimaanPegawai 
{ 
     [TableName("nilai")] 
     public class nilai:BaseNotifyProperty  
   {
          [PrimaryKey("IdNilai")] 
          [DbColumn("IdNilai")] 
          public int IdNilai 
          { 
               get{return _idnilai;} 
               set{ 
                      _idnilai=value; 
                     OnPropertyChange("IdNilai");
                     }
          } 

          [DbColumn("IdPelamar")] 
          public int IdPelamar 
          { 
               get{return _idpelamar;} 
               set{ 
                      _idpelamar=value; 
                     OnPropertyChange("IdPelamar");
                     }
          } 

          [DbColumn("Berkas")] 
          public double Berkas 
          { 
               get{return _berkas;} 
               set{ 
                      _berkas=value; 
                     OnPropertyChange("Berkas");
                     }
          } 

          [DbColumn("Kesehatan")] 
          public double Kesehatan 
          { 
               get{return _kesehatan;} 
               set{ 
                      _kesehatan=value; 
                     OnPropertyChange("Kesehatan");
                     }
          } 

          [DbColumn("Akademik")] 
          public double Akademik 
          { 
               get{return _akademik;} 
               set{ 
                      _akademik=value; 
                     OnPropertyChange("Akademik");
                     }
          } 

          [DbColumn("Psikotes")] 
          public double Psikotes 
          { 
               get{return _psikotes;} 
               set{ 
                      _psikotes=value; 
                     OnPropertyChange("Psikotes");
                     }
          } 

          [DbColumn("Wawancara")] 
          public double Wawancara 
          { 
               get{return _wawancara;} 
               set{ 
                      _wawancara=value; 
                     OnPropertyChange("Wawancara");
                     }
          } 

          private int  _idnilai;
           private int  _idpelamar;
           private double  _berkas;
           private double  _kesehatan;
           private double  _akademik;
           private double  _psikotes;
           private double  _wawancara;
      }
}


