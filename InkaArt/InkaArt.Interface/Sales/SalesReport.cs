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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            decimal sum = 0;
            grid_salesReport.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            grid_salesReport.Rows.Clear();
            foreach (DataRow row in salesReportList.Rows)
            {
                grid_salesReport.Rows.Add(row["FechaEntrega"], row["Cliente"], row["TipoCliente"], row["Cantidad"], row["MontoTotal"]);
            }
            foreach (DataRow row in salesReportList.Rows)
            {
                sum += Decimal.Parse(row["MontoTotal"].ToString());
            }
            label_total.Text = sum.ToString();
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
            if (grid_salesReport.Rows.Count == 0)
                MessageBox.Show("No se generó el reporte debido a que no se han realizado ventas en el intervalo de tiempo elegido", "Error", MessageBoxButtons.OK,
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
                for (int j = 0; j < grid_salesReport.Columns.Count; ++j)
                    xlWorkSheet.Cells[1, j + 1] = grid_salesReport.Columns[j].HeaderText;
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[2, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
        }

        private void button_pdf_Click(object sender, EventArgs e)
        {
            if (grid_salesReport.Rows.Count == 0)
                MessageBox.Show("No se generó el reporte debido a que no se han realizado ventas en el intervalo de tiempo elegido", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                DateTime date = DateTime.ParseExact(label_todaydate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                FileStream fs = new FileStream("ReporteVentas-" + date.ToString("dd-MM-yyyy") + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);

                Paragraph title = new Paragraph("REPORTE DE VENTAS", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph(" "));

                var phrase = new Phrase();
                phrase.Add(new Chunk("Fecha de generación de reporte:    ", boldFont));
                phrase.Add(new Chunk(label_todaydate.Text));
                document.Add(new Paragraph(phrase));
                document.Add(new Paragraph(" "));

                var phraseI = new Phrase();
                phraseI.Add(new Chunk("Fecha inicial de entrega:    ", boldFont));
                phraseI.Add(new Chunk(label_iniDate.Text));
                document.Add(new Paragraph(phraseI));
                document.Add(new Paragraph(" "));

                var phraseF = new Phrase();
                phraseF.Add(new Chunk("Fecha final de entrega:    ", boldFont));
                phraseF.Add(new Chunk(label_finDate.Text));
                document.Add(new Paragraph(phraseF));
                document.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(5)
                {
                    WidthPercentage = 100,
                };

                for (int i = 0; i < grid_salesReport.Columns.Count; i++)
                {
                    table.AddCell(grid_salesReport.Columns[i].HeaderText);
                }
                for (int i = 0; i < grid_salesReport.Rows.Count; i++)
                {
                    for (int j = 0; j < grid_salesReport.Columns.Count; j++)
                    {
                        if (grid_salesReport.Rows[i].Cells[j].Value != null)
                        {
                            if (j == 0)
                            {
                                table.AddCell(grid_salesReport.Rows[i].Cells[j].Value.ToString().Substring(0, 10));
                            }
                            else if (j == 4)
                            {
                                decimal t = Convert.ToDecimal(grid_salesReport.Rows[i].Cells[j].Value);
                                t = Math.Truncate(t * 1000m) / 1000m;
                                table.AddCell(t.ToString());
                            }
                            else
                                table.AddCell(grid_salesReport.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                            table.AddCell("");
                        }
                    }
                }
                document.Add(table);
                document.Add(new Paragraph(" "));

                var phrase2 = new Phrase();
                phrase2.Add(new Chunk("Monto Total (S/.):                         ", boldFont));
                phrase2.Add(new Chunk(label_total.Text));
                document.Add(new Paragraph(phrase2));

                document.Close();
                MessageBox.Show("Se generó el archivo del reporte de ventas exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
