using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Presentation.Purchases
{
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> toDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool s = Convert.ToBoolean(row.Cells[5].Value);

                if(s == true)
                {
                    toDelete.Add(row);
                }
            }
            foreach (DataGridViewRow row in toDelete)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SupplierDetail supplierDet = new SupplierDetail();
            supplierDet.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
