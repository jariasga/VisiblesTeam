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
        bool isInEditMode = true;
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
            buttonSave.Text = "🖫 Guardar";
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
            buttonSave.Text = "🖫 Guardar";
        }
        public PurchaseOrderDetail(DataGridViewRow currentPurchaseOrder, PurchaseOrderController controlForm)
        {
            mode = 2;
            control = controlForm;
            InitializeComponent();
            textBox_id.Text = currentPurchaseOrder.Cells[1].Value.ToString();
            textBox_supplier.Text = currentPurchaseOrder.Cells[2].Value.ToString();
            comboBox_status.Text = currentPurchaseOrder.Cells[3].Value.ToString();
            dateTimePicker_creation.Value = (DateTime) currentPurchaseOrder.Cells[4].Value;
            dateTimePicker_delivery.Value = (DateTime)currentPurchaseOrder.Cells[5].Value;
            textBox_total.Text = currentPurchaseOrder.Cells[6].Value.ToString();
            textBox_supplier.Enabled = false;
            dateTimePicker_creation.Enabled = false;
            dateTimePicker_delivery.Enabled = false;
            comboBox_status.Enabled = false;
            button_add.Enabled = false;
            buttonDelete.Enabled = false;
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
        private bool validating_alldata()
        {
            textBox_supplier.Text = textBox_supplier.Text.Trim();
            if(textBox_supplier.Text.Length<1 || comboBox_status.Text.Length<1)
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(dateTimePicker_creation.Value > dateTimePicker_delivery.Value)
            {
                MessageBox.Show("La fecha de emisión no puede ser posterior a la entrega", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
                return true;
        }
        private void button_save(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                if (!validating_alldata())
                {
                    return;
                }

                buttonSave.Text = "Editar";
                mode = 2;
                isInEditMode = false;
                textBox_supplier.Enabled = false;
                dateTimePicker_creation.Enabled = false;
                dateTimePicker_delivery.Enabled = false;
                comboBox_status.Enabled = false;
                button_add.Enabled = false;
                buttonDelete.Enabled = false;
                //hacer insert
                control.inserData(int.Parse(textBox_supplier.Text),comboBox_status.Text,DateTime.Parse(dateTimePicker_creation.Text),DateTime.Parse(dateTimePicker_delivery.Text),double.Parse(textBox_total.Text));
                
            }
            else if(mode==2 && isInEditMode)
            {
                if (!validating_alldata())
                {
                    return;
                }
                buttonSave.Text = "Editar";
                isInEditMode = false;
                textBox_supplier.Enabled = false;
                dateTimePicker_creation.Enabled = false;
                dateTimePicker_delivery.Enabled = false;
                comboBox_status.Enabled = false;
                button_add.Enabled = false;
                buttonDelete.Enabled = false;
                //hacer update
                control.updateData(textBox_id.Text, int.Parse(textBox_supplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), double.Parse(textBox_total.Text));
            }
            else
            {
                isInEditMode = true;
                buttonSave.Text = "🖫 Guardar";
                textBox_supplier.Enabled = true;
                dateTimePicker_creation.Enabled = true;
                dateTimePicker_delivery.Enabled = true;
                button_add.Enabled = true;
                buttonDelete.Enabled = true;
                comboBox_status.Enabled = true;

            }
        }

        private void validating_idmateria(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_idRawMaterial.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_idRawMaterial.Text = actualdata;
        }
    }
}