using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using InkaArt.Business.Purchases;
using System.Windows.Forms;

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView_unitOfMeasurement.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[0].Value);
                if (s == true)
                {
                    toDelete.Add(row);
                }
            }

            foreach (DataGridViewRow row in toDelete)
            {
                dataGridView_unitOfMeasurement.Rows.Remove(row);
            }
        }

        private void button_create(object sender, EventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement(control);
            new_unit_of_measurement.Show();
        }

        private void button_search(object sender, EventArgs e)
        {

        }

        private void editUnitOfMeasurement(object sender, DataGridViewCellEventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement(dataGridView_unitOfMeasurement.CurrentRow);
            new_unit_of_measurement.Show();
        }
    }
}
