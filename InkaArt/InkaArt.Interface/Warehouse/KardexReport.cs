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
    public partial class KardexReport : Form
    {
        private ReportsController reportControl = new ReportsController();

        public KardexReport(string fechaIni, string fechaFin, List<string> items, List<string> warehouses)
        {
            InitializeComponent();
            showData(fechaIni, fechaFin, items, warehouses);
        }

        public void showData(string fechaIni, string fechaFin, List<string> items, List<string> warehouses)
        {
            label_todaydate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            DataTable movementsReportList = reportControl.getDataMovements(fechaIni,  fechaFin, items, warehouses);
            populateDataGrid(movementsReportList);
        }

        private void populateDataGrid(DataTable movementsReportList)
        {
            dataGridView_movements.Rows.Clear();
            dataGridView_movements.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            foreach (DataRow row in movementsReportList.Rows)
            {
                dataGridView_movements.Rows.Add(row["Fecha"], row["IdMovimiento"], row["TipoMovimiento"], row["Razon"], row["Almacen"], row["Item"], row["Cantidad"]);
            }
        }

        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            dataGridView_movements.RowHeadersVisible = false;
            dataGridView_movements.SelectAll();
            DataObject dataObj = dataGridView_movements.GetClipboardContent();
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
