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
        public WarehouseIndex()
        {
            InitializeComponent();
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

        private void button_add_click(object sender, EventArgs e)
        {
            Form new_warehouse_window = new WarehouseDetail();
            new_warehouse_window.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int id;
            NpgsqlDataReader datos;
            if (Int32.TryParse(textBox_id.Text, out id))
            {
                Console.WriteLine("Por favor ingrese un valor entero");
            }
            string name = textBox_supplier.Text;
            string address = textBox_address.Text;
            string state = comboBox_status.GetItemText(comboBox_status.SelectedItem);

            WarehouseCrud conn = new WarehouseCrud();

            datos = conn.readWarehouse(id, name, address, state);

            int rowIndex = 0;

            //Limpiamos el datagridview
            this.dataGridView1.Rows.Clear();

            //Muestra los datos en el gridview
            while (datos.Read())
            {                
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = datos[0];
                row.Cells[1].Value = datos[1];
                row.Cells[2].Value = datos[3];
                row.Cells[3].Value = datos[4];
                dataGridView1.Rows.Add(row);
                /*
                dataGridView1.Rows[rowIndex].Cells[0].Value = datos[0];
                dataGridView1.Rows[rowIndex].Cells[1].Value = datos[1];
                dataGridView1.Rows[rowIndex].Cells[2].Value = datos[2];
                dataGridView1.Rows[rowIndex].Cells[3].Value = datos[3];*/
                rowIndex++;
            }
            
            //lestura de valores
            /*while (datos.Read())
                Console.Write("{0}\t{1} \n", datos[0], datos[1]);
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();
            int itemsUpdate = 0;
            int[] idUpdate = new int[500];
            string name = "", description = "", address = "", state = "";
            int idWarehouse = 0;
            //Se elimina la data
            WarehouseCrud objCrudWarehouse = new WarehouseCrud();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[6].Value);

                if (s == true)
                {
                    toDelete.Add(row);
                    idUpdate[itemsUpdate] = Convert.ToInt32(row.Cells[0].Value);
                    idWarehouse = Convert.ToInt32(row.Cells[0].Value);
                    name = Convert.ToString(row.Cells[1].Value);
                    address = Convert.ToString(row.Cells[2].Value);
                    state = Convert.ToString(row.Cells[3].Value);
                    description = "";
                    objCrudWarehouse.updateWareHouse(idWarehouse, name, description, address, state);
                    itemsUpdate++;
                }
            }
            
            MessageBox.Show("Almacenes actualizados", "Actualizar almacén",MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WarehouseCrud movimientos = new WarehouseCrud();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Users File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
                movimientos.massiveUpload(dialog.FileName);
        }


    }
}
