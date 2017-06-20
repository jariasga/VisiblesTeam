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
            label_todaydate.Text = DateTime.Now.ToString("M/d/yyyy");
            
            DataTable movementsReportList = reportControl.getDataMovements(fechaIni,  fechaFin, items, warehouses);
            populateDataGrid(movementsReportList);
        }

        private void populateDataGrid(DataTable salesReportList)
        {
            dataGridView_movements.Rows.Clear();
            foreach (DataRow row in salesReportList.Rows)
            {
                dataGridView_movements.Rows.Add(row["Fecha"], row["IdMovimiento"], row["TipoMovimiento"], row["Razon"], row["Almacen"], row["Item"], row["Cantidad"]);
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
                worksheet = workbook.Sheets["Reporte Kardex"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Reporte Kardex";

                try
                {
                    for (int i = 0; i < dataGridView_movements.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dataGridView_movements.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGridView_movements.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView_movements.Columns.Count; j++)
                        {
                            if (dataGridView_movements.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView_movements.Rows[i].Cells[j].Value.ToString();
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
