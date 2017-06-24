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
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

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
            label_todaydate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            CultureInfo provider = CultureInfo.InvariantCulture;            
            DateTime dti = DateTime.ParseExact(fechaIni, "M/d/yyyy", provider);
            label_iniDate.Text = dti.ToString("dd/MM/yyyy");

            DateTime dtf = DateTime.ParseExact(fechaFin, "M/d/yyyy", provider);
            label_finDate.Text = dtf.ToString("dd/MM/yyyy");

            label_product.Text = producto;

            DataTable salesReportList = reportControl.getDataSales(fechaIni, fechaFin, producto);
            populateDataGrid(salesReportList);
        }

        private void populateDataGrid(DataTable salesReportList)
        {
            grid_salesReport.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            grid_salesReport.Rows.Clear();
            foreach (DataRow row in salesReportList.Rows)
            {
                grid_salesReport.Rows.Add(row["FechaEntrega"], row["Cliente"], row["TipoCliente"], row["Cantidad"], row["MontoTotal"]);
            }
        }

        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            grid_salesReport.RowHeadersVisible = false;
            grid_salesReport.SelectAll();
            DataObject dataObj = grid_salesReport.GetClipboardContent();
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
