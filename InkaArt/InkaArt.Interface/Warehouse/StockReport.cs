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
using Excel = Microsoft.Office.Interop.Excel;

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
            label_todayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            dataGrid_stocks.RowHeadersVisible = false;
            dataGrid_stocks.SelectAll();
            DataObject dataObj = dataGrid_stocks.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}
