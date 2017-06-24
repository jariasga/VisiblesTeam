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
                if(rmList.Rows[i]["status"].ToString()=="Activo")
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
                    MessageBox.Show(this, "El almacén ha sido actualizado correctamente.", "Editar almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = true;
        }

        private void buttonAdd_RawMaterial_Click(object sender, EventArgs e)
        {
            RawMaterialController controlRM = new RawMaterialController();
            DataTable rmList = controlRM.getData();

            RawMaterialWarehouseController control = new RawMaterialWarehouseController();
            DataTable rmWarehouseList = control.getData();

            

            string name = comboBox_RM.SelectedItem.ToString();
            string idRM = "";
            //validar que no esté en la lista
            int valido = 0;
            for (int i = 0; i < dataGridView_RawMaterial.Rows.Count; i++)
                if (dataGridView_RawMaterial.Rows[i].Cells[1].Value.ToString() == name)
                    valido = 1;

            if (valido == 0)
            {

                for (int i = 0; i < rmList.Rows.Count; i++)
                {
                    if (string.Compare(rmList.Rows[i]["name"].ToString(), name) == 0)
                    {
                        idRM = rmList.Rows[i]["id_raw_material"].ToString();
                        break;
                    }
                }
                int min, max;
                min = max = 0;
                if (int.TryParse(numericUpDown1.Value.ToString(), out min) && int.TryParse(numericUpDown2.Value.ToString(), out max))
                {
                    min = int.Parse(numericUpDown1.Value.ToString());
                    max = int.Parse(numericUpDown2.Value.ToString());

                    if (min != 0 && max != 0)
                    {
                        if (max > min)
                        {
                            control.insertData(idWarehouse, idRM, name, numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString());
                            MessageBox.Show("Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fillGridRawMaterial();
                        }
                        else
                            MessageBox.Show("El valor máximo debe ser mayor al mínimo, por favor ingrese un nuevo máximo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        MessageBox.Show("El numero debe ser mayor a cero, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("El valor no es un número entero, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("La materia prima ya existe en el almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buttonAdd_Product_Click(object sender, EventArgs e)
        {
            FinalProductController controlP = new FinalProductController();
            DataTable pList = controlP.getData();

            ProductWarehouseController control = new ProductWarehouseController();
            DataTable pWarehouseList = control.getData();

            string name = comboBox_Producto.SelectedItem.ToString();
            string idP = "";
            //validar que no esté en la lista
            int valido = 0;
            for (int i = 0; i < dataGridView_Product.Rows.Count; i++)
                if (dataGridView_Product.Rows[i].Cells[1].Value.ToString() == name)
                    valido = 1;


            if (valido == 0)
            {
                for (int i = 0; i < pList.Rows.Count; i++)
                {
                    if (string.Compare(pList.Rows[i]["name"].ToString(), name) == 0)
                    {
                        idP = pList.Rows[i]["idProduct"].ToString();
                        break;
                    }
                }
                int min, max;
                min = max = 0;
                if (int.TryParse(numericUpDown3.Value.ToString(), out min) && int.TryParse(numericUpDown4.Value.ToString(), out max))
                {

                    min = int.Parse(numericUpDown4.Value.ToString());
                    max = int.Parse(numericUpDown3.Value.ToString());

                    if (min != 0 && max != 0)
                    {
                        if (max > min)
                        {
                            control.insertData(idWarehouse, idP, numericUpDown4.Value.ToString(), numericUpDown3.Value.ToString());
                            MessageBox.Show("Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fillGridProduct();
                        }
                        else
                            MessageBox.Show("El valor máximo debe ser mayor al mínimo, por favor ingrese un nuevo máximo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("El numero debe ser mayor a cero, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("El valor no es un número entero, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
                MessageBox.Show("El producto ya existe en el almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            MessageBox.Show("Materias Primas eliminados", "Eliminar Materia Prima.", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            fillGridRawMaterial();
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
            MessageBox.Show("Productos eliminados", "Eliminar Producto.", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            fillGridProduct();
        }

        private void button_updateProduct_Click(object sender, EventArgs e)
        {
            ProductWarehouseController pWarehouseController = new ProductWarehouseController();

            int registros = dataGridView_Product.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                string ide = dataGridView_Product.Rows[i].Cells[6].Value.ToString();
                string name = dataGridView_Product.Rows[i].Cells[1].Value.ToString();
                if (Convert.ToBoolean(dataGridView_Product.Rows[i].Cells[6].Value) == true)
                {
                    int min, max;
                    min = max = 0;
                    //validacion que los valores max y min sean numeros
                    if (int.TryParse(dataGridView_Product.Rows[i].Cells[4].Value.ToString(), out min) &&
                        int.TryParse(dataGridView_Product.Rows[i].Cells[5].Value.ToString(), out max))
                    {
                        min = int.Parse(dataGridView_Product.Rows[i].Cells[4].Value.ToString());
                        max = int.Parse(dataGridView_Product.Rows[i].Cells[5].Value.ToString());

                        if (min >=0 && max != 0)
                        {
                            if (max > min)
                            {

                                string id = dataGridView_Product.Rows[i].Cells[7].Value.ToString();
                                //update de valores maximos y minimos
                                pWarehouseController.updateMinMax(id, min, max);
                                MessageBox.Show("Se actualizaron los valores.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fillGridProduct();
                            }
                            else
                                MessageBox.Show("El valor máximo no puede ser menor al minimo, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                            MessageBox.Show("Los valores maximo y minimo no pueden ser cero, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        MessageBox.Show("Los valores maximos o minimos a ingresar no son válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void button_updateRm_Click(object sender, EventArgs e)
        {
            RawMaterialWarehouseController rmWarehouseController = new RawMaterialWarehouseController();

            int registros = dataGridView_RawMaterial.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                string ide = dataGridView_RawMaterial.Rows[i].Cells[6].Value.ToString();
                string name = dataGridView_RawMaterial.Rows[i].Cells[1].Value.ToString();
                if (Convert.ToBoolean(dataGridView_RawMaterial.Rows[i].Cells[6].Value) == true)
                {
                    int min, max;
                    min = max = 0;
                    //validacion que los valores max y min sean numeros
                    if (int.TryParse(dataGridView_RawMaterial.Rows[i].Cells[4].Value.ToString(), out min) &&
                        int.TryParse(dataGridView_RawMaterial.Rows[i].Cells[5].Value.ToString(), out max))
                    {
                        min = int.Parse(dataGridView_RawMaterial.Rows[i].Cells[4].Value.ToString());
                        max = int.Parse(dataGridView_RawMaterial.Rows[i].Cells[5].Value.ToString());

                        if (min >= 0 && max != 0)
                        {
                            if (max > min)
                            {

                                string id = dataGridView_RawMaterial.Rows[i].Cells[7].Value.ToString();
                                //update de valores maximos y minimos
                                rmWarehouseController.updateMinMax(id, min, max);
                                MessageBox.Show("Se actualizaron los valores.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fillGridRawMaterial();
                            }
                            else
                                MessageBox.Show("El valor máximo no puede ser menor al minimo, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                            MessageBox.Show("Los valores maximo y minimo no pueden ser cero, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                        MessageBox.Show("Los valores maximos o minimos a ingresar no son válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
