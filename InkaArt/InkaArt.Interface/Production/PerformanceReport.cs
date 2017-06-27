using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using InkaArt.Business.Reports;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            int i = 0, cantP = 0, cantR = 0;
            decimal tiempos = 0;
            dataGridView_performance.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView_performance.Rows.Clear();
            dataGridView_performance.Columns[6].DefaultCellStyle.Format = "0.##";
            foreach (DataRow row in performanceReportList.Rows)
            {
                dataGridView_performance.Rows.Add(row["Fecha"], row["Trabajador"], row["Puesto"], row["Receta"], row["CantidadRota"], row["CantidadProducida"], row["Tiempo"]);
            }
            foreach (DataRow row in performanceReportList.Rows)
            {
                tiempos += Decimal.Parse(row["Tiempo"].ToString());
                cantP += Int32.Parse(row["CantidadProducida"].ToString());
                cantR += Int32.Parse(row["CantidadRota"].ToString());
                i++;
            }
            if (i != 0)
            {
                decimal t = tiempos / i;
                label_tprom.Text = (Math.Truncate(t * 1000m) / 1000m).ToString();
                decimal cp = cantP / i;
                label_cant.Text = (Math.Truncate(cp)).ToString();
                decimal cr = cantR / i;
                label_rota.Text = (Math.Truncate(cr)).ToString();
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

        private void button_pdf_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("ReporteDesempeñoTrabajadores.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);

            Paragraph title = new Paragraph("REPORTE DE DESEMPEÑO DE TRABAJADORES", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);
            document.Add(new Paragraph(" "));
            var phrase = new Phrase();
            phrase.Add(new Chunk("Fecha de generación de reporte:    ", boldFont));
            phrase.Add(new Chunk(label_today.Text));
            document.Add(new Paragraph(phrase));
            document.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(7)
            {
                WidthPercentage = 100,
            };
            
            for (int i = 0; i < dataGridView_performance.Columns.Count; i++)
            {
                table.AddCell(dataGridView_performance.Columns[i].HeaderText);
            }
            for (int i = 0; i < dataGridView_performance.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_performance.Columns.Count; j++)
                {
                    if (dataGridView_performance.Rows[i].Cells[j].Value != null)
                    {
                        if (j == 0)
                        {
                            table.AddCell(dataGridView_performance.Rows[i].Cells[j].Value.ToString().Substring(0,10));
                        } else if (j == 6)
                        {
                            decimal t = Convert.ToDecimal(dataGridView_performance.Rows[i].Cells[j].Value);
                            t = Math.Truncate(t * 1000m) / 1000m;
                            table.AddCell(t.ToString());
                        }
                        else
                        table.AddCell(dataGridView_performance.Rows[i].Cells[j].Value.ToString());
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
            phrase2.Add(new Chunk("Tiempo promedio (min):                         ", boldFont));
            phrase2.Add(new Chunk(label_tprom.Text));
            document.Add(new Paragraph(phrase2));

            var phrase3 = new Phrase();
            phrase3.Add(new Chunk("Cantidad producida promedio (u):            ", boldFont));
            phrase3.Add(new Chunk(label_cant.Text));
            document.Add(new Paragraph(phrase3));

            var phrase4 = new Phrase();
            phrase4.Add(new Chunk("Cantidad rota promedio (u):                         ", boldFont));
            phrase4.Add(new Chunk(label_rota.Text));
            document.Add(new Paragraph(phrase4));

            document.Close();
            MessageBox.Show("Se generó el archivo del reporte de desempeño de trabajadores exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
