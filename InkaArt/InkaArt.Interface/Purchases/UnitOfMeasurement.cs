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
    public partial class UnitOfMeasurement : Form
    {
        int mode;
        bool isInEditMode = false;
        UnitOfMeasurementController controlForm;
        UnitOfMeasurementList unitsView;
        bool creandoDesdeRawMatView = false;
        public UnitOfMeasurement()
        {
            mode = 1; //Crear unitOfMeasurement para material
            controlForm = new UnitOfMeasurementController();
            controlForm.getData();
            InitializeComponent();
            isInEditMode = true;
            buttonSave.Text = "🖫 Guardar";
            comboBox_status.SelectedIndex = 0;
            creandoDesdeRawMatView = true;
        }
        public UnitOfMeasurement(UnitOfMeasurementController control)
        {
            mode = 1; //Crear unitOfMeasurement para material
            controlForm = control;
            controlForm.getData();
            InitializeComponent();
            isInEditMode = true;
            buttonSave.Text = "🖫 Guardar";
            comboBox_status.SelectedIndex = 0;
            creandoDesdeRawMatView = true;
            
        }
        public UnitOfMeasurement(UnitOfMeasurementController control,UnitOfMeasurementList viewFormUnits)
        {
            mode = 1; //Crear unitOfMeasurement
            controlForm = control;
            InitializeComponent();
            isInEditMode = true;
            buttonSave.Text = "🖫 Guardar";
            comboBox_status.SelectedIndex = 0;
            unitsView = viewFormUnits;
        }

        public UnitOfMeasurement(DataGridViewRow currentUnitOfMeasurement,UnitOfMeasurementController control, UnitOfMeasurementList viewFormUnits)
        {
            mode = 2; //Editar unitOfMeasurement
            isInEditMode = false;
            controlForm = control;
            InitializeComponent();
            textBox_id.Text = currentUnitOfMeasurement.Cells[1].Value.ToString();
            textBox_nameUnit.Text = currentUnitOfMeasurement.Cells[2].Value.ToString();
            textBox_abbreviation.Text = currentUnitOfMeasurement.Cells[3].Value.ToString();
            comboBox_status.Text = currentUnitOfMeasurement.Cells[4].Value.ToString();
            textBox_abbreviation.Enabled = false;
            textBox_nameUnit.Enabled = false;
            comboBox_status.Enabled = false;

            unitsView = viewFormUnits;
        }
        private bool validating_data()
        {
            textBox_abbreviation.Text = textBox_abbreviation.Text.Trim();
            textBox_nameUnit.Text = textBox_nameUnit.Text.Trim();
            if(textBox_nameUnit.Text.Length<1 || textBox_abbreviation.Text.Length < 1)
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_save(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                if (!validating_data())
                {
                    return;
                }
                //hacer el insert
                try
                {
                    controlForm.insertData(textBox_nameUnit.Text, textBox_abbreviation.Text, comboBox_status.Text);
                    if (!creandoDesdeRawMatView) unitsView.desarrolloBusqueda();
                    else
                    {
                        controlForm.getData();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (mode==2 && isInEditMode)
            {
                if (!validating_data())
                {
                    return;
                }
                try
                {
                    //hacer el update
                    controlForm.updateData(textBox_id.Text, textBox_nameUnit.Text, textBox_abbreviation.Text, comboBox_status.Text);
                    unitsView.desarrolloBusqueda();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                isInEditMode = true;
                buttonSave.Text = "🖫 Guardar";
                textBox_nameUnit.Enabled = true;
                textBox_abbreviation.Enabled = true;
                comboBox_status.Enabled = true;
            }
        }
    }
}
