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

namespace InkaArt.Interface.Warehouse
{
    public partial class WarehouseSearchMovement : Form
    {
        public int id = 0;
        public string name = "";
        TextBox text1New;
        TextBox text2New;

        private WarehouseMovementController warehouseMovementController = new WarehouseMovementController();

        public WarehouseSearchMovement()
        {
            InitializeComponent();
        }

        public WarehouseSearchMovement(TextBox text1, TextBox text2)
        {
            text1New = text1;
            text2New = text2;
            InitializeComponent();
        }

        private void populateDataGridWarehouseMovement(DataTable listList)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow row in listList.Rows)
            {
                dataGridView1.Rows.Add(row["idWarehouse"], row["name"], row["address"], row["state"]);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DataTable warehouseList;

            if (textBox_id.Text.Equals("") && textBox_supplier.Text.Equals(""))
            {
                //Búsqueda en materiales y productos
                warehouseList = warehouseMovementController.GetWarehouseMovementList();
                populateDataGridWarehouseMovement(warehouseList);                
            }
            else
            {
                //string materialType = comboBox_status.SelectedIndex.ToString;
                warehouseList = warehouseMovementController.GetWarehouseMovementList(textBox_id.Text, textBox_supplier.Text, textBox_address.Text);
                populateDataGridWarehouseMovement(warehouseList);                
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            text1New.Text = "";
            text2New.Text = "";
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[4].Value);

                if (s == true)
                {
                    id = Convert.ToInt32(row.Cells[0].Value);
                    name = Convert.ToString(row.Cells[1].Value);
                    break;
                }
            }
            text1New.Text = Convert.ToString(id);
            text2New.Text = name;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



    }
}
