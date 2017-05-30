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
        int mode;
        public PurchaseOrderDetail()
        {
            mode = 1;
            InitializeComponent();
            button_add.Enabled = false;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = true;
            dateTimePicker_creation.Value = DateTime.Now;
            textBox_total.Text = "0";
        }

        public PurchaseOrderDetail(DataGridViewRow currentPurchaseOrder)
        {
            mode = 2;
            InitializeComponent();
            textBox_id.Text = currentPurchaseOrder.Cells[1].Value.ToString();
            textBox_supplier.Text = currentPurchaseOrder.Cells[2].Value.ToString();
            comboBox_status.Text = currentPurchaseOrder.Cells[3].Value.ToString();
            dateTimePicker_creation.Value = (DateTime) currentPurchaseOrder.Cells[4].Value;
            dateTimePicker_delivery.Value = (DateTime)currentPurchaseOrder.Cells[5].Value;
            textBox_total.Text = currentPurchaseOrder.Cells[6].Value.ToString();
        }

        /* search */
        private void button1_Click(object sender, EventArgs e)
        {

        }

        /* save */
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            Form new_supply_window = new AddSupplyForOrder();
            new_supply_window.Show();
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

        private void textBox_supplier_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_supplier.Text == "")
            {
                this.button_add.Enabled = false;
            }
            else this.button_add.Enabled = true;
        }

        private void button_save(object sender, EventArgs e)
        {
            /*closing*/
            this.textBox_id.Text = "";
            this.textBox_supplier.Text = "";
            this.textBox_total.Text = "";
            this.comboBox_status.Text = "";
            this.dataGridView1.Rows.Clear();
            this.textBox_idRawMaterial.Text = "";
            this.textBox_nameRawMaterial.Text = "";
            this.dateTimePicker_creation.Value = DateTime.Today;
            this.dateTimePicker_delivery.Value = DateTime.Today;
            this.Close();
        }
    }
}