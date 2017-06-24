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
using System.IO;

namespace InkaArt.Interface.Production
{
    public partial class PerformanceReport : Form
    {
        private ReportsController reportControl = new ReportsController();        

        public PerformanceReport(List<string> workersList, string fechaIni, string fechaFin)
        {
            InitializeComponent();
            showData(workersList, fechaIni, fechaFin);
        }

        public void showData(List<string> workersList, string fechaIni, string fechaFin)
        {
            label_today.Text = DateTime.Now.ToString("dd/MM/yyyy");
            System.Data.DataTable performanceReportList = reportControl.getDataPerformance(workersList, fechaIni, fechaFin);
            populateDataGrid(performanceReportList);           
        }

        private void populateDataGrid(System.Data.DataTable performanceReportList)
        {
            dataGridView_performance.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView_performance.Rows.Clear();
            dataGridView_performance.Columns[6].DefaultCellStyle.Format = "0.##";
            foreach (DataRow row in performanceReportList.Rows)
            {
                dataGridView_performance.Rows.Add(row["Fecha"], row["Trabajador"], row["Puesto"], row["Receta"], row["CantidadRota"], row["CantidadProducida"], row["Tiempo"]);
            }               
        }

        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            dataGridView_performance.RowHeadersVisible = false;
            dataGridView_performance.SelectAll();
            DataObject dataObj = dataGridView_performance.GetClipboardContent();
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
