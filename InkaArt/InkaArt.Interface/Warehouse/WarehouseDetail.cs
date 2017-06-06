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
using Npgsql;

namespace InkaArt.Interface.Warehouse
{
    public partial class WarehouseDetail : Form
    {
        WarehouseCrud warehouseController;

        public WarehouseDetail()
        {
            InitializeComponent();
            warehouseController = new WarehouseCrud();
            //fillGridRawMaterial();
        }
        
        private void button_save_Click(object sender, EventArgs e)
        {
            string messageResponse = warehouseController.makeValidations(textBox_name.Text, textBox_description.Text, textBox_address.Text);
            if (messageResponse.Equals("OK"))
            {
                int response = warehouseController.createWarehouse(textBox_name.Text, textBox_description.Text, textBox_address.Text);
                if (response >= 0)
                {
                    MessageBox.Show(this, "El almacén ha sido agregado correctamente.", "Crear almacén", MessageBoxButtons.OK);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            /*else
            {
                MessageBox.Show("El almacén no ha sido creado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void ClearFields()
        {
            textBox_name.Clear();
            textBox_description.Clear();
            textBox_address.Clear();
        }

        private void buttonAdd_RawMaterial_Click(object sender, EventArgs e)
        {
           /* var show_form = new AddRawMaterialWarehouse();
            var result = show_form.ShowDialog();
           if (result == DialogResult.OK)
                updateDataGrid();*/
        }

        private void WarehouseDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
