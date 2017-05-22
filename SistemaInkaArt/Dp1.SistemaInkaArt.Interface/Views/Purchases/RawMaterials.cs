using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInkaArt.Presentation.Purchases
{
    public partial class RawMaterials : Form
    {
        public RawMaterials()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RawMaterialDetail rawMaterialDet = new RawMaterialDetail();
            rawMaterialDet.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
