using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Business.Purchases;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class RawMaterials : Form
    {
        RawMaterialController control;
        public RawMaterials()
        {
            InitializeComponent();
            control = new RawMaterialController();
            DataTable rawMaterialList = control.getData();
            dataGridView_rawMaterialsList.DataSource = rawMaterialList;

            dataGridView_rawMaterialsList.Columns["idRawMaterial"].HeaderText = "ID";
            dataGridView_rawMaterialsList.Columns["name"].HeaderText = "Nombre";
            dataGridView_rawMaterialsList.Columns["unit"].HeaderText = "Unidad";
            dataGridView_rawMaterialsList.Columns["status"].HeaderText = "Estado";
            dataGridView_rawMaterialsList.Columns["description"].HeaderText = "Descripción";
            dataGridView_rawMaterialsList.Columns["averagePrice"].HeaderText = "Precio Promedio";
            dataGridView_rawMaterialsList.Columns["averagePrice"].Visible = false;
        }
        private void verifying_ids()
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
        private void button_search(object sender, EventArgs e)
        {
            textBox_name.Text = textBox_name.Text.Trim();
            if (true)
            {
                //codigo para hacer las busquedas
            }
            
        }

        private void button_delete(object sender, EventArgs e)
        {
            int registros = dataGridView_rawMaterialsList.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(dataGridView_rawMaterialsList.Rows[i].Cells[0].Value) == true)
                {
                    string id = dataGridView_rawMaterialsList.Rows[i].Cells[1].Value.ToString();
                    string name = dataGridView_rawMaterialsList.Rows[i].Cells[2].Value.ToString();
                    string unit = dataGridView_rawMaterialsList.Rows[i].Cells[4].Value.ToString();
                    dataGridView_rawMaterialsList.Rows[i].Cells[5].Value = "Inactivo";
                    string status = dataGridView_rawMaterialsList.Rows[i].Cells[5].Value.ToString();
                    string description = dataGridView_rawMaterialsList.Rows[i].Cells[3].Value.ToString();
                    string averagePrice = dataGridView_rawMaterialsList.Rows[i].Cells[6].Value.ToString();
                    control.updateData(id, name, description, unit, status, double.Parse(averagePrice));
                }
            }
        }

        private void button_create(object sender, EventArgs e)
        {
            Form new_raw_material = new RawMaterialDetail(control);
            new_raw_material.Show();
        }

        private void editRawMaterialDetail(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRawMaterial = dataGridView_rawMaterialsList.CurrentRow;
            Form new_raw_material = new RawMaterialDetail(currentRawMaterial,control);
            new_raw_material.Show();
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
