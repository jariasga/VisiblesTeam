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
    public partial class WarehouseSearchMovement : Form
    {
        public int id = 0;
        public string name = "";
        int prohibitedWarehouse = 0;
        TextBox idWarehouse;
        TextBox nameWarehouse;

        private MovementController movementController = new MovementController();

        public WarehouseSearchMovement()
        {
            InitializeComponent();
            realizandoBusqueda();
        }

        public WarehouseSearchMovement(TextBox text1, TextBox text2)
        {
            idWarehouse = text1;
            nameWarehouse = text2;
            InitializeComponent();
            realizandoBusqueda();
        }

        public WarehouseSearchMovement(TextBox text1, TextBox text2, int prohibitWare)
        {
            idWarehouse = text1;
            nameWarehouse = text2;
            prohibitedWarehouse = prohibitWare;
            InitializeComponent();
            realizandoBusqueda();
        }

        private void populateDataGridWarehouseMovement(NpgsqlDataReader listRows)
        {
            dataGridView1.Rows.Clear();

            while (listRows.Read())
            {
                dataGridView1.Rows.Add(listRows[0], listRows[1], listRows[2], listRows[3]);
            }            
        }

        private int validarEnteroPositivo(string stringTexto)
        {
            int valor=0;
            if(textBox_id.Text == "")
            {
                return -2;
            }
            if (textBox_id.Text != "")
            {
                try
                {
                    valor = Convert.ToInt32(textBox_id.Text);
                }
                catch
                {
                    MessageBox.Show("Favor de ingresar un valor entero para el id del almacén");
                    return -1;
                }
            }
            if (valor < 0)
            {
                MessageBox.Show("Favor de ingresar un valor entero positivo para el id del almacén");
                return -1;
            } return valor;
        }

        public void realizandoBusqueda()
        {
            NpgsqlDataReader warehouseList;
            int idWarehouse = 0;

            idWarehouse = validarEnteroPositivo(textBox_id.Text);
            if (idWarehouse == -1) return;

            warehouseList = movementController.GetWarehouseList(idWarehouse, textBox_name.Text, textBox_address.Text, prohibitedWarehouse);
            populateDataGridWarehouseMovement(warehouseList);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            realizandoBusqueda();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            idWarehouse.Text = "";
            nameWarehouse.Text = "";
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int cant = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[4].Value);

                if (s == true)
                {
                    id = Convert.ToInt32(row.Cells[0].Value);
                    name = Convert.ToString(row.Cells[1].Value);
                    cant++;
                    break;
                }
            }
            if(cant > 0)
            {
                idWarehouse.Text = Convert.ToString(id);
                nameWarehouse.Text = name;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



    }
}
