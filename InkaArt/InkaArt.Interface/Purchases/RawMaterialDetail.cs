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
        bool isInEditMode=false;
        RawMaterialController control_material;
        RawMaterial_SupplierController control_material_supplier;
        RawMaterials ventanaRM;
        UnitOfMeasurementController control_units;
        DataTable unitsList;

        public RawMaterialDetail()
        {
            mode = 1; // crearRawMaterial
            InitializeComponent();
            control_material = new RawMaterialController();
            control_material_supplier = new RawMaterial_SupplierController();
            control_units = new UnitOfMeasurementController();
            textBox_averagePrice.Text = "0";
            textBox_averagePrice.Enabled = false;
            buttonSave.Text="🖫 Guardar";
            comboBox_status.SelectedIndex = 0;

            control_units = new UnitOfMeasurementController();
            unitsList = control_units.getData();
            for (int i = 0; i < unitsList.Rows.Count; i++)
                comboBox_unit.Items.Add(unitsList.Rows[i]["name"].ToString());
        }

        public RawMaterialDetail(RawMaterialController controlForm,RawMaterials viewRMList)
        {
            mode = 1;
            control_material = controlForm;
            control_material_supplier = new RawMaterial_SupplierController();
            control_units = new UnitOfMeasurementController();
            InitializeComponent();
            textBox_averagePrice.Text = "0";
            buttonSave.Text = "🖫 Guardar";
            textBox_averagePrice.Enabled = false;
            comboBox_status.SelectedIndex = 0;
            ventanaRM = viewRMList;
            control_units = new UnitOfMeasurementController();
            unitsList = control_units.getData();
            for (int i = 0; i < unitsList.Rows.Count; i++)
                comboBox_unit.Items.Add(unitsList.Rows[i]["name"].ToString());
        }

        public RawMaterialDetail(DataGridViewRow currentRawMaterial, RawMaterialController controlForm,RawMaterials viewRMList)
        {
            mode = 2; //editarRawMaterial
            control_material = controlForm;
            InitializeComponent();
            textBox_id.Text = currentRawMaterial.Cells[1].Value.ToString();
            textBox_name.Text = currentRawMaterial.Cells[2].Value.ToString();

            ventanaRM = viewRMList;
            comboBox_status.Text = currentRawMaterial.Cells[5].Value.ToString();
            textBox_description.Text = currentRawMaterial.Cells[3].Value.ToString();
            textBox_averagePrice.Text = currentRawMaterial.Cells[6].Value.ToString();
            
            textBox_name.Enabled = false;
            comboBox_unit.Enabled = false;
            comboBox_status.Enabled = false;
            textBox_description.Enabled = false;
            textBox_averagePrice.Enabled = false;
            buttonCreate.Enabled = false;

            control_material_supplier = new RawMaterial_SupplierController();
            DataTable priceList= control_material_supplier.getDataSuppliers(textBox_id.Text,"");
            dataGridView_suppliersPrice.DataSource = priceList;
            dataGridView_suppliersPrice.Columns["id_supplier"].HeaderText = "ID";
            dataGridView_suppliersPrice.Columns["price"].HeaderText = "Precio";
            dataGridView_suppliersPrice.Columns["id_raw_material"].Visible = false;
            double valorPrecio = 0;
            int registros = dataGridView_suppliersPrice.Rows.Count;
            for (int j = 0; j < registros; j++)
            {
                valorPrecio+=double.Parse(dataGridView_suppliersPrice.Rows[j].Cells[2].Value.ToString());
            }
            if(registros>0) valorPrecio = valorPrecio / registros;
            
            control_units = new UnitOfMeasurementController();
            unitsList = control_units.getData();
            for (int i = 0; i < unitsList.Rows.Count; i++)
            {
                comboBox_unit.Items.Add(unitsList.Rows[i]["name"].ToString());
                if (String.Compare(unitsList.Rows[i]["id_unit"].ToString(), currentRawMaterial.Cells[4].Value.ToString())==0)
                {
                    comboBox_unit.Text = unitsList.Rows[i]["name"].ToString();
                }
            }
            if (double.Parse(textBox_averagePrice.Text) != valorPrecio)
            {
                try
                {
                    control_material.updateData(textBox_id.Text, textBox_name.Text, textBox_description.Text, currentRawMaterial.Cells[4].Value.ToString(), comboBox_status.Text, valorPrecio);
                    textBox_averagePrice.Text = valorPrecio.ToString();
                    ventanaRM.desarrolloBusqueda();
                }
                catch (Exception)
                {

                }
            }
        }
        
        private void button_create(object sender, EventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement();
            var respuesta=new_unit_of_measurement.ShowDialog();
            if (respuesta == DialogResult.OK)
            {
                unitsList = control_units.getData();
                comboBox_unit.Items.Clear();
                for (int i = 0; i < unitsList.Rows.Count; i++)
                {
                    comboBox_unit.Items.Add(unitsList.Rows[i]["name"].ToString());
                }
            }
        }
        private bool validating_fields()
        {
            textBox_name.Text = textBox_name.Text.Trim();
            textBox_description.Text = textBox_description.Text.Trim();
            if (textBox_name.Text.Length<1 || textBox_description.Text.Length<1 || comboBox_unit.Text.Length<1 || comboBox_status.Text.Length < 1)
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button_save(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                if (!validating_fields())
                {
                    return;
                }
                isInEditMode = false;
                mode = 2;
                textBox_name.Enabled = false;
                comboBox_unit.Enabled = false;
                comboBox_status.Enabled = false;
                textBox_description.Enabled = false;
                buttonCreate.Enabled = false;
                buttonSave.Text = "Editar";
                int indexUnit=comboBox_unit.SelectedIndex;
                string id_unit_selected = unitsList.Rows[indexUnit]["id_unit"].ToString();
                control_material.insertData(textBox_name.Text, textBox_description.Text, id_unit_selected, comboBox_status.Text, Double.Parse(textBox_averagePrice.Text));
                ventanaRM.desarrolloBusqueda();
                Close();
            }
            else if(mode==2 && isInEditMode)
            {
                if (!validating_fields())
                {
                    return;
                }
                textBox_name.Enabled = false;
                comboBox_unit.Enabled = false;
                comboBox_status.Enabled = false;
                textBox_description.Enabled = false;
                buttonCreate.Enabled = false;
                buttonSave.Text = "Editar";
                isInEditMode = false;
                int indexUnit = comboBox_unit.SelectedIndex;
                string id_unit_selected = unitsList.Rows[indexUnit]["id_unit"].ToString();
                control_material.updateData(textBox_id.Text,textBox_name.Text, textBox_description.Text, id_unit_selected, comboBox_status.Text, Double.Parse(textBox_averagePrice.Text));
                ventanaRM.desarrolloBusqueda();
            }
            else
            {
                textBox_name.Enabled = true;
                comboBox_unit.Enabled = true;
                comboBox_status.Enabled = true;
                textBox_description.Enabled = true;
                buttonCreate.Enabled = true;
                buttonSave.Text = "🖫 Guardar";
                isInEditMode = true;
            }

        }
    }
}
