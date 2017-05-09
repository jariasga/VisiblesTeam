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
            button_add.Enabled = true;
            button_delete.Enabled = false;
            button_save.Enabled = false;
        }

        /* delete */
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

        /* search */
        private void button1_Click(object sender, EventArgs e)
        {
            button_delete.Enabled = false;
            button_add.Enabled = true;
            button_delete.Enabled = true;
        }

        /* save */
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            button_delete.Enabled = true;
            button_save.Enabled = true;
        }
    }
}
