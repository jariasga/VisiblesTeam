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
    public partial class WarehouseDetail : Form
    {
        public WarehouseDetail()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form new_add_supply_window = new InkaArt.Interface.Purchases.AddSupply();
            new_add_supply_window.Show();
        }

        private void button_return_click(object sender, EventArgs e)
        {
            this.textBox_idWarehouse.Text = "";
            this.textBox_name.Text = "";
            this.textBox_description.Text = "";
            this.textBox_address.Text = "";
            this.textBox_idRawMaterial.Text = "";
            this.textBox_nameRawMaterial.Text = "";
            this.comboBox_status.Text = "";
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;
            string description = textBox_description.Text;
            string address = textBox_address.Text;

            WarehouseCrud conn = new WarehouseCrud();
            conn.createWarehouse(name, description, address, "Activo");
            MessageBox.Show("Almacén Creado", "Crear almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }
    }
}
