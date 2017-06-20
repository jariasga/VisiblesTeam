using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using InkaArt.Business.Warehouse;

namespace InkaArt.Interface.Warehouse
{
    public partial class Form1 : Form
    {
        public int id = 0 ;
        public string name = "";
        public string productType = "";
        TextBox text1New;
        TextBox text2New;
        TextBox text3New;
        TextBox text8New;
        string idWarehouseOrigin;
        string idWarehouseDestiny;

        private ProductionItemMovementController productionItemMovementController = new ProductionItemMovementController();
        private MaterialMovementController materialMovementController = new MaterialMovementController();
        private ProductMovementController productMovementController = new ProductMovementController();

        public Form1()
        {
            InitializeComponent();
        }

        //public Form1(ref TextBox text1, ref TextBox text2,ref  TextBox text3)
        public Form1( TextBox text1,  TextBox text2,  TextBox text3, string warehouseOrigin, string warehouseDestiny, TextBox text8)
        {
            text1New = text1;
            text2New = text2;
            text3New = text3;
            text8New = text8;
            idWarehouseOrigin = warehouseOrigin;
            idWarehouseDestiny = warehouseDestiny;
            InitializeComponent();
        }

        private void populateDataGridMaterialMovement(DataTable listList)
        {
            foreach (DataRow row in listList.Rows)
            {
                dataGridView1.Rows.Add(row["id_raw_material"], row["name"],"Materia Prima");
            }
        }

        private void populateDataGridProductMovement(DataTable listList)
        {
            foreach (DataRow row in listList.Rows)
            {
                dataGridView1.Rows.Add(row["idProduct"], row["name"], "Producto");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
            DataTable materialList;
            DataTable productList;
            
            if (textBox_id.Text.Equals("") && textBox_supplier.Text.Equals("") && comboBox1.SelectedIndex == -1)
            {
                //Búsqueda en materiales y productos
                materialList = materialMovementController.GetMaterialMovementList();
                productList = productMovementController.GetProductMovementList();
                dataGridView1.Rows.Clear();
                populateDataGridProductMovement(productList);
                populateDataGridMaterialMovement(materialList);                 
            }
            else
            {
                //string materialType = comboBox_status.SelectedIndex.ToString;
                productList = productMovementController.GetProductMovementList(textBox_id.Text, textBox_supplier.Text);
                materialList = materialMovementController.GetMaterialMovementList(textBox_id.Text, textBox_supplier.Text);
                dataGridView1.Rows.Clear();
                populateDataGridProductMovement(productList);
                populateDataGridMaterialMovement(materialList);
            }
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int aux = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[4].Value);

                if (s == true)
                {
                    id = Convert.ToInt32(row.Cells[0].Value);
                    name = Convert.ToString(row.Cells[1].Value);
                    productType = Convert.ToString(row.Cells[2].Value);
                    try
                    {
                        aux = Convert.ToInt32(row.Cells[3].Value);
                        text8New.Text = Convert.ToString(aux);
                    }
                    catch
                    {

                    }
                    
                    break;
                }
            }
            text1New.Text = Convert.ToString(id);
            text2New.Text = name;
            text3New.Text = productType;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            text1New.Text = "";
            text2New.Text = "";
            text3New.Text = "";
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NpgsqlDataReader datos;

            datos = productionItemMovementController.getProductWarehouseWarehouse(idWarehouseOrigin, idWarehouseDestiny);
            int rowIndex = 0;


            dataGridView1.Rows.Clear();

            //Muestra los datos en el gridview
            while (datos.Read())
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = datos[0];
                row.Cells[1].Value = datos[1];
                row.Cells[2].Value = datos[2];
                dataGridView1.Rows.Add(row);
                rowIndex++;
            }
            productionItemMovementController.closeConnection();


        }
    }
}
