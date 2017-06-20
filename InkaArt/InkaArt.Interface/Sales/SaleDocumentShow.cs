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
    public partial class SaleDocumentShow : Form
    {
        OrderController orderController = new OrderController();
        private int currentOrderId, currentClientId;
        public SaleDocumentShow(int orderId, int clientId)
        {
            InitializeComponent();
            currentOrderId = orderId;
            currentClientId = clientId;
        }

        private void SaleDocumentShow_Load(object sender, EventArgs e)
        {
            DataTable invoices = orderController.GetSalesDocument(currentOrderId);
            populateDataGrid(invoices);
        }

        private void populateDataGrid(DataTable invoices)
        {
            grid_documents.Rows.Clear();
            foreach (DataRow row in invoices.Rows)
            {
                string docType;
                if (row["idDocumentType"].ToString().Equals("1")) docType = "Boleta";
                else if (row["idDocumentType"].ToString().Equals("2")) docType = "Factura";
                else docType = "Nota de crédito";
                grid_documents.Rows.Add(row["idSalesDocument"], docType, row["amount"], row["igv"], row["totalAmount"]);
            }
        }

        private void grid_documents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                SaleDocumentDetail form = new SaleDocumentDetail(grid_documents.Rows[e.RowIndex], currentOrderId, currentClientId);
                form.Show();
            }
        }

        private void button_see_Click(object sender, EventArgs e)
        {
            int index = grid_documents.CurrentCell.RowIndex;
            SaleDocumentDetail form = new SaleDocumentDetail(grid_documents.Rows[index], currentOrderId, currentClientId);
            form.Show();
        }
    }
}
