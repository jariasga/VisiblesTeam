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

namespace InkaArt.Interface.Production
{
    public partial class SimulationReport : Form
    {
        private ReportsController reportControl = new ReportsController();

        public SimulationReport(string name)
        {
            InitializeComponent();
            showData(name);
        }

        public void showData(string name)
        {
            label_todaydate.Text = DateTime.Now.ToString("M/d/yyyy");
            label_simulationName.Text = name;
            //label_simulationTime.Text = time;

            DataTable simulationReportList = reportControl.getDataSimulation(name);
            populateDataGrid(simulationReportList);
        }

        private void populateDataGrid(DataTable simulationReportList)
        {
            simulation_grid.Rows.Clear();
            foreach (DataRow row in simulationReportList.Rows)
            {
                simulation_grid.Rows.Add(row["Fecha"], row["Iteraciones"], row["Huacos"], row["Piedras"], row["Retablos"], row["Trabajadores"]);
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add();
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Reporte de Simulación"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Reporte de Simulación";

                try
                {
                    for (int i = 0; i < simulation_grid.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = simulation_grid.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < simulation_grid.Rows.Count; i++)
                    {
                        for (int j = 0; j < simulation_grid.Columns.Count; j++)
                        {
                            if (simulation_grid.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = simulation_grid.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user.
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Exportación correcta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
    }
}
