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
            WarehouseDetail create_form = new WarehouseDetail();
            create_form.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*string id = grid_clients.Rows[e.RowIndex].Cells[0].Value.ToString();
            var show_form = new ClientShow(id);
            var result = show_form.ShowDialog();
            if (result == DialogResult.OK)
                updateDataGrid();*/
        }

        private void updateDataGrid()
        {
            DataTable clientList = warehouseController.GetWarehouses();
            populateDataGrid(clientList);
        }

        private void WarehouseIndex_Load(object sender, EventArgs e)
        {
            updateDataGrid();
        }

        private void populateDataGrid(DataTable clientList)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow row in clientList.Rows)
            {
                string status = row["status"].ToString().Equals("1") ? "Activo" : "Inactivo";
                if (status.Equals("Activo")) dataGridView1.Rows.Add(row["idClient"], row["ruc"], row["name"], status, row["priority"]);
            }
        }

        private void button_delete_click(object sender, EventArgs e)
        {
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();
            int itemsBorrar=0;
            int [] idEliminar = new int[500];
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[5].Value);

                if (s == true)
                {
                    toDelete.Add(row);
                    idEliminar[itemsBorrar] = Convert.ToInt32(row.Cells[0].Value);
                    itemsBorrar++;
                }
            }

            foreach (DataGridViewRow row in toDelete)
            {
                dataGridView1.Rows.Remove(row);
            }
            //Se elimina la data
            WarehouseCrud objCrudWarehouse = new WarehouseCrud();

            objCrudWarehouse.deleteWarehouse(idEliminar, itemsBorrar);
            MessageBox.Show("Almacenes eliminados", "Eliminar almacen", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            /*DataTable clientList;
            clientList = clientController.GetClients(textbox_id.Text, textbox_doc.Text, textbox_doc.Text, textbox_name.Text, combobox_state.SelectedIndex, combobox_priority.SelectedIndex);
            populateDataGrid(clientList);*/
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
