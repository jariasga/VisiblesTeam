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
        UnitOfMeasurementController controlUnit;
        DataTable rawMaterialList;
        public RawMaterials()
        {
            InitializeComponent();
            control = new RawMaterialController();
            rawMaterialList = control.getData();
            desarrolloBusqueda();
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
        public string buscarNombre(string id_unit)
        {
            DataRow[] rows;
            if (controlUnit == null) controlUnit = new UnitOfMeasurementController();
            DataTable auxiliarLista = controlUnit.getData();
            rows = auxiliarLista.Select("id_unit = " + id_unit);
            if (rows.Any()) auxiliarLista = rows.CopyToDataTable();
            else auxiliarLista.Rows.Clear();
            string sortQuery = string.Format("id_unit");
            auxiliarLista.DefaultView.Sort = sortQuery;
            if (auxiliarLista.Rows.Count != 0) return auxiliarLista.Rows[0]["name"].ToString();
            else return "";
        }
        public void desarrolloBusqueda()
        {
            textBox_name.Text = textBox_name.Text.Trim();
            filter();
            dataGridView_rawMaterialsList.Rows.Clear();
            for (int i = 0; i < rawMaterialList.Rows.Count; i++)
            {
                int id_raw_material = int.Parse(rawMaterialList.Rows[i]["id_raw_material"].ToString());
                string name = rawMaterialList.Rows[i]["name"].ToString();
                string description = rawMaterialList.Rows[i]["description"].ToString();
                string id_unit = rawMaterialList.Rows[i]["unit"].ToString();
                string unit = buscarNombre(id_unit);
                string status =rawMaterialList.Rows[i]["status"].ToString();
                double average_price = double.Parse(rawMaterialList.Rows[i]["average_price"].ToString());
                dataGridView_rawMaterialsList.Rows.Add(id_raw_material,name,description,unit,status,average_price,id_unit,false);
            }
            dataGridView_rawMaterialsList.Sort(dataGridView_rawMaterialsList.Columns["id_raw_material"], System.ComponentModel.ListSortDirection.Ascending);

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
                if (Convert.ToBoolean(dataGridView_rawMaterialsList.Rows[i].Cells[7].Value) == true)
                {
                    string id = dataGridView_rawMaterialsList.Rows[i].Cells[0].Value.ToString();
                    string name = dataGridView_rawMaterialsList.Rows[i].Cells[1].Value.ToString();
                    string description = dataGridView_rawMaterialsList.Rows[i].Cells[2].Value.ToString();
                    string unit = dataGridView_rawMaterialsList.Rows[i].Cells[6].Value.ToString();
                    string averagePrice = dataGridView_rawMaterialsList.Rows[i].Cells[5].Value.ToString();
                    try
                    {
                        control.updateData(id, name, description, unit, "Inactivo", double.Parse(averagePrice));
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("No se pudo actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    
                }
            }
            desarrolloBusqueda();
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
            dialog.Title = "Open Raw Materials File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK) {
                int resultado = control.massiveUpload(dialog.FileName);
                if (resultado == 1)
                {
                    MessageBox.Show("No se pudo cargar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (resultado == 2)
                {
                    MessageBox.Show("No se realizó la carga porque estas materias primas ya existen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else MessageBox.Show("Se realizó la carga masiva de manera exitosa", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox_id.Text = "";
            textBox_name.Text = "";
            comboBox_status.Text = "";
            desarrolloBusqueda();
        }
    }
}
