using SAWPenerimaanPegawai.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAWPenerimaanPegawai.Form
{
    /// <summary>
    /// Interaction logic for DataNilai.xaml
    /// </summary>
    public partial class DataNilai : Page
    {
        public DataNilai()
        {
            InitializeComponent();
            this.VM = new DataNilaiVM();
            this.DataContext = VM;
        }

        public DataNilaiVM VM { get; private set; }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Text = sender as TextBox;
            this.VM.Cari = Text.Text;
        }
    }
}
