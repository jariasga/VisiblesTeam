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
            lines = orderController.getLineXDocument(selectedInvoice.Cells[0].Value.ToString());
            populateDataGrid(lines);
        }

        private void populateLabels(DataGridViewRow selectedInvoice)
        {
            if (selectedInvoice.Cells[1].Value.ToString().Equals("Boleta")) label_type.Text = "Boleta - Nro";
            else if (selectedInvoice.Cells[1].Value.ToString().Equals("Factura")) label_type.Text = "Factura - Nro";
            else label_type.Text = "Nota de crédito - Nro";
            label_orderid.Text = idOrder.ToString();
            label_doc.Text = orderController.getClientDoc(idClient.ToString());
            label_name.Text = orderController.getClientName(idClient.ToString());
            label_invoiceid.Text = selectedInvoice.Cells[0].Value.ToString();
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
                grid_detail.Rows.Add(productName, row["pu"],row["finished"], Math.Round(float.Parse(row["pu"].ToString())*float.Parse(row["finished"].ToString()),2));               
            }
        }
    }
}
