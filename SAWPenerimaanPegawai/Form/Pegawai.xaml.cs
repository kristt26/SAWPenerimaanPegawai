﻿using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI;
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
using SAWPenerimaanPegawai.ViewModel;

namespace SAWPenerimaanPegawai.Form
{
    /// <summary>
    /// Interaction logic for Pegawai.xaml
    /// </summary>
    public partial class Pegawai :Page
    {
        public Pegawai()
        {
            InitializeComponent();
            this.VM = new DataPelamarVM();
            this.DataContext = VM;
        }

        public DataPelamarVM VM { get; private set; }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Text = sender as TextBox;
            this.VM.Cari = Text.Text;
        }
    }
}
