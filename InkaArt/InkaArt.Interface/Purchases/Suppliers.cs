using System;
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
        public Suppliers()
        {
            InitializeComponent();
            control = new SupplierController();
            DataTable suppliersList = control.getData();
            dataGridView_suppliersList.DataSource = suppliersList;

            dataGridView_suppliersList.Columns["id_supplier"].HeaderText = "ID";
            dataGridView_suppliersList.Columns["name"].HeaderText = "Nombre";
            dataGridView_suppliersList.Columns["ruc"].HeaderText = "RUC";
            dataGridView_suppliersList.Columns["contact"].HeaderText = "Contacto";
            dataGridView_suppliersList.Columns["contact"].Visible = false;
            dataGridView_suppliersList.Columns["telephone"].HeaderText = "Teléfono";
            dataGridView_suppliersList.Columns["telephone"].Visible = false;
            dataGridView_suppliersList.Columns["email"].HeaderText = "Correo";
            dataGridView_suppliersList.Columns["address"].Visible = false;
            dataGridView_suppliersList.Columns["address"].HeaderText = "Dirección";
            dataGridView_suppliersList.Columns["priority"].HeaderText = "Prioridad";
            dataGridView_suppliersList.Columns["status"].HeaderText = "Estado";
             }
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_add(object sender, EventArgs e)
        {
            Form supplierDet = new SupplierDetail(control);
            supplierDet.Show();
        }

        private void button_delete(object sender, EventArgs e)
        {
            int registros=dataGridView_suppliersList.Rows.Count;
            for(int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(dataGridView_suppliersList.Rows[i].Cells[0].Value)==true)
                {
                    string idSupplier = dataGridView_suppliersList.Rows[i].Cells[1].Value.ToString();
                    dataGridView_suppliersList.Rows[i].Cells[7].Value = "Inactivo";
                    string status = dataGridView_suppliersList.Rows[i].Cells[7].Value.ToString();
                    control.updateStatus(idSupplier,status);
                }
            }
        }

        private void editCurrentSupplier(object sender, DataGridViewCellEventArgs e)
        {
            Form supplierDet = new SupplierDetail(dataGridView_suppliersList.CurrentRow,control);
            supplierDet.Show();
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

        private void validating_ruc(object sender, EventArgs e)
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

        private void button_search(object sender, EventArgs e)
        {
            if (true)
            {
                //buscar
            }
        }
    }
}
