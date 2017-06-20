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
                    for (int i = 0; i < grid_salesReport.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = grid_salesReport.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < grid_salesReport.Rows.Count; i++)
                    {
                        for (int j = 0; j < grid_salesReport.Columns.Count; j++)
                        {
                            if (grid_salesReport.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = grid_salesReport.Rows[i].Cells[j].Value.ToString();
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
