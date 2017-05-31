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
        UnitOfMeasurementController controlForm;
        public UnitOfMeasurement()
        {
            mode = 1; //Crear unitOfMeasurement
            controlForm = new UnitOfMeasurementController();
            controlForm.getData();
            InitializeComponent();
        }
        public UnitOfMeasurement(UnitOfMeasurementController control)
        {
            mode = 1; //Crear unitOfMeasurement
            controlForm = control;
            InitializeComponent();
        }

        public UnitOfMeasurement(DataGridViewRow currentUnitOfMeasurement, UnitOfMeasurementController control)
        {
            mode = 2; //Editar unitOfMeasurement
            controlForm = control;
            InitializeComponent();
            textBox_id.Text = currentUnitOfMeasurement.Cells[1].Value.ToString();
            textBox_nameUnit.Text = currentUnitOfMeasurement.Cells[2].Value.ToString();
            textBox_abbreviation.Text = currentUnitOfMeasurement.Cells[3].Value.ToString();
        }

        private void button_cancel(object sender, EventArgs e)
        {
            this.cleaningWindow();
            /*Closing the window*/
            this.Close();
        }

        private void button_save(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                //hacer el insert
                controlForm.insertData(textBox_nameUnit.Text, textBox_abbreviation.Text);
            }
            else
            {
                //hacer el update
                controlForm.updateData(textBox_id.Text, textBox_nameUnit.Text, textBox_abbreviation.Text);
            }
            /*Closing the window*/
            this.Close();
        }
        private void cleaningWindow()
        {
            textBox_nameUnit.Text = "";
            textBox_abbreviation.Text = "";
        }
    }
}