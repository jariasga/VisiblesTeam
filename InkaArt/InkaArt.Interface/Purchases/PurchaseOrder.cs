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
            dataGridView_purchaseOrder.Sort(dataGridView_purchaseOrder.Columns["id_order"], System.ComponentModel.ListSortDirection.Ascending);
        }
        private string buscarIdsProveedores(string nombre)
        {
            string lista = "";
            DataRow[] rows;
            if (controlSup == null) controlSup = new SupplierController();
            DataTable auxiliarLista = controlSup.getData();
            rows = auxiliarLista.Select("name LIKE '%" + nombre+ "%'");
            if (rows.Any()) auxiliarLista = rows.CopyToDataTable();
            else auxiliarLista.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            auxiliarLista.DefaultView.Sort = sortQuery;
            for (int i = 0; i < auxiliarLista.Rows.Count; i++)
                {
                    if (lista.Length > 0) lista += ", ";
                    lista += auxiliarLista.Rows[i]["id_supplier"].ToString();
                }
            
            return lista;
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
                string lista = buscarIdsProveedores(textBox_name.Text);
                cadena += " AND id_supplier IN (" + lista+")";
            }
            if (dateTimePicker_creation.Text.Length > 0 && checkBox_dateInclude.Checked)
            {
                string creation_date = DateTime.Parse(dateTimePicker_creation.Text).ToString("dd/MM/yyyy");
                string end_date = DateTime.Parse(dateTimePicker_creationEnd.Text).ToString("dd/MM/yyyy");
                cadena += " AND creation_date >= '"+creation_date+ "' AND creation_date<= '" + end_date + "'";
            }
            rows = purchaseOrderList.Select("status LIKE '%" + comboBox_status.Text + "%'" + cadena);
            
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
                dataGridView_purchaseOrder.Rows.Add(id_order, suppName, creation_date, delivery_date, total, status, id_supplier, false);
            }
            
        }
        private void button_search(object sender, EventArgs e)
        {
            if(checkBox_dateInclude.Checked && dateTimePicker_creationEnd.Value < dateTimePicker_creation.Value)
            {
                MessageBox.Show("La fecha fin debe ser mayor o igual a la de inicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                if (Convert.ToBoolean(dataGridView_purchaseOrder.Rows[i].Cells[7].Value) == true)
                {
                    string id_order = dataGridView_purchaseOrder.Rows[i].Cells[0].Value.ToString();
                    int prov = int.Parse(dataGridView_purchaseOrder.Rows[i].Cells[6].Value.ToString());
                    string status = dataGridView_purchaseOrder.Rows[i].Cells[5].Value.ToString();
                    if (string.Compare(status, "Borrador") != 0)
                    {
                        //solo se eliminará las ordenes en estado Borrador
                        dataGridView_purchaseOrder.Rows[i].Cells[7].Value = false;
                        MessageBox.Show("No se pudo eliminar la orden " + id_order + " porque no se encuentra en estado Borrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    DateTime creation_date = DateTime.Parse(dataGridView_purchaseOrder.Rows[i].Cells[2].Value.ToString());
                    DateTime delivery_date= DateTime.Parse(dataGridView_purchaseOrder.Rows[i].Cells[3].Value.ToString());
                    double total = (double) dataGridView_purchaseOrder.Rows[i].Cells[4].Value;
                    try
                    {
                        control.updateData(id_order,prov,"Eliminado", creation_date,delivery_date,total);
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

        private void activarCheckbox(object sender, EventArgs e)
        {
            checkBox_dateInclude.Checked = true;
        }
    }
}
