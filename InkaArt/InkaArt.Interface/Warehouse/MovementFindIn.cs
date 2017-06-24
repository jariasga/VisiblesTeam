using InkaArt.Business.Production;
using InkaArt.Business.Purchases;
using InkaArt.Business.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace InkaArt.Interface.Warehouse
{
    public partial class MovementFindIn : Form
    {
        Dictionary<string, string> materials = new Dictionary<string, string>();
        Dictionary<string, string> products = new Dictionary<string, string>();
        string warehouse_id;

        public MovementFindIn(string warehouse_id)
        {
            InitializeComponent();
            this.warehouse_id = warehouse_id;
            getMaterials();
            getProducts();
            initializeCombos();         
        }

        private void getMaterials()
        {
            RawMaterialWarehouseController warehouse_materials_controller = new RawMaterialWarehouseController();
            DataTable warehouse_materials = warehouse_materials_controller.getData();
            RawMaterialController materials_controller = new RawMaterialController();
            DataTable all_materials = materials_controller.getData();

            for (int i = 0; i < warehouse_materials.Rows.Count; i++)
            {
                if (warehouse_materials.Rows[i]["idWarehouse"].ToString() == warehouse_id &&
                    warehouse_materials.Rows[i]["state"].ToString() == "Activo")
                {
                    for (int j = 0; j < all_materials.Rows.Count; j++)
                    {
                        if (all_materials.Rows[j]["id_raw_material"].ToString() == warehouse_materials.Rows[i]["idRawMaterial"].ToString())
                        {
                            materials.Add(all_materials.Rows[j]["id_raw_material"].ToString(), all_materials.Rows[j]["name"].ToString());
                            break;
                        }
                    }
                }
            }
        }
        

        private void getProducts()
        {
            ProductWarehouseController warehouse_products_controller = new ProductWarehouseController();
            DataTable warehouse_products = warehouse_products_controller.getData();
            FinalProductController products_controller = new FinalProductController();
            DataTable all_products = products_controller.getData();
            for (int i = 0; i < warehouse_products.Rows.Count; i++)
            {
                if (warehouse_products.Rows[i]["idWarehouse"].ToString() == warehouse_id &&
                    warehouse_products.Rows[i]["state"].ToString() == "Activo")
                {
                    for (int j = 0; j < all_products.Rows.Count; j++)
                    {
                        if (string.Compare(all_products.Rows[j]["idProduct"].ToString(), warehouse_products.Rows[i]["idProduct"].ToString()) == 0)
                        {
                            products.Add(all_products.Rows[j]["idProduct"].ToString(), all_products.Rows[j]["name"].ToString());
                            break;
                        }
                    }
                }
            }
        }

        private void initializeCombos()
        {
            Dictionary<int, string> types = new Dictionary<int, string>();
            types.Add(0, "Materia Prima");
            types.Add(1, "Producto");
            combo_type.DataSource = new BindingSource(types, null);
            combo_type.DisplayMember = "Value";
            combo_type.ValueMember = "Key";
            combo_type.SelectedValue = 0;

            setItemsCombo(combo_type.SelectedIndex);
        }

        private void setItemsCombo(int type)
        {
            bool exist;
            if (type == 0)
            {
                exist = materials.Count() > 0;
                label_item.Text = "Materias Primas";
                combo_item.DataSource = new BindingSource(materials, null);
            }
            else
            {
                exist = products.Count() > 0;
                label_item.Text = "Productos";
                combo_item.DataSource = new BindingSource(products, null);
                combo_type.SelectedValue = 1;
            }

            if (exist)
            {
                combo_item.DisplayMember = "Value";
                combo_item.ValueMember = "Key";
                combo_item.SelectedValue = -1;
            }            
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            ProductWarehouseController control = new ProductWarehouseController();
            RawMaterialWarehouseController controlRm = new RawMaterialWarehouseController();
            ProductionMovementMovementController controlM = new ProductionMovementMovementController();

            DataTable pwhList = control.getData();
            DataTable rmwhList = controlRm.getData();
            //0 mp, 1 producto
            //string item_id = combo_item.SelectedValue.ToString();

            if(combo_type.SelectedIndex == 0)//materia prima
            {
                int encontrado = 0;
                for(int i=0; i < rmwhList.Rows.Count; i++)
                {
                    if (rmwhList.Rows[i]["idWarehouse"].ToString() == warehouse_id)
                    {
                        encontrado = 1;
                        string item_id = combo_item.SelectedValue.ToString();
                        if (rmwhList.Rows[i]["idRawMaterial"].ToString() == item_id &&
                            rmwhList.Rows[i]["state"].ToString() == "Activo")
                        {
                            encontrado = 1;
                            int currentStock = 0;
                            int currentLogical = 0;
                            int maxStock = 0;
                            int aIngresar = 0;
                            currentStock = int.Parse(rmwhList.Rows[i]["currentStock"].ToString());
                            maxStock = int.Parse(rmwhList.Rows[i]["maximunStock"].ToString());
                            currentLogical = int.Parse(rmwhList.Rows[i]["virtualStock"].ToString());
                            if (int.TryParse(textBox6.Text, out aIngresar))
                            {
                                aIngresar = int.Parse(textBox6.Text);
                                int quantity = maxStock- currentStock -aIngresar;
                                if (quantity > 0)
                                {
                                    encontrado = 1;
                                    //update d la tabla
                                    controlRm.updateStock(warehouse_id, item_id,currentStock + aIngresar, currentLogical+ aIngresar);
                                    controlM.insertBrokenFindMovement(2, warehouse_id, 7, DateTime.Now.ToShortDateString(), item_id, 0, aIngresar);

                                    MessageBox.Show(this, "Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                                else
                                    encontrado = 3;//no hay espacio en almacen

                            }else
                                MessageBox.Show(this, "Ingrese una cantidad válida encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                        
                }
                if(encontrado ==0)
                    MessageBox.Show(this, "El almacén no puede recibir esta materia prima, por favor seleccione otro almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (encontrado ==3)
                    MessageBox.Show(this, "No hay espacio suficiente para guardar esta materia prima, por favor seleccione otro almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //aqui
                if(combo_type.SelectedIndex == 1)//producto
            {
                int encontrado = 0;
                for (int i = 0; i < pwhList.Rows.Count; i++)
                {
                    if (pwhList.Rows[i]["idWarehouse"].ToString() == warehouse_id)
                    {
                        encontrado = 1;
                        string item_id = combo_item.SelectedValue.ToString();
                        if (pwhList.Rows[i]["idProduct"].ToString() == item_id &&
                            pwhList.Rows[i]["state"].ToString() == "Activo")
                        {
                            encontrado = 1;
                            int currentStock = 0;
                            int currentLogical = 0;
                            int maxStock = 0;
                            int aIngresar = 0;
                            currentStock = int.Parse(pwhList.Rows[i]["currentStock"].ToString());
                            maxStock = int.Parse(pwhList.Rows[i]["maximunStock"].ToString());
                            currentLogical = int.Parse(pwhList.Rows[i]["virtualStock"].ToString());
                            if (int.TryParse(textBox6.Text, out aIngresar))
                            {
                                aIngresar = int.Parse(textBox6.Text);
                                int quantity = maxStock-currentStock - aIngresar;
                                if (quantity > 0)
                                {
                                    encontrado = 1;
                                    //update d la tabla
                                    control.updateStock(warehouse_id, item_id, currentStock + aIngresar, currentLogical + aIngresar);
                                    controlM.insertBrokenFindMovement(2, warehouse_id, 7, DateTime.Now.ToShortDateString(), item_id, 1, aIngresar);

                                    MessageBox.Show(this, "Se guardaron los cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                                else
                                    encontrado = 3;//no hay espacio en almacen
                            }
                            else
                                MessageBox.Show(this, "Ingrese una cantidad válida encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                }
                if (encontrado == 0)
                    MessageBox.Show(this, "El almacén no puede recibir este producto, por favor seleccione otro almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (encontrado == 3)
                    MessageBox.Show(this, "No hay espacio suficiente para guardar este producto, por favor seleccione otro almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void combo_type_SelectedValueChanged(object sender, EventArgs e)
        {
            setItemsCombo(combo_type.SelectedIndex);
        }

        private void MovementFindIn_Load(object sender, EventArgs e)
        {

        }
    }
}
