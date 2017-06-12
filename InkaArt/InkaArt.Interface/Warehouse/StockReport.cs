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

namespace InkaArt.Interface.Warehouse
{
    public partial class StockReport : Form
    {
        private ReportsController reportControl = new ReportsController();

        public StockReport(int flag)
        {
            InitializeComponent();
            showData(flag);
        }

        public void showData(int flag)
        {
            label_todayDate.Text = DateTime.Now.ToString("M/d/yyyy");
            DataTable stocksReportList = reportControl.getDataStocks(flag);
            populateDataGrid(stocksReportList);
        }

        private void populateDataGrid(DataTable stocksReportList)
        {
            dataGrid_stocks.Rows.Clear();
            foreach (DataRow row in stocksReportList.Rows)
            {
                dataGrid_stocks.Rows.Add(row["Tipo"], row["IdItem"], row["NameItem"], row["NameWarehouse"], row["CurrentStock"], row["VirtualStock"], row["Unit"]);
            }
        }
    }
}
