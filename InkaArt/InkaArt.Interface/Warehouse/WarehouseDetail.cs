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
        WarehouseCrud warehouseController = new WarehouseCrud();

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

            string messageResponse = warehouseController.makeValidations(textBox_name.Text, textBox_description.Text, textBox_address.Text, comboBox_status.Text);
            if (messageResponse.Equals("OK"))
            {
                int response = warehouseController.createWarehouse(textBox_name.Text, textBox_description.Text, textBox_address.Text, comboBox_status.Text);
                if (response > 0)
                {
                    MessageBox.Show(this, "El almacén ha sido agregado correctamente.", "Crear Almacén", MessageBoxButtons.OK);
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show(this, messageResponse, "Error", MessageBoxButtons.OK);
            }

            string name = textBox_name.Text;
            string description = textBox_description.Text;
            string address = textBox_address.Text;

            WarehouseCrud conn = new WarehouseCrud();
            conn.createWarehouse(name, description, address, "Activo");
            MessageBox.Show("Almacén Creado", "Crear almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void ClearFields()
        {
            textBox_name.Clear();
            textBox_description.Clear();
            textBox_address.Clear();
            textBox_idRawMaterial.Clear();
            textBox_nameRawMaterial.Clear();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
