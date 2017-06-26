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
        SupplierController control_supplier;
        RawMaterials ventanaRM;
        UnitOfMeasurementController control_units;
        DataTable unitsList;
        DataTable priceList;

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
            comboBox_status.Enabled = false;
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
            comboBox_status.Enabled = false;
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
            textBox_id.Text = currentRawMaterial.Cells[0].Value.ToString();
            textBox_name.Text = currentRawMaterial.Cells[1].Value.ToString();

            ventanaRM = viewRMList;
            comboBox_status.Text = currentRawMaterial.Cells[4].Value.ToString();
            textBox_description.Text = currentRawMaterial.Cells[2].Value.ToString();
            textBox_averagePrice.Text = currentRawMaterial.Cells[5].Value.ToString();
            
            textBox_name.Enabled = false;
            comboBox_unit.Enabled = false;
            comboBox_status.Enabled = false;
            textBox_description.Enabled = false;
            textBox_averagePrice.Enabled = false;
            buttonCreate.Enabled = false;

            control_material_supplier = new RawMaterial_SupplierController();
            priceList= filterRawMaterial();
            llenarTablaSuppliers();

            double valorPrecio = 0;
            int registros = dataGridView_suppliersPrice.Rows.Count;
            for (int j = 0; j < registros; j++)
            {
                valorPrecio+=double.Parse(dataGridView_suppliersPrice.Rows[j].Cells[2].Value.ToString());
            }
            if(registros>0) valorPrecio = Math.Round(valorPrecio / registros,2);
            
            control_units = new UnitOfMeasurementController();
            unitsList = control_units.getData();
            for (int i = 0; i < unitsList.Rows.Count; i++)
            {
                comboBox_unit.Items.Add(unitsList.Rows[i]["name"].ToString());
                if (String.Compare(unitsList.Rows[i]["id_unit"].ToString(), currentRawMaterial.Cells[6].Value.ToString())==0)
                {
                    comboBox_unit.Text = unitsList.Rows[i]["name"].ToString();
                }
            }
            if (double.Parse(textBox_averagePrice.Text) != valorPrecio)
            {
                try
                {
                    control_material.updateData(textBox_id.Text, textBox_name.Text, textBox_description.Text, currentRawMaterial.Cells[6].Value.ToString(), comboBox_status.Text, valorPrecio);
                    textBox_averagePrice.Text = valorPrecio.ToString();
                    ventanaRM.desarrolloBusqueda();
                }
                catch (Exception)
                {

                }
            }
        }
        public void llenarTablaSuppliers()
        {
            DataRow[] rows = priceList.Select("status LIKE 'Activo'");
            if (rows.Any()) priceList = rows.CopyToDataTable();
            else priceList.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            priceList.DefaultView.Sort = sortQuery;

            dataGridView_suppliersPrice.Rows.Clear();
            for (int i = 0; i < priceList.Rows.Count; i++)
            {
                string id_supplier = priceList.Rows[i]["id_supplier"].ToString();
                string id_raw_material = priceList.Rows[i]["id_raw_material"].ToString();
                string nombre = buscarNombre(id_supplier);
                double price = double.Parse(priceList.Rows[i]["price"].ToString());
                string id_rawmaterial_supplier = priceList.Rows[i]["id_rawmaterial_supplier"].ToString();
                string status = priceList.Rows[i]["status"].ToString();
                dataGridView_suppliersPrice.Rows.Add(id_supplier, nombre, price, nombre, id_raw_material, status, id_rawmaterial_supplier);
            }
        }
        public string buscarNombre(string id_supplier)
        {
            DataRow[] rows;
            if (control_supplier == null) control_supplier = new SupplierController();
            DataTable auxiliarLista = control_supplier.getData();
            rows = auxiliarLista.Select("id_supplier = " + id_supplier);
            if (rows.Any()) auxiliarLista = rows.CopyToDataTable();
            else auxiliarLista.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            auxiliarLista.DefaultView.Sort = sortQuery;
            if (auxiliarLista.Rows.Count != 0) return auxiliarLista.Rows[0]["name"].ToString();
            else return "";
        }
        public DataTable filterRawMaterial()
        {
            //obtengo las materias primas para llenar el combobox
            DataRow[] rows;
            DataTable rawMaterialSupList = control_material_supplier.getData();
            rows = rawMaterialSupList.Select("status LIKE 'Activo' AND id_raw_material="+ textBox_id.Text);
            if (rows.Any()) rawMaterialSupList = rows.CopyToDataTable();
            else rawMaterialSupList.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            rawMaterialSupList.DefaultView.Sort = sortQuery;
            return rawMaterialSupList;
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
                try
                {
                    control_material.insertData(textBox_name.Text, textBox_description.Text, id_unit_selected, comboBox_status.Text, Double.Parse(textBox_averagePrice.Text));
                    ventanaRM.desarrolloBusqueda();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
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
                try
                {
                    control_material.updateData(textBox_id.Text, textBox_name.Text, textBox_description.Text, id_unit_selected, comboBox_status.Text, Double.Parse(textBox_averagePrice.Text));
                    ventanaRM.desarrolloBusqueda();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
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
