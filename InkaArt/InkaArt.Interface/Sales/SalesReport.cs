using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Reports;

namespace InkaArt.Interface.Sales
{
    public partial class SalesReport : Form
    {
        private ReportsController reportControl = new ReportsController();

        public SalesReport(string fechaIni, string fechaFin, string producto)
        {
            InitializeComponent();
            showData(fechaIni, fechaFin, producto);
        }

        public void showData(string fechaIni, string fechaFin, string producto)
        {
            label_todaydate.Text = DateTime.Now.ToString("M/d/yyyy");
            label_iniDate.Text = fechaIni;
            label_finDate.Text = fechaFin;
            label_product.Text = producto;

            DataTable salesReportList = reportControl.getDataSales(fechaIni, fechaFin, producto);
            populateDataGrid(salesReportList);
        }

        private void populateDataGrid(DataTable salesReportList)
        {
            grid_salesReport.Rows.Clear();
            foreach (DataRow row in salesReportList.Rows)
            {
                grid_salesReport.Rows.Add(row["FechaEntrega"], row["Cliente"], row["TipoCliente"], row["Cantidad"], row["MontoTotal"]);
            }
        }
    }
}
