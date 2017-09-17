using Microsoft.Reporting.WinForms;
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
using System.Windows.Shapes;
using SAWPenerimaanPegawai.Model;
using SAWPenerimaanPegawai.Common;

namespace SAWPenerimaanPegawai.Form
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report(List<ReportModel> sourceReport)
        {
            InitializeComponent();
            this.Loaded += Report_Loaded;
            this.DataBaru = sourceReport;
        }

        public List<ReportModel> DataBaru { get; private set; }

        private void Report_Loaded(object sender, RoutedEventArgs e)
        {
           this.reportViewer1.ProcessingMode = ProcessingMode.Local;

            reportViewer1.LocalReport.ReportEmbeddedResource= "SAWPenerimaanPegawai.Report.ReportSAW.rdlc";

            //Gedata In List
            //var list = new List<ViewModel.HasilVM>();
            // Create a report data source for the sales order data  
            ReportDataSource dsSalesOrder = new ReportDataSource();
            dsSalesOrder.Name = "DataSet1";
            dsSalesOrder.Value = DataBaru;

            reportViewer1.LocalReport.DataSources.Add(dsSalesOrder);

            // Create a report parameter for the sales order number   
            //ReportParameter rpSalesOrderNumber = new ReportParameter();
           // rpSalesOrderNumber.Name = "SalesOrderNumber";
            //rpSalesOrderNumber.Values.Add("SO43661");

            // Set the report parameters for the report  
            //localReport.SetParameters(
               // new ReportParameter[] { rpSalesOrderNumber });

            // Refresh the report  
            reportViewer1.RefreshReport();
        }
    }
}
