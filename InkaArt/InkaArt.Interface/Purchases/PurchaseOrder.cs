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
    public partial class PurchaseOrder : Form
    {
        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PurchaseOrderDetail purchaseDetail = new PurchaseOrderDetail();
            purchaseDetail.Show();
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
    }
}
