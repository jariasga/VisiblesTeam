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
    public partial class PurchaseOrderDetail : Form
    {
        public PurchaseOrderDetail()
        {
            InitializeComponent();
            button_add.Enabled = true;
            buttonDelete.Enabled = false;
            button_save.Enabled = false;
        }

        /* search */
        private void button1_Click(object sender, EventArgs e)
        {
            buttonDelete.Enabled = false;
            button_add.Enabled = true;
            buttonDelete.Enabled = true;
        }

        /* save */
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
            button_save.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                button_add.Enabled=true;
            }
            else button_add.Enabled = false;
        }


        /* delete */
        private void button_delete(object sender, EventArgs e)
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
    }
}