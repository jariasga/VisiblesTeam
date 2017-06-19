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

        public PerformanceReport(string worker, int chosenIndex, string fechaIni, string fechaFin)
        {
            InitializeComponent();
            showData(worker, chosenIndex, fechaIni, fechaFin);
        }

        public void showData(string worker, int chosenIndex, string fechaIni, string fechaFin)
        {
            label_nameWorker.Text = worker;
            label_today.Text = DateTime.Now.ToString("M/d/yyyy");
            System.Data.DataTable performanceReportList = reportControl.getDataPerformance(worker, chosenIndex, fechaIni, fechaFin);
            populateDataGrid(performanceReportList);           
        }

        private void populateDataGrid(System.Data.DataTable performanceReportList)
        {
            dataGridView_performance.Rows.Clear();
            foreach (DataRow row in performanceReportList.Rows)
            {
                dataGridView_performance.Rows.Add(row["Fecha"], row["Puesto"], row["Receta"], row["CantidadRota"], row["CantidadProducida"], row["Tiempo"]);
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
                worksheet = workbook.Sheets["Reporte de Desempeño"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Reporte de Desempeño";

                try
                {
                    for (int i = 0; i < dataGridView_performance.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dataGridView_performance.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGridView_performance.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView_performance.Columns.Count; j++)
                        {
                            if (dataGridView_performance.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView_performance.Rows[i].Cells[j].Value.ToString();
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
