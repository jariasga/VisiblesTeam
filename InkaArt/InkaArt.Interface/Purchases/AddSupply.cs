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
        RawMaterial_SupplierController control_rs;
        DataTable rawMaterialList;
        Form supplierView;
        int idSupplier;
        public AddSupply()
        {
            InitializeComponent();
            control = new RawMaterialController();
            rawMaterialList = control.getData();
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
        public AddSupply(Form viewSupplier,RawMaterial_SupplierController controlForm,string idSupp)
        {
            InitializeComponent();
            control = new RawMaterialController();
            rawMaterialList = control.getData();
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
            control_rs = controlForm;
            idSupplier = int.Parse(idSupp);
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
            for(int i = 0; i < totalSupplies; i++)
            {
                if ((bool)dataGridView_supplies.Rows[i].Cells[0].Value == true)
                {
                    //control_rs.insertRM_Sup(dataGridView_supplies.Rows[i].Cells[1].Value.ToString(),idSupplier,"0");
                    dataGridView_supplies.Rows[i].Cells[0].Value = false;
                }
            }
            this.Close();
        }

        private void button_create(object sender, EventArgs e)
        {
            //Form newRawMaterialWindow = new RawMaterialDetail(control);
            //newRawMaterialWindow.Show();
        }

        private void filter()
        {
            DataRow[] rows;
            rawMaterialList = control.getData();
            string cadena = "";
            if (textBox_idFilter.Text.Length > 0)
            {
                cadena = " AND idRawMaterial = " + textBox_idFilter.Text;
            }
            rows = rawMaterialList.Select("name LIKE '%" + textBox_nameFilter.Text + "%'" + cadena);
            
            if (rows.Any()) rawMaterialList = rows.CopyToDataTable();
            else rawMaterialList.Rows.Clear();
            string sortQuery = string.Format("idRawMaterial");
            rawMaterialList.DefaultView.Sort = sortQuery;
        }
        private void button_search(object sender, EventArgs e)
        {
            textBox_nameFilter.Text = textBox_nameFilter.Text.Trim();
            filter();
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

        private void validating_id(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_idFilter.Text.ToCharArray();
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
            textBox_idFilter.Text = actualdata;
        }
    }
}