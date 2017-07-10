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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
                row.Cells[2].Value = day.HuacosProduced;
                row.Cells[3].Value = day.HuamangaProduced;
                row.Cells[4].Value = day.AltarpieceProduced;
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
            if (simulation_grid.Rows.Count == 0)
                MessageBox.Show("No se generó el reporte debido a que no se han realizado simulaciones", "Error", MessageBoxButtons.OK,
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
                for (int j = 0; j < simulation_grid.Columns.Count; ++j)
                    xlWorkSheet.Cells[1, j + 1] = simulation_grid.Columns[j].HeaderText;
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[2, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
        }

        private void button_pdf_Click(object sender, EventArgs e)
        {
            if (simulation_grid.Rows.Count == 0)
                MessageBox.Show("No se generó el reporte debido a que no se han realizado simulaciones", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
            SaveFileDialog dialogo = new SaveFileDialog();
            string x = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string titulo = "ReporteStocks.pdf";
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

                Paragraph title = new Paragraph("REPORTE DE STOCKS", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph(" "));

                var phrase = new Phrase();
                phrase.Add(new Chunk("Fecha de generación de reporte:    ", boldFont));
                phrase.Add(new Chunk(label_todaydate.Text));
                document.Add(new Paragraph(phrase));
                document.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(6)
                {
                    WidthPercentage = 100,
                };

                for (int i = 0; i < simulation_grid.Columns.Count; i++)
                {
                    table.AddCell(simulation_grid.Columns[i].HeaderText);
                }
                for (int i = 0; i < simulation_grid.Rows.Count; i++)
                {
                    for (int j = 0; j < simulation_grid.Columns.Count; j++)
                    {
                        if (simulation_grid.Rows[i].Cells[j].Value != null)
                        {
                            if (j == 0)
                            {
                                table.AddCell(simulation_grid.Rows[i].Cells[j].Value.ToString().Substring(0, 10));
                            }
                            else
                                table.AddCell(simulation_grid.Rows[i].Cells[j].Value.ToString());
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
                MessageBox.Show("Se generó el archivo del reporte de desempeño de trabajadores exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
