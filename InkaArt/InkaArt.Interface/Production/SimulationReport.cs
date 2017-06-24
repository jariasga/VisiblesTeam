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
using InkaArt.Business.Algorithm;
using Excel = Microsoft.Office.Interop.Excel;

namespace InkaArt.Interface.Production
{
    public partial class SimulationReport : Form
    {
        private ReportsController reportControl = new ReportsController();

        public SimulationReport(Simulation simulation)
        {
            InitializeComponent();
            showData(simulation);
        }

        public void showData(Simulation simulation)
        {
            label_todaydate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label_simulationName.Text = simulation.Name;
            label_simulationTime.Text = simulation.Time.ToString();

            foreach (Assignment day in simulation.Assignments)
            {
                DataGridViewRow row = (DataGridViewRow)simulation_grid.Rows[0].Clone();
                row.Cells[0].Value = day.Date;
                row.Cells[1].Value = day.TabuIterations;
                row.Cells[2].Value = day.Huacos_produced;
                row.Cells[3].Value = day.Huamanga_produced;
                row.Cells[4].Value = day.Altarpiece_produced;
                row.Cells[5].Value = simulation.SelectedWorkers.Count();
                simulation_grid.Rows.Add(row);
            }
            
            //DataTable simulationReportList = reportControl.getDataSimulation(simulation);
            //populateDataGrid(simulationReportList);
        }

        private void populateDataGrid(DataTable simulationReportList)
        {
            simulation_grid.Rows.Clear();
            foreach (DataRow row in simulationReportList.Rows)
            {
                simulation_grid.Rows.Add(row["Fecha"], row["Iteraciones"], row["Huacos"], row["Piedras"], row["Retablos"], row["Trabajadores"]);
            }
        }

        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            simulation_grid.RowHeadersVisible = false;
            simulation_grid.SelectAll();
            DataObject dataObj = simulation_grid.GetClipboardContent();
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
