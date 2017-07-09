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
        WarehouseCrud warehouseController;
        string idWarehouse;

        public WarehouseShow(string id)
        {
            InitializeComponent();
            warehouseId = int.Parse(id);
            warehouseController = new WarehouseCrud();
            idWarehouse = id;
            RawMaterialController controlRM = new RawMaterialController();
            DataTable rmList = controlRM.getData();
            for (int i = 0; i< rmList.Rows.Count; i++)
            {
                if(rmList.Rows[i]["status"].ToString()=="Activo")
                    combo_rm.Items.Add(rmList.Rows[i]["name"]);
            }
            combo_rm.SelectedIndex = 1;
            FinalProductController controlP = new FinalProductController();
            DataTable pList = controlP.getData();
            for (int i = 0; i < pList.Rows.Count; i++)
                comboBox_Producto.Items.Add(pList.Rows[i]["name"]);
            comboBox_Producto.SelectedIndex = 1;
            fillGridRawMaterial();
            fillGridProduct();
            enableDisableFields(false);
        }

        public void fillGridRawMaterial()
        {
            RawMaterialWarehouseController control = new RawMaterialWarehouseController();
            RawMaterialController controlRM = new RawMaterialController();

            DataTable rmWarehouseList = control.getData();
            DataTable rmList = controlRM.getData();

            string name = "";
            grid_rm.Rows.Clear();

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
                    grid_rm.Rows.Add(rmWarehouseList.Rows[i]["idRawMaterial"],
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
            grid_product.Rows.Clear();

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
                    grid_product.Rows.Add(pWarehouseList.Rows[i]["idProduct"],
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

        private void buttonEditSaveClick(object sender, EventArgs e)
        {
            if (!textBox_name.Enabled)
            {
                enableDisableFields(true);
                button_edit.Text = "🖫 Guardar";
            }
            else
            {
                int response = warehouseController.updateWarehouse(warehouseId.ToString(), textBox_name.Text, textBox_description.Text, textBox_address.Text);
                if (updateProducts() && updateRM() && response >= 0)
                {
                    MessageBox.Show(this, "El almacén ha sido actualizado correctamente.", "Editar almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        
        private void enableDisableFields(bool enabled)
        {
            textBox_name.Enabled = enabled;
            textBox_description.Enabled = enabled;
            textBox_address.Enabled = enabled;

            combo_rm.Enabled = enabled;
            num_rm_min.Enabled = enabled;
            num_rm_max.Enabled = enabled;
            button_add_rm.Enabled = enabled;
            button_delete_rm.Visible = enabled;
            grid_rm.Columns["rm_stock_min"].ReadOnly = !enabled;
            grid_rm.Columns["rm_stock_max"].ReadOnly = !enabled;

            num_product_max.Enabled = enabled;
            num_product_min.Enabled = enabled;
            comboBox_Producto.Enabled = enabled;
            button_add_product.Enabled = enabled;
            button_delete_product.Visible = enabled;
            grid_product.Columns["pr_stock_min"].ReadOnly = !enabled;
            grid_product.Columns["pr_stock_max"].ReadOnly = !enabled;
        }

        private void buttonAddRMClick(object sender, EventArgs e)
        {
            RawMaterialController controlRM = new RawMaterialController();
            DataTable rmList = controlRM.getData();

            RawMaterialWarehouseController control = new RawMaterialWarehouseController();
            DataTable rmWarehouseList = control.getData();

            string name = combo_rm.SelectedItem.ToString();
            string idRM = "";
            //validar que no esté en la lista
            int valido = 0;
            for (int i = 0; i < grid_rm.Rows.Count; i++)
                if (grid_rm.Rows[i].Cells[1].Value.ToString() == name)
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
                if (int.TryParse(num_rm_min.Value.ToString(), out min) && int.TryParse(num_rm_max.Value.ToString(), out max))
                {
                    min = int.Parse(num_rm_min.Value.ToString());
                    max = int.Parse(num_rm_max.Value.ToString());

                    if (min >= 0 && max != 0)
                    {
                        if (max > min)
                        {
                            try
                            {
                                control.insertData(idWarehouse, idRM, name, num_rm_min.Value.ToString(), num_rm_max.Value.ToString());
                                MessageBox.Show("Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception m)
                            {
                                Console.WriteLine("{0} error", m);
                            }
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

        private void buttonAddProductClick(object sender, EventArgs e)
        {
            FinalProductController controlP = new FinalProductController();
            DataTable pList = controlP.getData();

            ProductWarehouseController control = new ProductWarehouseController();
            DataTable pWarehouseList = control.getData();

            string name = comboBox_Producto.SelectedItem.ToString();
            string idP = "";
            //validar que no esté en la lista
            int valido = 0;
            for (int i = 0; i < grid_product.Rows.Count; i++)
                if (grid_product.Rows[i].Cells[1].Value.ToString() == name)
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
                if (int.TryParse(num_product_max.Value.ToString(), out min) && int.TryParse(num_product_min.Value.ToString(), out max))
                {

                    min = int.Parse(num_product_min.Value.ToString());
                    max = int.Parse(num_product_max.Value.ToString());

                    if (min >= 0 && max != 0)
                    {
                        if (max > min)
                        {
                            try
                            {
                                control.insertData(idWarehouse, idP, num_product_min.Value.ToString(), num_product_max.Value.ToString());
                                MessageBox.Show("Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception m)
                            {
                                Console.WriteLine("{0} error", m);
                            }
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

        private void buttonDeleteRMClick(object sender, EventArgs e)
        {
            RawMaterialWarehouseController rwWarehouseController = new RawMaterialWarehouseController();

            int registros = grid_rm.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                string ide = grid_rm.Rows[i].Cells[6].Value.ToString();
                string name = grid_rm.Rows[i].Cells[1].Value.ToString();
                if (Convert.ToBoolean(grid_rm.Rows[i].Cells[6].Value) == true)
                {
                    string id = grid_rm.Rows[i].Cells[7].Value.ToString();
                    //Debug.WriteLine(id);
                    try
                    {
                        rwWarehouseController.deleteData(id);
                    }
                    catch (Exception m)
                    {
                        Console.WriteLine("{0} error", m);
                    }
                }
            }
            //updateDataGrid();
            MessageBox.Show("Materias Primas eliminados", "Eliminar Materia Prima.", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            fillGridRawMaterial();
        }

        private void dataGridView_RawMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDeleteProductClick(object sender, EventArgs e)
        {
            ProductWarehouseController pWarehouseController = new ProductWarehouseController();

            int registros = grid_product.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                string ide = grid_product.Rows[i].Cells[6].Value.ToString();
                string name = grid_product.Rows[i].Cells[1].Value.ToString();
                if (Convert.ToBoolean(grid_product.Rows[i].Cells[6].Value) == true)
                {
                    string id = grid_product.Rows[i].Cells[7].Value.ToString();
                    //Debug.WriteLine(id);
                    try
                    {
                        pWarehouseController.deleteData(id);
                    }
                    catch (Exception m)
                    {
                        Console.WriteLine("{0} error", m);
                    }
                }
            }
            //updateDataGrid();
            MessageBox.Show("Productos eliminados", "Eliminar Producto.", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            fillGridProduct();
        }
        
        private bool updateProducts()
        {
            ProductWarehouseController pWarehouseController = new ProductWarehouseController();

            int registros = grid_product.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                string ide = grid_product.Rows[i].Cells[6].Value.ToString();
                string name = grid_product.Rows[i].Cells[1].Value.ToString();
                if (Convert.ToBoolean(grid_product.Rows[i].Cells[6].Value) == true)
                {
                    int min, max;
                    min = max = 0;
                    //validacion que los valores max y min sean numeros
                    if (int.TryParse(grid_product.Rows[i].Cells[4].Value.ToString(), out min) &&
                        int.TryParse(grid_product.Rows[i].Cells[5].Value.ToString(), out max))
                    {
                        if (min >= 0 && max >= 0)
                        {
                            if (max > min)
                            {

                                string id = grid_product.Rows[i].Cells[7].Value.ToString();
                                //update de valores maximos y minimos
                                try
                                {
                                    pWarehouseController.updateMinMax(id, min, max);
                                    MessageBox.Show("Se actualizaron los valores.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception m)
                                {
                                    Console.WriteLine("{0} error", m);
                                }
                                //fillGridProduct();
                            }
                            else
                            {
                                MessageBox.Show("El valor máximo no puede ser menor al minimo, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los valores maximo y minimo no pueden ser cero, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Los valores maximos o minimos a ingresar no son válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            fillGridProduct();
            return true;
        }

        private bool updateRM()
        {
            RawMaterialWarehouseController rmWarehouseController = new RawMaterialWarehouseController();

            int registros = grid_rm.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                string ide = grid_rm.Rows[i].Cells[6].Value.ToString();
                string name = grid_rm.Rows[i].Cells[1].Value.ToString();
                if (Convert.ToBoolean(grid_rm.Rows[i].Cells[6].Value) == true)
                {
                    int min, max;
                    min = max = 0;
                    //validacion que los valores max y min sean numeros
                    if (int.TryParse(grid_rm.Rows[i].Cells[4].Value.ToString(), out min) &&
                        int.TryParse(grid_rm.Rows[i].Cells[5].Value.ToString(), out max))
                    {
                        if (min >= 0 && max != 0)
                        {
                            if (max > min)
                            {

                                string id = grid_rm.Rows[i].Cells[7].Value.ToString();
                                //update de valores maximos y minimos
                                try
                                {
                                    rmWarehouseController.updateMinMax(id, min, max);
                                    //MessageBox.Show("Se actualizaron los valores.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception m)
                                {
                                    Console.WriteLine("{0} error", m);
                                }
                                //fillGridRawMaterial();
                            }
                            else
                            {
                                MessageBox.Show("El valor máximo no puede ser menor al minimo, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Los valores maximo y minimo no pueden ser cero, por favor ingrese un nuevo valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Los valores maximos o minimos a ingresar no son válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            //if (seActualizoAlguno == 1)
                //MessageBox.Show("Se actualizaron los valores.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fillGridRawMaterial();
            return true;
        }

    }
}
