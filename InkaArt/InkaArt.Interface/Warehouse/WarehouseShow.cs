using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Warehouse;
using InkaArt.Business.Purchases;

namespace InkaArt.Interface.Warehouse
{
    public partial class WarehouseShow : Form
    {
        int warehouseId;
        bool first;
        WarehouseCrud warehouseController;
        string idWarehouse;

        public WarehouseShow(string id)
        {
            InitializeComponent();
            warehouseId = int.Parse(id);
            first = true;
            warehouseController = new WarehouseCrud();
            idWarehouse = id;
            RawMaterialController controlRM = new RawMaterialController();
            DataTable rmList = controlRM.getData();
            for (int i = 0; i< rmList.Rows.Count; i++)
            {
                comboBox_RM.Items.Add(rmList.Rows[i]["name"]);
            }
            fillGridRawMaterial();
        }

        public void fillGridRawMaterial()
        {
            RawMaterialWarehouseController control = new RawMaterialWarehouseController();
            RawMaterialController controlRM = new RawMaterialController();

            DataTable rmWarehouseList = control.getData();
            DataTable rmList = controlRM.getData();

            string name = "";
            dataGridView_RawMaterial.Rows.Clear();

            for (int i = 0; i < rmWarehouseList.Rows.Count; i++)
            {
                if (string.Compare(rmWarehouseList.Rows[i]["idWarehouse"].ToString(), idWarehouse) == 0 &&
                    string.Compare(rmWarehouseList.Rows[i]["state"].ToString(), "Activo") == 0) {
                    for (int j = 0; j < rmList.Rows.Count; j++)
                    {
                        if (string.Compare(rmWarehouseList.Rows[i]["idRawMaterial"].ToString(), rmList.Rows[j]["idRawMaterial"].ToString()) == 0)
                        {
                            name = rmList.Rows[j]["name"].ToString();
                            break;
                        }
                    }
                    dataGridView_RawMaterial.Rows.Add(rmWarehouseList.Rows[i]["idRawMaterial"],
                        name,
                        rmWarehouseList.Rows[i]["currentStock"],
                        rmWarehouseList.Rows[i]["virtualStock"],
                        rmWarehouseList.Rows[i]["minimunStock"],
                        rmWarehouseList.Rows[i]["maximunStock"],
                        rmWarehouseList.Rows[i]["idRawMaterialWarehouse"]);
                }
            }
        }

        private void WarehouseShow_Load(object sender, EventArgs e)
        {
            DataTable warehouseObject = warehouseController.GetWarehouses(warehouseId.ToString());
            populateFields(warehouseObject);
        }

        private void populateFields(DataTable warehouseObject)
        {
            foreach (DataRow row in warehouseObject.Rows)
            {
                textBox_name.Text = row["name"].ToString();
                textBox_description.Text = row["description"].ToString();
                textBox_address.Text = row["address"].ToString();
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (first)
            {
                enableFields();
                button_edit.Text = "🖫 Guardar";
            }
            else
            {
                int response = warehouseController.updateWarehouse(warehouseId.ToString(), textBox_name.Text, textBox_description.Text, textBox_address.Text);
                if (response >= 0)
                {
                    MessageBox.Show(this, "El almacén ha sido actualizado correctamente.", "Editar almacén", MessageBoxButtons.OK);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void enableFields()
        {
            first = false;
            textBox_name.Enabled = true;
            textBox_description.Enabled = true;
            textBox_address.Enabled = true;
            comboBox_RM.Enabled = true;
        }

        private void buttonAdd_RawMaterial_Click(object sender, EventArgs e)
        {
            RawMaterialController controlRM = new RawMaterialController();
            DataTable rmList = controlRM.getData();

            RawMaterialWarehouseController control = new RawMaterialWarehouseController();
            DataTable rmWarehouseList = control.getData();

            string name = comboBox_RM.SelectedItem.ToString();
            string idRM = "";
            for (int i = 0; i < rmList.Rows.Count; i++)
            {
                if (string.Compare(rmList.Rows[i]["name"].ToString(), name) == 0)
                {
                    idRM = rmList.Rows[i]["idRawMaterial"].ToString();
                    break;
                }
            }

            control.insertData(idWarehouse, idRM, name, numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString());
            fillGridRawMaterial();
        }

        private void buttonAdd_Product_Click(object sender, EventArgs e)
        {

        }
    }
}
