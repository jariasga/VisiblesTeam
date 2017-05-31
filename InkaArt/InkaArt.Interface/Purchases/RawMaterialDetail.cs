using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Business.Purchases;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class RawMaterialDetail : Form
    {
        int mode;
        RawMaterialController control;

        public RawMaterialDetail()
        {
            mode = 1; // crearRawMaterial
            InitializeComponent();
            textBox_averagePrice.Text = "0";
        }

        public RawMaterialDetail(RawMaterialController controlForm)
        {
            mode = 1;
            control = controlForm;
            InitializeComponent();
            textBox_averagePrice.Text = "0";
        }

        public RawMaterialDetail(DataGridViewRow currentRawMaterial, RawMaterialController controlForm)
        {
            mode = 2; //editarRawMaterial
            control = controlForm;
            InitializeComponent();
            textBox_id.Text = currentRawMaterial.Cells[1].Value.ToString();
            textBox_name.Text = currentRawMaterial.Cells[2].Value.ToString();
            comboBox_unit.Text = currentRawMaterial.Cells[4].Value.ToString();
            comboBox_status.Text = currentRawMaterial.Cells[5].Value.ToString();
            textBox_description.Text = currentRawMaterial.Cells[3].Value.ToString();
            textBox_averagePrice.Text = currentRawMaterial.Cells[6].Value.ToString();

            /*RawMaterial_SupplierController control = new RawMaterial_SupplierController();
            DataTable priceList=control.getDataSuppliers(1);
            dataGridView_suppliersPrice.DataSource = priceList;
            dataGridView_suppliersPrice.Columns["idSupplier"].HeaderText = "ID";
            dataGridView_suppliersPrice.Columns["price"].HeaderText = "Precio";*/

        }

        private void button_create(object sender, EventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement();
            new_unit_of_measurement.Show();
        }

        private void button_save(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                control.insertData(textBox_name.Text, textBox_description.Text, comboBox_unit.Text, comboBox_status.Text, Double.Parse(textBox_averagePrice.Text));
            }
            else
            {
                control.updateData(textBox_id.Text, textBox_name.Text, textBox_description.Text, comboBox_unit.Text, comboBox_status.Text, Double.Parse(textBox_averagePrice.Text));
            }
            /*closing*/
            this.Close();

        }
    }
}