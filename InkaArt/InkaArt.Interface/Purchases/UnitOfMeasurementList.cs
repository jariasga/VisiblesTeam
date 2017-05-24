using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class UnitOfMeasurementList : Form
    {
        public UnitOfMeasurementList()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[0].Value);
                if (s == true)
                {
                    toDelete.Add(row);
                }
            }

            foreach (DataGridViewRow row in toDelete)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button_create(object sender, EventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement();
            new_unit_of_measurement.Show();
        }

        private void button_search(object sender, EventArgs e)
        {

        }
    }
}
