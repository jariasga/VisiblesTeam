﻿using System;
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
            label_todayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            dataGrid_stocks.RowHeadersVisible = false;
            dataGrid_stocks.SelectAll();
            DataObject dataObj = dataGrid_stocks.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (dataGrid_stocks.Rows.Count == 0)
                MessageBox.Show("No se generó el reporte debido a que no existen items en los almacenes", "Error", MessageBoxButtons.OK,
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
                for (int j = 0; j < dataGrid_stocks.Columns.Count; ++j)
                    xlWorkSheet.Cells[1, j + 1] = dataGrid_stocks.Columns[j].HeaderText;
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[2, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
        }

        private void button_pdf_Click(object sender, EventArgs e)
        {
            if (dataGrid_stocks.Rows.Count == 0)
                MessageBox.Show("No se generó el reporte debido a que no existen items en los almacenes", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
            DateTime date = DateTime.ParseExact(label_todayDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            SaveFileDialog dialogo = new SaveFileDialog();
            string x = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string titulo = "ReporteStocks-" + date.ToString("dd-MM-yyyy") + ".pdf";
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
                phrase.Add(new Chunk(label_todayDate.Text));
                document.Add(new Paragraph(phrase));
                document.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(7)
                {
                    WidthPercentage = 100,
                };

                for (int i = 0; i < dataGrid_stocks.Columns.Count; i++)
                {
                    table.AddCell(dataGrid_stocks.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGrid_stocks.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGrid_stocks.Columns.Count; j++)
                    {
                        if (dataGrid_stocks.Rows[i].Cells[j].Value != null)
                        {
                            table.AddCell(dataGrid_stocks.Rows[i].Cells[j].Value.ToString());
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
                MessageBox.Show("Se generó el archivo del reporte de stocks exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
