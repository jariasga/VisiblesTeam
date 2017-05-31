using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Purchases;
namespace InkaArt.Interface.Purchases
{
    public partial class PurchaseOrderDetail : Form
    {
        PurchaseOrderController control;
        int mode;
        public PurchaseOrderDetail()
        {
            mode = 1;
            control = new PurchaseOrderController();
            InitializeComponent();
            button_add.Enabled = false;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = true;
            dateTimePicker_creation.Value = DateTime.Now;
            textBox_total.Text = "0";
        }
        public PurchaseOrderDetail(PurchaseOrderController controlForm)
        {
            mode = 1;
            control = controlForm;
            InitializeComponent();
            button_add.Enabled = false;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = true;
            dateTimePicker_creation.Value = DateTime.Now;
            textBox_total.Text = "0";
        }
        public PurchaseOrderDetail(DataGridViewRow currentPurchaseOrder, PurchaseOrderController controlForm)
        {
            mode = 2;
            control = controlForm;
            InitializeComponent();
            textBox_id.Text = currentPurchaseOrder.Cells[1].Value.ToString();
            textBox_supplier.Text = currentPurchaseOrder.Cells[2].Value.ToString();
            comboBox_status.Text = currentPurchaseOrder.Cells[3].Value.ToString();
            dateTimePicker_creation.Value = (DateTime)currentPurchaseOrder.Cells[4].Value;
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
            if (mode == 1)
            {
                //hacer insert
                control.inserData(int.Parse(textBox_supplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), double.Parse(textBox_total.Text));

            }
            else
            {
                //hacer update
                control.updateData(textBox_id.Text, int.Parse(textBox_supplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), double.Parse(textBox_total.Text));
            }
            this.Close();
        }
    }
}