using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Purchases;

namespace InkaArt.Interface.Purchases
{
    public partial class AddSupply : Form
    {
        RawMaterialController control;
        Form supplierView;
        public AddSupply()
        {
            InitializeComponent();
            control = new RawMaterialController();
            DataTable rawMaterialList = control.getData();
            dataGridView_supplies.DataSource = rawMaterialList;

            dataGridView_supplies.Columns["idRawMaterial"].HeaderText = "ID";
            dataGridView_supplies.Columns["name"].HeaderText = "Nombre";
            dataGridView_supplies.Columns["unit"].HeaderText = "Unidad";
            dataGridView_supplies.Columns["unit"].Visible = false;
            dataGridView_supplies.Columns["status"].HeaderText = "Estado";
            dataGridView_supplies.Columns["status"].Visible = false;
            dataGridView_supplies.Columns["description"].HeaderText = "Descripción";
            dataGridView_supplies.Columns["description"].Visible = false;
            dataGridView_supplies.Columns["averagePrice"].HeaderText = "Precio Promedio";
            dataGridView_supplies.Columns["averagePrice"].Visible = false;
        }
        public AddSupply(Form viewSupplier)
        {
            InitializeComponent();
            control = new RawMaterialController();
            DataTable rawMaterialList = control.getData();
            dataGridView_supplies.DataSource = rawMaterialList;

            dataGridView_supplies.Columns["idRawMaterial"].HeaderText = "ID";
            dataGridView_supplies.Columns["name"].HeaderText = "Nombre";
            dataGridView_supplies.Columns["unit"].HeaderText = "Unidad";
            dataGridView_supplies.Columns["unit"].Visible = false;
            dataGridView_supplies.Columns["status"].HeaderText = "Estado";
            dataGridView_supplies.Columns["status"].Visible = false;
            dataGridView_supplies.Columns["description"].HeaderText = "Descripción";
            dataGridView_supplies.Columns["description"].Visible = false;
            dataGridView_supplies.Columns["averagePrice"].HeaderText = "Precio Promedio";
            dataGridView_supplies.Columns["averagePrice"].Visible = false;

            supplierView = viewSupplier;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_return(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_add(object sender, EventArgs e)
        {
            int totalSupplies=dataGridView_supplies.RowCount;
            for(int i = 1; i < totalSupplies; i++)
            {
                if ((bool)dataGridView_supplies.Rows[i].Cells[0].Value == true)
                {
                }
            }
            this.Close();
        }

        private void button_create(object sender, EventArgs e)
        {
            Form newRawMaterialWindow = new RawMaterialDetail(control);
            newRawMaterialWindow.Show();
        }

        private void button_search(object sender, EventArgs e)
        {

        }
    }
}