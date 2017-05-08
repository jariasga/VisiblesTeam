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
    public partial class PurchaseOrderDetail : Form
    {
        public PurchaseOrderDetail()
        {
            InitializeComponent();
            button3.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button2.Enabled = true;
            button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
