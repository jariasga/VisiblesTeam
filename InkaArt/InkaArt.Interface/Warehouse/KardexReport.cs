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
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            if (dataGridView_movements.Rows.Count == 0)
                MessageBox.Show("No se generó el reporte debido a que no existen movimientos en el intervalo de tiempo elegido", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
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
                for (int j = 0; j < dataGridView_movements.Columns.Count; ++j)
                    xlWorkSheet.Cells[1, j + 1] = dataGridView_movements.Columns[j].HeaderText;
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[2, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
        }

        private void button_pdf_Click(object sender, EventArgs e)
        {
            if (dataGridView_movements.Rows.Count == 0)
                MessageBox.Show("No se generó el reporte debido a que no existen movimientos en el intervalo de tiempo elegido", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
            DateTime date = DateTime.ParseExact(label_todaydate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            SaveFileDialog dialogo = new SaveFileDialog();
            string x = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string titulo = "ReporteKardex-" + date.ToString("dd-MM-yyyy") + ".pdf";
            dialogo.Title = "Guardar reporte";
            dialogo.InitialDirectory = x;
            dialogo.FileName = titulo;
            dialogo.Filter = "Pdf Files|*.pdf";
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                titulo = dialogo.FileName;
            }
            else return;
            FileStream fs = new FileStream(titulo, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);

                Paragraph title = new Paragraph("REPORTE KARDEX", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph(" "));

                var phrase = new Phrase();
                phrase.Add(new Chunk("Fecha de generación de reporte:    ", boldFont));
                phrase.Add(new Chunk(label_todaydate.Text));
                document.Add(new Paragraph(phrase));
                document.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(7)
                {
                    WidthPercentage = 100,
                };

                for (int i = 0; i < dataGridView_movements.Columns.Count; i++)
                {
                    table.AddCell(dataGridView_movements.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView_movements.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_movements.Columns.Count; j++)
                    {
                        if (dataGridView_movements.Rows[i].Cells[j].Value != null)
                        {
                            if (j == 0)
                            {
                                table.AddCell(dataGridView_movements.Rows[i].Cells[j].Value.ToString().Substring(0, 10));
                            }
                            else
                                table.AddCell(dataGridView_movements.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            table.AddCell("");
                        }
                    }
                }
                document.Add(table);
                document.Add(new Paragraph(" "));

                document.Close();
                MessageBox.Show("Se generó el archivo del reporte kardex exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
