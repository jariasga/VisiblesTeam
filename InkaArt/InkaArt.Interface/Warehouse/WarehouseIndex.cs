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
using Npgsql;


namespace InkaArt.Interface.Warehouse
{
    public partial class WarehouseIndex : Form
    {
        private WarehouseCrud warehouseController = new WarehouseCrud();
        public WarehouseIndex()
        {
            InitializeComponent();
        }

        private void button_add_click(object sender, EventArgs e)
        {
            var create_form = new WarehouseDetail();
            var result = create_form.ShowDialog();
            if (result == DialogResult.OK)
                updateDataGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            var show_form = new WarehouseShow(id);
            var result = show_form.ShowDialog();
            if (result == DialogResult.OK)
                updateDataGrid();
        }

        private void updateDataGrid()
        {
            DataTable warehouseList = warehouseController.GetWarehouses();
            populateDataGrid(warehouseList);
        }

        private void WarehouseIndex_Load(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        private void populateDataGrid(DataTable warehouseList)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow row in warehouseList.Rows)
            {
                string status = row["state"].ToString();
                if (status.Equals("Activo")) dataGridView1.Rows.Add(row["idWarehouse"], row["name"], row["description"], row["address"]);
            }
        }

        private void button_delete_click(object sender, EventArgs e)
        {
            int registros = dataGridView1.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value) == true)
                {
                    string id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string description = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string address = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string state="Inactivo";
                    warehouseController.updateWarehouse(id, name, description,address, state);
                }
            }


            //List<DataGridViewRow> toDelete = new List<DataGridViewRow>();
            //int itemsBorrar=0;
            //int [] idEliminar = new int[500];
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    bool s = Convert.ToBoolean(row.Cells[5].Value);

            //    if (s == true)
            //    {
            //        toDelete.Add(row);
            //        idEliminar[itemsBorrar] = Convert.ToInt32(row.Cells[0].Value);
            //        itemsBorrar++;
            //    }
            //}

            //foreach (DataGridViewRow row in toDelete)
            //{
            //    dataGridView1.Rows.Remove(row);
            //}
            ////Se elimina la data
            //WarehouseCrud objCrudWarehouse = new WarehouseCrud();
            //MessageBox.Show("Almacenes eliminados", "Eliminar almacen", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            MessageBox.Show("Almacenes eliminados", "Eliminar almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DataTable warehouseList;
            warehouseList = warehouseController.GetWarehouses(textBox_id.Text, textBox_name.Text, textBox_description.Text, textBox_address.Text, comboBox_status.Text);
            populateDataGrid(warehouseList);
        }
        /*
                private void button_bulk_upload_Click(object sender, EventArgs e)
                {
                    WarehouseCrud movimientos = new WarehouseCrud();
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Title = "Open Users File";
                    dialog.Filter = "CSV files|*.csv";
                    if (dialog.ShowDialog() == DialogResult.OK)
                        movimientos.massiveUpload(dialog.FileName);
                }*/
    }
}
