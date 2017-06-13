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
    public partial class DocumentSearch : Form
    {
        OrderController orderController = new OrderController();
        public int SelectedOrderId { get; private set; }
        public int SelectedDocumentId { get; private set; }
        public DocumentSearch()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DocumentSearch_Load(object sender, EventArgs e)
        {
            DataTable salesDocument = orderController.GetSalesDocument();
            populateDataGrid(salesDocument);
        }
        private void populateDataGrid(DataTable list)
        {
            grid_documents.Rows.Clear();
            foreach (DataRow row in list.Rows)
            {
                string docType = row["idDocumentType"].ToString().Equals("1") ? "Boleta" : "Factura";
                grid_documents.Rows.Add(row["idSalesDocument"], docType, row["amount"], row["igv"], row["totalAmount"], row["idOrder"]);
            }
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            int index = grid_documents.CurrentCell.RowIndex;
            SelectedOrderId = int.Parse(grid_documents.Rows[index].Cells[0].Value.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }

        private void grid_documents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                SelectedOrderId = int.Parse(grid_documents.Rows[e.RowIndex].Cells[0].Value.ToString());
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
