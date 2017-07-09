using InkaArt.Business.Algorithm;
using InkaArt.Business.Reports;
using InkaArt.Classes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace InkaArt.Interface.Production
{
    public partial class PerformanceReport : Form
    {
        private ReportsController report_controller;
        private DataTable performance_table;

        public PerformanceReport(WorkerController selected_workers, DateTime start_date, DateTime end_date)
        {
            InitializeComponent();
            this.label_today.Text = DateTime.Now.ToString("dd/MM/yyyy");

            this.report_controller = new ReportsController();
            this.performance_table = report_controller.GetDataPerformance(selected_workers, start_date, end_date);
        }

        public PerformanceReport(WorkerController selected_workers)
        {
            InitializeComponent();
            label_today.Text = DateTime.Now.ToString("dd/MM/yyyy");

            this.report_controller = new ReportsController();
            this.performance_table = report_controller.GetDataPerformance(selected_workers);
        }

        private void PerformanceReport_Load(object sender, EventArgs e)
        {
            grid_performance.Rows.Clear();
            for (int i = 0; i < performance_table.Rows.Count; i++)
            {
                string worker = performance_table.Rows[i]["worker"].ToString();
                string recipe = performance_table.Rows[i]["recipe"].ToString();
                string job = performance_table.Rows[i]["job"].ToString();
                string breakage = string.Format("{0:0.00}%", performance_table.Rows[i]["breakage"]);
                string time = string.Format("{0:0.00} min", performance_table.Rows[i]["time"]);
                grid_performance.Rows.Add(worker, recipe, job, breakage, time);
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Add(Missing.Value);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.Item[1];

                worksheet.Cells[1, 1] = "Trabajador";
                worksheet.Cells[1, 2] = "Receta";
                worksheet.Cells[1, 3] = "Puesto de trabajo";
                worksheet.Cells[1, 4] = "% promedio de rotura";
                worksheet.Cells[1, 5] = "Tiempo promedio";

                for (int r = 0; r < grid_performance.Rows.Count; r++)
                    for (int c = 0; c < grid_performance.Columns.Count; c++)
                        worksheet.Cells[r + 2, c + 1] = grid_performance[c, r].Value.ToString();

                Excel.Range first_row = worksheet.Range["A1", "E1"];
                first_row.Font.Bold = true;
                first_row.Font.Color = ColorTranslator.ToOle(Color.White);
                first_row.Interior.Color = ColorTranslator.ToOle(Color.Black);
                worksheet.Columns.AutoFit();

                excel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo exportar el reporte a Microsoft Excel. " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LogHandler.WriteLine(ex.ToString());
            }
        }

        private void button_pdf_Click(object sender, EventArgs e)
        {
            DialogResult result = this.save_pdf_dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            try
            {
                FileStream file = new FileStream(this.save_pdf_dialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                document.Open();

                Paragraph title = new Paragraph("REPORTE DE DESEMPEÑO DE TRABAJADORES", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20));
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                document.Add(new Paragraph("   "));
                Chunk date_chunk = new Chunk("Fecha de generación de reporte:    " + label_today.Text);
                date_chunk.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                document.Add(new Paragraph(date_chunk));
                document.Add(new Paragraph("   "));

                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                for (int i = 0; i < grid_performance.Columns.Count; i++)
                    table.AddCell(grid_performance.Columns[i].HeaderText);
                for (int r = 0; r < grid_performance.Rows.Count; r++)
                    for (int c = 0; c < grid_performance.Columns.Count; c++)
                        table.AddCell(grid_performance[c, r].Value.ToString());
                document.Add(table);

                document.Close();
                file.Close();

                MessageBox.Show("Se generó el archivo del reporte de desempeño de trabajadores exitosamente.", "Inka Art",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo exportar el reporte a PDF. " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LogHandler.WriteLine(ex.ToString());
            }
        }
        
    }
}
