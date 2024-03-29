﻿using System;
using System.Collections.Generic;
using System.Data;
using InkaArt.Business.Purchases;
using System.Windows.Forms;
using System.Linq;

namespace InkaArt.Interface.Purchases
{
    public partial class Suppliers : Form
    {
        SupplierController control;
        DataTable suppliersList;
        public Suppliers()
        {
            InitializeComponent();
            control = new SupplierController();
            suppliersList = control.getData();
            string sortQuery = string.Format("id_supplier");
            suppliersList.DefaultView.Sort = sortQuery;
            dataGridView_suppliersList.DataSource = suppliersList;
            dataGridView_suppliersList.Columns["id_supplier"].HeaderText = "ID";
            dataGridView_suppliersList.Columns["id_supplier"].ReadOnly = true;
            dataGridView_suppliersList.Columns["name"].HeaderText = "Nombre";
            dataGridView_suppliersList.Columns["name"].ReadOnly = true;
            dataGridView_suppliersList.Columns["ruc"].HeaderText = "RUC";

            dataGridView_suppliersList.Columns["ruc"].ReadOnly = true;
            dataGridView_suppliersList.Columns["contact"].HeaderText = "Contacto";
            dataGridView_suppliersList.Columns["contact"].Visible = false;
            dataGridView_suppliersList.Columns["telephone"].HeaderText = "Teléfono";
            dataGridView_suppliersList.Columns["telephone"].Visible = false;
            dataGridView_suppliersList.Columns["email"].HeaderText = "Correo";
            dataGridView_suppliersList.Columns["address"].Visible = false;
            dataGridView_suppliersList.Columns["address"].HeaderText = "Dirección";
            dataGridView_suppliersList.Columns["address"].ReadOnly = true;
            dataGridView_suppliersList.Columns["priority"].HeaderText = "Prioridad";
            dataGridView_suppliersList.Columns["priority"].ReadOnly = true;
            dataGridView_suppliersList.Columns["status"].HeaderText = "Estado";

            dataGridView_suppliersList.Columns["status"].ReadOnly = true;
        }
        

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void button_add(object sender, EventArgs e)
        {
            Form supplierDet = new SupplierDetail(control,this);
            supplierDet.Show();
        }
        private void cambiarTodasLasMateriasAInactivo(string idSupplier)
        {
            //COMPLETARRRRR!!
            DataRow[] rows;
            RawMaterial_SupplierController control_rm=new RawMaterial_SupplierController();
            DataTable tablaAuxiliar = control_rm.getData();
            rows = tablaAuxiliar.Select("id_supplier = " + idSupplier);
            if (rows.Any()) tablaAuxiliar = rows.CopyToDataTable();
            else tablaAuxiliar.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            tablaAuxiliar.DefaultView.Sort = sortQuery;
            int numero = tablaAuxiliar.Rows.Count;
            for(int i = 0; i < numero; i++)
            {
                string idMat=tablaAuxiliar.Rows[i]["id_raw_material"].ToString();
                string idRMSup = tablaAuxiliar.Rows[i]["id_rawmaterial_supplier"].ToString();
                string price = tablaAuxiliar.Rows[i]["price"].ToString();
                string status = tablaAuxiliar.Rows[i]["status"].ToString();
                if (string.Compare(status, "Inactivo") == 0) continue;
                try
                {
                    control_rm.UpdateRM_Sup(idRMSup, idMat, idSupplier, price, "Inactivo");
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        public void button_delete(object sender, EventArgs e)
        {
            int registros=dataGridView_suppliersList.Rows.Count;
            for(int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(dataGridView_suppliersList.Rows[i].Cells[0].Value)==true)
                {
                    string idSupplier = dataGridView_suppliersList.Rows[i].Cells[1].Value.ToString();
                    string name = dataGridView_suppliersList.Rows[i].Cells[2].Value.ToString();
                    string ruc = dataGridView_suppliersList.Rows[i].Cells[3].Value.ToString();
                    string address = dataGridView_suppliersList.Rows[i].Cells[8].Value.ToString();
                    string priority = dataGridView_suppliersList.Rows[i].Cells[9].Value.ToString();
                    string contactName = dataGridView_suppliersList.Rows[i].Cells[4].Value.ToString();
                    string email = dataGridView_suppliersList.Rows[i].Cells[6].Value.ToString();
                    string telephone = dataGridView_suppliersList.Rows[i].Cells[5].Value.ToString();
                    try {
                        control.updateData(idSupplier, name, ruc, contactName, int.Parse(telephone), email, address, int.Parse(priority), "Inactivo");
                        cambiarTodasLasMateriasAInactivo(idSupplier);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se pudo eliminar al proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    
                }
            }
            desarrolloBusqueda();
        }

        public void editCurrentSupplier(object sender, DataGridViewCellEventArgs e)
        {
            Form supplierDet = new SupplierDetail(dataGridView_suppliersList.CurrentRow,control,this);
            supplierDet.Show();
        }

        public void validating_id(object sender, EventArgs e)
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

        public void validating_ruc(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_ruc.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el ruc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_ruc.Text = actualdata;
        }
        public void filter()
        {
            DataRow[] rows;
            suppliersList = control.getData();
            string cadena = "";
            if (textBox_id.Text.Length > 0)
            {
                cadena = " AND id_supplier = " + textBox_id.Text;
            }
            if (String.Compare(comboBox_status.Text, "Activo") == 0)
            {
                rows = suppliersList.Select("name LIKE '%" + textBox_supplier.Text + "%' AND address LIKE '%" + textBox_address.Text + "%' AND ruc LIKE '%" + textBox_ruc.Text + "%' AND status LIKE '" + comboBox_status.Text + "'" + cadena);
            }
            else
            {
                rows = suppliersList.Select("name LIKE '%" + textBox_supplier.Text + "%' AND address LIKE '%" + textBox_address.Text + "%' AND ruc LIKE '%"+textBox_ruc.Text + "%' AND status LIKE '%" + comboBox_status.Text + "%'" + cadena);
            }
            if (rows.Any()) suppliersList = rows.CopyToDataTable();
            else suppliersList.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            suppliersList.DefaultView.Sort = sortQuery;
        }
        public void desarrolloBusqueda()
        {
            textBox_address.Text = textBox_address.Text.Trim();
            textBox_supplier.Text = textBox_supplier.Text.Trim();
            filter();
            dataGridView_suppliersList.DataSource = suppliersList;

            dataGridView_suppliersList.Columns["id_supplier"].HeaderText = "ID";
            dataGridView_suppliersList.Columns["id_supplier"].ReadOnly = true;
            dataGridView_suppliersList.Columns["name"].HeaderText = "Nombre";
            dataGridView_suppliersList.Columns["name"].ReadOnly = true;
            dataGridView_suppliersList.Columns["ruc"].HeaderText = "RUC";
            dataGridView_suppliersList.Columns["ruc"].ReadOnly = true;
            dataGridView_suppliersList.Columns["contact"].HeaderText = "Contacto";
            dataGridView_suppliersList.Columns["contact"].Visible = false;
            dataGridView_suppliersList.Columns["telephone"].HeaderText = "Teléfono";
            dataGridView_suppliersList.Columns["telephone"].Visible = false;
            dataGridView_suppliersList.Columns["email"].HeaderText = "Correo";
            dataGridView_suppliersList.Columns["email"].ReadOnly = true;
            dataGridView_suppliersList.Columns["address"].Visible = false;
            dataGridView_suppliersList.Columns["address"].HeaderText = "Dirección";
            dataGridView_suppliersList.Columns["priority"].HeaderText = "Prioridad";
            dataGridView_suppliersList.Columns["priority"].ReadOnly = true;
            dataGridView_suppliersList.Columns["status"].HeaderText = "Estado";
            dataGridView_suppliersList.Columns["status"].ReadOnly = true;
        }
        public void button_search(object sender, EventArgs e)
        {
            desarrolloBusqueda();
        }

        private void cargaMasiva(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Seleccione el archivo de proveedores";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK) {
                int resultado1 = control.massiveUpload(dialog.FileName);
                if (resultado1 == 1)
                {
                    MessageBox.Show("No se pudo cargar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (resultado1 == 2)
                {
                    MessageBox.Show("No se realizó la carga porque estos proveedores ya existen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                else MessageBox.Show("Se realizó la carga masiva de proveedores de manera exitosa", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            OpenFileDialog dialog2 = new OpenFileDialog();
            dialog2.Title = "Seleccione el archivo con las materias primas ofrecidas";
            dialog2.Filter = "CSV files|*.csv";
            if (dialog2.ShowDialog() == DialogResult.OK)
            {
                RawMaterial_SupplierController control_rm=new RawMaterial_SupplierController();
                int resultado2 = control_rm.massiveUpload(dialog2.FileName);
                if (resultado2 == 1)
                {
                    MessageBox.Show("No se pudo cargar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (resultado2 == 2)
                {
                    MessageBox.Show("No se realizó la carga porque los registros ya existen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else MessageBox.Show("Se realizó la carga masiva de manera exitosa", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox_id.Text = "";
            textBox_ruc.Text = "";
            textBox_supplier.Text = "";
            textBox_address.Text = "";
            comboBox_status.Text = "";
            desarrolloBusqueda();
        }
    }
}
