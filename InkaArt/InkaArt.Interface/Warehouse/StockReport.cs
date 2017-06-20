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

        private void button_export_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add();
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Reporte de Stocks"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Reporte de Stocks";

                try
                {
                    for (int i = 0; i < dataGrid_stocks.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dataGrid_stocks.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGrid_stocks.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGrid_stocks.Columns.Count; j++)
                        {
                            if (dataGrid_stocks.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGrid_stocks.Rows[i].Cells[j].Value.ToString();
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
