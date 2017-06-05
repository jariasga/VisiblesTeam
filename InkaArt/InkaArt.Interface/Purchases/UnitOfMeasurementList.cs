using System;
using System.Collections.Generic;
using System.Data;
using InkaArt.Business.Purchases;
using System.Windows.Forms;
using System.Linq;

namespace InkaArt.Interface.Purchases
{
    public partial class UnitOfMeasurementList : Form
    {
        UnitOfMeasurementController control;
        public UnitOfMeasurementList()
        {
            InitializeComponent();
            control = new UnitOfMeasurementController();
            DataTable unitOfMeasurementsList = control.getData();
            dataGridView_unitOfMeasurement.DataSource = unitOfMeasurementsList;

            dataGridView_unitOfMeasurement.Columns["idUnit"].HeaderText = "ID";
            dataGridView_unitOfMeasurement.Columns["name"].HeaderText = "Nombre";
            dataGridView_unitOfMeasurement.Columns["abbreviature"].HeaderText = "Abreviatura";
            dataGridView_unitOfMeasurement.Columns["status"].HeaderText = "Estado";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button_create(object sender, EventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement(control);
            new_unit_of_measurement.Show();
        }

        private void button_search(object sender, EventArgs e)
        {
            textBox_abbreviature.Text=textBox_abbreviature.Text.Trim();
            textBox_id.Text = textBox_id.Text.Trim();
            textBox_name.Text = textBox_name.Text.Trim();
            if(textBox_abbreviature.Text.Length<1 && textBox_id.Text.Length<1 && textBox_name.Text.Length < 1)
            {
                return;
            }
        }

        private void editUnitOfMeasurement(object sender, DataGridViewCellEventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement(dataGridView_unitOfMeasurement.CurrentRow,control);
            new_unit_of_measurement.Show();
        }

        private void validating_id(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_id.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_id.Text = actualdata;
        }

        private void button_delete(object sender, EventArgs e)
        {
            int registros = dataGridView_unitOfMeasurement.Rows.Count;
            for (int i = 0; i < registros; i++)
            {
                if (Convert.ToBoolean(dataGridView_unitOfMeasurement.Rows[i].Cells[0].Value) == true)
                {
                    string idUnit = dataGridView_unitOfMeasurement.Rows[i].Cells[1].Value.ToString();
                    string name = dataGridView_unitOfMeasurement.Rows[i].Cells[2].Value.ToString();
                    string abbrev = dataGridView_unitOfMeasurement.Rows[i].Cells[3].Value.ToString();
                    dataGridView_unitOfMeasurement.Rows[i].Cells[4].Value = "Inactivo";
                    string status = dataGridView_unitOfMeasurement.Rows[i].Cells[4].Value.ToString();
                    control.updateData(idUnit,name, abbrev, status);
                }
            }
        }
    }
}
