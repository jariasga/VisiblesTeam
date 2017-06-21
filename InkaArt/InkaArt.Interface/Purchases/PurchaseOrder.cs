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
        SupplierController controlSup;
        DataTable purchaseOrderList;
        public PurchaseOrder()
        {
            InitializeComponent();
            control = new PurchaseOrderController();
            controlSup = new SupplierController();
            purchaseOrderList = control.getData();
            desarrolloBusqueda();
            /*
            dataGridView_purchaseOrder.DataSource = purchaseOrderList;

            dataGridView_purchaseOrder.Columns["id_order"].HeaderText = "ID";
            dataGridView_purchaseOrder.Columns["id_supplier"].HeaderText = "Proveedor";
            dataGridView_purchaseOrder.Columns["status"].HeaderText = "Estado";
            dataGridView_purchaseOrder.Columns["creation_date"].HeaderText = "Fecha de emisión";
            dataGridView_purchaseOrder.Columns["delivery_date"].HeaderText = "Fecha de entrega";
            dataGridView_purchaseOrder.Columns["total"].HeaderText = "Total";

            dataGridView_purchaseOrder.Columns["delivery_date"].Visible=false;*/
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
                //cadena += " AND id_supplier = " + textBox_name.Text;
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
        private string buscarNombre(int id_supplier)
        {
            DataRow[] rows;
            if (controlSup == null) controlSup = new SupplierController();
            DataTable auxiliarLista = controlSup.getData();
            rows = auxiliarLista.Select("id_supplier = " + id_supplier);
            if (rows.Any()) auxiliarLista = rows.CopyToDataTable();
            else auxiliarLista.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            auxiliarLista.DefaultView.Sort = sortQuery;
            if (auxiliarLista.Rows.Count != 0) return auxiliarLista.Rows[0]["name"].ToString();
            else return "";
        }
        public void desarrolloBusqueda()
        {
            textBox_name.Text = textBox_name.Text.Trim();
            filter();
            dataGridView_purchaseOrder.Rows.Clear();
            for (int i = 0; i < purchaseOrderList.Rows.Count; i++)
            {
                int id_order = int.Parse(purchaseOrderList.Rows[i]["id_order"].ToString());
                int id_supplier = int.Parse(purchaseOrderList.Rows[i]["id_supplier"].ToString());
                string status = purchaseOrderList.Rows[i]["status"].ToString();
                string creation_date = DateTime.Parse(purchaseOrderList.Rows[i]["creation_date"].ToString()).ToShortDateString();
                string delivery_date = DateTime.Parse(purchaseOrderList.Rows[i]["delivery_date"].ToString()).ToShortDateString();
                double total = double.Parse(purchaseOrderList.Rows[i]["total"].ToString());
                string suppName = buscarNombre(id_supplier);
                dataGridView_purchaseOrder.Rows.Add(false, id_order, suppName, creation_date, delivery_date, total, status, id_supplier);
            }
            
        }
        private void button_search(object sender, EventArgs e)
        {
            desarrolloBusqueda();
        }

        private void button_add(object sender, EventArgs e)
        {
            Form purchaseDetail = new PurchaseOrderDetail(control,this);
            purchaseDetail.Show();
        }

        private void button_delete(object sender, EventArgs e)
        {
            int registros = dataGridView_purchaseOrder.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(dataGridView_purchaseOrder.Rows[i].Cells[0].Value) == true)
                {
                    string id_order = dataGridView_purchaseOrder.Rows[i].Cells[1].Value.ToString();
                    int prov = int.Parse(dataGridView_purchaseOrder.Rows[i].Cells[7].Value.ToString());
                    string status = dataGridView_purchaseOrder.Rows[i].Cells[6].Value.ToString();
                    if (string.Compare(status, "Borrador") != 0)
                    {
                        //solo se eliminará las ordenes en estado Borrador
                        dataGridView_purchaseOrder.Rows[i].Cells[0].Value = false;
                        MessageBox.Show("No se pudo eliminar la orden " + id_order + " porque no se encuentra en estado Borrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    DateTime creation_date = DateTime.Parse(dataGridView_purchaseOrder.Rows[i].Cells[3].Value.ToString());
                    DateTime delivery_date= DateTime.Parse(dataGridView_purchaseOrder.Rows[i].Cells[4].Value.ToString());
                    double total = (double) dataGridView_purchaseOrder.Rows[i].Cells[5].Value;
                    try
                    {
                        control.updateData(id_order,prov,"Inactivo", creation_date,delivery_date,total);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo eliminar la orden "+id_order+".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                }
            }
            desarrolloBusqueda();
        }

        private void editPurchaseOrder(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentPurchaseOrder = dataGridView_purchaseOrder.CurrentRow;
            Form purchaseDetail = new PurchaseOrderDetail(currentPurchaseOrder,control,this);
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
