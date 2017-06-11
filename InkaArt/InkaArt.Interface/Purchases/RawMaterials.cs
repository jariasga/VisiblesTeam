using System;
using System.Data;
using System.Linq;
using InkaArt.Business.Purchases;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class RawMaterials : Form
    {
        RawMaterialController control;
        DataTable rawMaterialList;
        public RawMaterials()
        {
            InitializeComponent();
            control = new RawMaterialController();
            rawMaterialList = control.getData();
            dataGridView_rawMaterialsList.DataSource = rawMaterialList;

            dataGridView_rawMaterialsList.Columns["id_raw_material"].HeaderText = "ID";
            dataGridView_rawMaterialsList.Columns["name"].HeaderText = "Nombre";
            dataGridView_rawMaterialsList.Columns["unit"].HeaderText = "Unidad";
            dataGridView_rawMaterialsList.Columns["status"].HeaderText = "Estado";
            dataGridView_rawMaterialsList.Columns["description"].HeaderText = "Descripción";
            dataGridView_rawMaterialsList.Columns["average_price"].HeaderText = "Precio Promedio";
            dataGridView_rawMaterialsList.Columns["average_price"].Visible = false;
            
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
        public void desarrolloBusqueda()
        {
            textBox_name.Text = textBox_name.Text.Trim();
            filter();
            dataGridView_rawMaterialsList.DataSource = rawMaterialList;

            dataGridView_rawMaterialsList.Columns["id_raw_material"].HeaderText = "ID";
            dataGridView_rawMaterialsList.Columns["name"].HeaderText = "Nombre";
            dataGridView_rawMaterialsList.Columns["unit"].HeaderText = "Unidad";
            dataGridView_rawMaterialsList.Columns["status"].HeaderText = "Estado";
            dataGridView_rawMaterialsList.Columns["description"].HeaderText = "Descripción";
            dataGridView_rawMaterialsList.Columns["average_price"].HeaderText = "Precio Promedio";
            dataGridView_rawMaterialsList.Columns["average_price"].Visible = false;
        }
        public void button_search(object sender, EventArgs e)
        {
            desarrolloBusqueda();
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
                    string description = dataGridView_rawMaterialsList.Rows[i].Cells[3].Value.ToString();
                    string averagePrice = dataGridView_rawMaterialsList.Rows[i].Cells[6].Value.ToString();
                    try
                    {
                        control.updateData(id, name, description, unit, "Inactivo", double.Parse(averagePrice));
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("No se pudo actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dataGridView_rawMaterialsList.Rows[i].Cells[0].Value = false;
                    desarrolloBusqueda();
                }
            }
        }

        private void button_create(object sender, EventArgs e)
        {
            Form new_raw_material = new RawMaterialDetail(control,this);
            new_raw_material.Show();
        }

        private void editRawMaterialDetail(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRawMaterial = dataGridView_rawMaterialsList.CurrentRow;
            Form new_raw_material = new RawMaterialDetail(currentRawMaterial,control,this);
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
        public void filter()
        {
            DataRow[] rows;
            rawMaterialList = control.getData();
            string cadena = "";
            if (textBox_id.Text.Length > 0)
            {
                cadena = " AND id_raw_material = "+textBox_id.Text;
            }
            if (String.Compare(comboBox_status.Text, "Activo") == 0)
            {
                rows = rawMaterialList.Select("name LIKE '%" + textBox_name.Text + "%' AND status LIKE '" + comboBox_status.Text + "'"+cadena);
            }
            else
            {
                rows = rawMaterialList.Select("name LIKE '%" + textBox_name.Text + "%' AND status LIKE '%" + comboBox_status.Text + "%'"+cadena);
            }
            if (rows.Any()) rawMaterialList = rows.CopyToDataTable();
            else rawMaterialList.Rows.Clear();
            string sortQuery = string.Format("id_raw_material");
            rawMaterialList.DefaultView.Sort = sortQuery;
        }

        private void button_cargamasivaclic(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Users File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
                control.massiveUpload(dialog.FileName);
            textBox_id.Text = "";
            textBox_name.Text = "";
            comboBox_status.Text = "";
            desarrolloBusqueda();
        }
    }
}
