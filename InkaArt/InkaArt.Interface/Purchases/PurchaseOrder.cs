using System;
using System.Collections.Generic;
using System.Data;
using InkaArt.Business.Purchases;
using System.Windows.Forms;
using System.Linq;

namespace InkaArt.Interface.Purchases
{
    public partial class PurchaseOrder : Form
    {
        PurchaseOrderController control;
        DataTable purchaseOrderList;
        public PurchaseOrder()
        {
            InitializeComponent();
            control = new PurchaseOrderController();
            purchaseOrderList = control.getData();
            dataGridView_purchaseOrder.DataSource = purchaseOrderList;

            dataGridView_purchaseOrder.Columns["id_order"].HeaderText = "ID";
            dataGridView_purchaseOrder.Columns["id_supplier"].HeaderText = "Proveedor";
            dataGridView_purchaseOrder.Columns["status"].HeaderText = "Estado";
            dataGridView_purchaseOrder.Columns["creation_date"].HeaderText = "Fecha de emisión";
            dataGridView_purchaseOrder.Columns["delivery_date"].HeaderText = "Fecha de entrega";
            dataGridView_purchaseOrder.Columns["total"].HeaderText = "Total";

            dataGridView_purchaseOrder.Columns["delivery_date"].Visible=false;
        }

        private void filter() {
            DataRow[] rows;
            purchaseOrderList = control.getData();
            string cadena = "";
            if (textBox_id.Text.Length > 0)
            {
                cadena = " AND id_order = " + textBox_id.Text;
            }
            if (textBox_name.Text.Length > 0)
            {
                cadena += " AND id_supplier = " + textBox_name.Text;
            }
            /*if (dateTimePicker_creation.Text.Length > 0)
            {
                int inicio = int.Parse(dateTimePicker_creation.Value.ToString("yyyyMMdd"));
                int fin = int.Parse(dateTimePicker_creationEnd.Value.ToString("yyyyMMdd"));
                cadena += " AND format(cast(creationDate as date), 'yyyyMMdd') <= "+fin+" AND "+inicio+ " <= format(cast(creationDate as date), 'yyyyMMdd')";
            }*/
            if (String.Compare(comboBox_status.Text, "Activo") == 0)
            {
                rows = purchaseOrderList.Select("status LIKE '" + comboBox_status.Text + "'" + cadena);
            }
            else
            {
                rows = purchaseOrderList.Select("status LIKE '%" + comboBox_status.Text + "%'" + cadena);
            }
            if (rows.Any()) purchaseOrderList = rows.CopyToDataTable();
            else purchaseOrderList.Rows.Clear();
            string sortQuery = string.Format("id_order");
            purchaseOrderList.DefaultView.Sort = sortQuery;
        }

        private void button_search(object sender, EventArgs e)
        {
            textBox_name.Text = textBox_name.Text.Trim();
            filter();
            dataGridView_purchaseOrder.DataSource = purchaseOrderList;

            dataGridView_purchaseOrder.Columns["id_order"].HeaderText = "ID";
            dataGridView_purchaseOrder.Columns["id_supplier"].HeaderText = "Proveedor";
            dataGridView_purchaseOrder.Columns["status"].HeaderText = "Estado";
            dataGridView_purchaseOrder.Columns["creation_date"].HeaderText = "Fecha de emisión";
            dataGridView_purchaseOrder.Columns["delivery_date"].HeaderText = "Fecha de entrega";
            dataGridView_purchaseOrder.Columns["total"].HeaderText = "Total";

            dataGridView_purchaseOrder.Columns["delivery_date"].Visible = false;

        }

        private void button_add(object sender, EventArgs e)
        {
            Form purchaseDetail = new PurchaseOrderDetail(control);
            purchaseDetail.Show();
        }

        private void button_delete(object sender, EventArgs e)
        {
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView_purchaseOrder.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[0].Value);

                if (s == true)
                {
                    toDelete.Add(row);
                }
            }

            foreach (DataGridViewRow row in toDelete)
            {
                dataGridView_purchaseOrder.Rows.Remove(row);
            }
        }

        private void editPurchaseOrder(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentPurchaseOrder = dataGridView_purchaseOrder.CurrentRow;
            Form purchaseDetail = new PurchaseOrderDetail(currentPurchaseOrder,control);
            purchaseDetail.Show();
        }

        private void validating_id(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_id.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_id.Text = actualdata;
        }
    }
}
