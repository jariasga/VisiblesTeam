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
using InkaArt.Business.Production;
using System.Diagnostics;

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
            comboBox_RM.SelectedIndex = 1;
            FinalProductController controlP = new FinalProductController();
            DataTable pList = controlP.getData();
            for (int i = 0; i < pList.Rows.Count; i++)
                comboBox_Producto.Items.Add(pList.Rows[i]["name"]);
            comboBox_Producto.SelectedIndex = 1;
            fillGridRawMaterial();
            fillGridProduct();
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
                        if (string.Compare(rmWarehouseList.Rows[i]["idRawMaterial"].ToString(), rmList.Rows[j]["id_raw_material"].ToString()) == 0)
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
                        rmWarehouseList.Rows[i]["maximunStock"],false,
                        rmWarehouseList.Rows[i]["idRawMaterialWarehouse"]);
                }
            }
        }

        public void fillGridProduct()
        {
            ProductWarehouseController control = new ProductWarehouseController();
            FinalProductController controlP = new FinalProductController();

            DataTable pWarehouseList = control.getData();
            DataTable pList = controlP.getData();

            string name = "";
            dataGridView_Product.Rows.Clear();

            for(int i = 0; i < pWarehouseList.Rows.Count; i++)
            {
                if (string.Compare(pWarehouseList.Rows[i]["idWarehouse"].ToString(), idWarehouse) == 0 &&
                    string.Compare(pWarehouseList.Rows[i]["state"].ToString(), "Activo") == 0)
                {
                    for (int j = 0; j < pList.Rows.Count; j++)
                    {
                        if (string.Compare(pWarehouseList.Rows[i]["idProduct"].ToString(), pList.Rows[j]["idProduct"].ToString()) == 0)
                        {
                            name = pList.Rows[j]["name"].ToString();
                            break;
                        }
                    }
                    dataGridView_Product.Rows.Add(pWarehouseList.Rows[i]["idProduct"],
                        name,
                        pWarehouseList.Rows[i]["currentStock"],
                        pWarehouseList.Rows[i]["virtualStock"],
                        pWarehouseList.Rows[i]["minimunStock"],
                        pWarehouseList.Rows[i]["maximunStock"], false,
                        pWarehouseList.Rows[i]["idProductWarehouse"]);
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
            comboBox_Producto.Enabled = true;
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
                    idRM = rmList.Rows[i]["id_raw_material"].ToString();
                    break;
                }
            }
            if (int.Parse(numericUpDown1.Value.ToString()) != 0 && int.Parse(numericUpDown2.Value.ToString()) != 0)
            {
                control.insertData(idWarehouse, idRM, name, numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString());
                fillGridRawMaterial();
            }else
            {
                MessageBox.Show("El numero debe ser mayor a cero.");
            }
        }

        private void buttonAdd_Product_Click(object sender, EventArgs e)
        {
            FinalProductController controlP = new FinalProductController();
            DataTable pList = controlP.getData();

            ProductWarehouseController control = new ProductWarehouseController();
            DataTable pWarehouseList = control.getData();

            string name = comboBox_Producto.SelectedItem.ToString();
            string idP = "";

            for (int i = 0; i < pList.Rows.Count; i++)
            {
                if (string.Compare(pList.Rows[i]["name"].ToString(), name) == 0)
                {
                    idP= pList.Rows[i]["idProduct"].ToString();
                    break;
                }
            }
            if (int.Parse(numericUpDown3.Value.ToString()) != 0 && int.Parse(numericUpDown4.Value.ToString()) != 0)
            {
                control.insertData(idWarehouse, idP, numericUpDown4.Value.ToString(), numericUpDown3.Value.ToString());
                fillGridProduct();
            }
            else
            {
                MessageBox.Show("El numero debe ser mayor a cero.");
            }
        }

        private void buttonDelete_RawMaterial_Click(object sender, EventArgs e)
        {
            RawMaterialWarehouseController rwWarehouseController = new RawMaterialWarehouseController();

            int registros = dataGridView_RawMaterial.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                string ide = dataGridView_RawMaterial.Rows[i].Cells[6].Value.ToString();
                string name = dataGridView_RawMaterial.Rows[i].Cells[1].Value.ToString();
                if (Convert.ToBoolean(dataGridView_RawMaterial.Rows[i].Cells[6].Value) == true)
                {
                    string id = dataGridView_RawMaterial.Rows[i].Cells[7].Value.ToString();
                    //Debug.WriteLine(id);
                    rwWarehouseController.deleteData(id);
                }
            }
            //updateDataGrid();
            fillGridRawMaterial();
            MessageBox.Show("Materias Primas eliminados", "Eliminar Materia Prima.", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void dataGridView_RawMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDelete_Product_Click(object sender, EventArgs e)
        {
            ProductWarehouseController pWarehouseController = new ProductWarehouseController();

            int registros = dataGridView_Product.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                string ide = dataGridView_Product.Rows[i].Cells[6].Value.ToString();
                string name = dataGridView_Product.Rows[i].Cells[1].Value.ToString();
                if (Convert.ToBoolean(dataGridView_Product.Rows[i].Cells[6].Value) == true)
                {
                    string id = dataGridView_Product.Rows[i].Cells[7].Value.ToString();
                    //Debug.WriteLine(id);
                    pWarehouseController.deleteData(id);
                }
            }
            //updateDataGrid();
            fillGridProduct();
            MessageBox.Show("Productos eliminados", "Eliminar Producto.", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

        }
    }
}
