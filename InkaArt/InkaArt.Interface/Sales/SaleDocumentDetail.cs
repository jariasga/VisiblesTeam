using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Sales;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InkaArt.Interface.Sales
{
    public partial class SaleDocumentDetail : Form
    {
        private DataGridViewRow selectedInvoice;
        private int idOrder;
        private int idClient;
        private DataTable lines;
        OrderController orderController = new OrderController();
        public SaleDocumentDetail(DataGridViewRow dataGridViewRow, int orderId, int clientId)
        {
            InitializeComponent();
            selectedInvoice = dataGridViewRow;
            idOrder = orderId;
            idClient = clientId;
            lines = new DataTable();
        }        

        private void SaleDocumentDetail_Load(object sender, EventArgs e)
        {
            populateLabels(selectedInvoice);
            lines = orderController.getLineXDocument(int.Parse(selectedInvoice.Cells[0].Value.ToString()));
            populateDataGrid(lines);
        }

        private void populateLabels(DataGridViewRow selectedInvoice)
        {
            if (selectedInvoice.Cells[1].Value.ToString().Equals("Boleta")) label_invoiceid.Text = "Boleta - Nro ";
            else if (selectedInvoice.Cells[1].Value.ToString().Equals("Factura")) label_invoiceid.Text = "Factura - Nro ";
            else label_invoiceid.Text = "Nota de crédito - Nro ";
            label_orderid.Text = idOrder.ToString();
            label_doc.Text = orderController.getClientDoc(idClient.ToString());
            label_name.Text = orderController.getClientName(idClient.ToString());
            label_invoiceid.Text += selectedInvoice.Cells[0].Value.ToString();
            label_subtotal.Text = selectedInvoice.Cells[2].Value.ToString();
            label_igv.Text = selectedInvoice.Cells[3].Value.ToString();
            label_total.Text = selectedInvoice.Cells[4].Value.ToString();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void populateDataGrid(DataTable lines)
        {
            grid_detail.Rows.Clear();
            foreach (DataRow row in lines.Rows)
            {
                string productName = orderController.getProductName(orderController.getProductId(row["idLineItem"].ToString()));
                if (int.Parse(row["finished"].ToString()) > 0) grid_detail.Rows.Add(productName, row["pu"],row["finished"], Math.Round(float.Parse(row["pu"].ToString())*float.Parse(row["finished"].ToString()),2));               
            }
        }

        private void button_pdf_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("Factura-Pedido"+label_orderid.Text+".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);

            Paragraph title = new Paragraph("FACTURA", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);
            document.Add(new Paragraph(" "));

            var phrase = new Phrase();
            phrase.Add(new Chunk("N° Documento:    ", boldFont));
            phrase.Add(new Chunk(label_doc.Text));
            document.Add(new Paragraph(phrase));
            document.Add(new Paragraph(" "));

            var phrase2 = new Phrase();
            phrase2.Add(new Chunk("Cliente:    ", boldFont));
            phrase2.Add(new Chunk(label_name.Text));
            document.Add(new Paragraph(phrase2));
            document.Add(new Paragraph(" "));

            var phrase3 = new Phrase();
            phrase3.Add(new Chunk("Detalle:    ", boldFont));
            document.Add(new Paragraph(phrase3));
            document.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(4)
            {
                WidthPercentage = 100,
            };

            for (int i = 0; i < grid_detail.Columns.Count; i++)
            {
                table.AddCell(grid_detail.Columns[i].HeaderText);
            }
            for (int i = 0; i < grid_detail.Rows.Count; i++)
            {
                for (int j = 0; j < grid_detail.Columns.Count; j++)
                {
                    if (grid_detail.Rows[i].Cells[j].Value != null)
                    {
                            table.AddCell(grid_detail.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        table.AddCell("");
                    }
                }
            }
            document.Add(table);
            document.Add(new Paragraph(" "));

            var phrase4 = new Phrase();
            phrase4.Add(new Chunk("Subtotal:    ", boldFont));
            phrase4.Add(new Chunk(label_subtotal.Text));
            document.Add(new Paragraph(phrase4));
            document.Add(new Paragraph(" "));

            var phrase5 = new Phrase();
            phrase5.Add(new Chunk("IGV:    ", boldFont));
            phrase5.Add(new Chunk(label_igv.Text));
            document.Add(new Paragraph(phrase5));
            document.Add(new Paragraph(" "));

            var phrase6 = new Phrase();
            phrase6.Add(new Chunk("Total:    ", boldFont));
            phrase6.Add(new Chunk(label_total.Text));
            document.Add(new Paragraph(phrase6));

            document.Close();
            MessageBox.Show("Se generó el archivo de la factura exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
