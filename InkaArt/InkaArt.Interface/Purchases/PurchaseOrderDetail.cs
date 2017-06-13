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
        SupplierController control_supplier;
        DataTable supList;
        int mode;
        bool isInEditMode = true;
        public PurchaseOrderDetail()
        {
            mode = 1;
            control = new PurchaseOrderController();
            control_supplier = new SupplierController();
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
            textBox_cantidad.Text = "0";
            buttonSave.Text = "🖫 Guardar";
            control_supplier = new SupplierController();
            llenarComboBoxSuppliers();
        }
        public PurchaseOrderDetail(DataGridViewRow currentPurchaseOrder, PurchaseOrderController controlForm)
        {
            mode = 2;
            control = controlForm;
            InitializeComponent();
            textBox_id.Text = currentPurchaseOrder.Cells[1].Value.ToString();
            textBox_idsupplier.Text = currentPurchaseOrder.Cells[2].Value.ToString();
            comboBox_status.Text = currentPurchaseOrder.Cells[3].Value.ToString();
            dateTimePicker_creation.Value = (DateTime) currentPurchaseOrder.Cells[4].Value;
            dateTimePicker_delivery.Value = (DateTime)currentPurchaseOrder.Cells[5].Value;
            textBox_total.Text = currentPurchaseOrder.Cells[6].Value.ToString();
            textBox_idsupplier.Enabled = false;
            dateTimePicker_creation.Enabled = false;
            dateTimePicker_delivery.Enabled = false;
            comboBox_status.Enabled = false;
            comboBox_supplier.Enabled = false;
            button_add.Enabled = false;
            buttonDelete.Enabled = false;
            textBox_cantidad.Enabled = false;
            control_supplier = new SupplierController();
            buscarNombreSupplier(textBox_idsupplier.Text);
        }
        private void filterSupplier()
        {
            DataRow[] rows;
            supList = control_supplier.getData();
            rows = supList.Select("status = 'Activo'");
            if (rows.Any()) supList = rows.CopyToDataTable();
            else supList.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            supList.DefaultView.Sort = sortQuery;
        }
        private void llenarComboBoxSuppliers()
        {
            filterSupplier();
            for (int i = 0; i < supList.Rows.Count; i++)
                comboBox_supplier.Items.Add(supList.Rows[i]["name"].ToString());
        }
        private void buscarNombreSupplier(string idSupp)
        {
            DataRow[] rows;
            supList = control_supplier.getData();
            rows = supList.Select("id_supplier = "+idSupp);
            if (rows.Any()) supList = rows.CopyToDataTable();
            else supList.Rows.Clear();
            string sortQuery = string.Format("id_supplier");
            supList.DefaultView.Sort = sortQuery;
            comboBox_supplier.Items.Add(supList.Rows[0]["name"].ToString());
            comboBox_supplier.SelectedIndex = 0;
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
            if (this.textBox_idsupplier.Text == "")
            {
                this.button_add.Enabled = false;
            }
            else this.button_add.Enabled = true;
        }
        private bool validating_alldata()
        {
            textBox_idsupplier.Text = textBox_idsupplier.Text.Trim();
            if(textBox_idsupplier.Text.Length<1 || comboBox_status.Text.Length<1)
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
                comboBox_supplier.Enabled = false;
                dateTimePicker_creation.Enabled = false;
                dateTimePicker_delivery.Enabled = false;
                comboBox_status.Enabled = false;
                button_add.Enabled = false;
                buttonDelete.Enabled = false;
                //hacer insert
                control.inserData(int.Parse(textBox_idsupplier.Text),comboBox_status.Text,DateTime.Parse(dateTimePicker_creation.Text),DateTime.Parse(dateTimePicker_delivery.Text),double.Parse(textBox_total.Text));
                
            }
            else if(mode==2 && isInEditMode)
            {
                if (!validating_alldata())
                {
                    return;
                }
                buttonSave.Text = "Editar";
                isInEditMode = false;
                comboBox_supplier.Enabled = false;
                dateTimePicker_creation.Enabled = false;
                dateTimePicker_delivery.Enabled = false;
                comboBox_status.Enabled = false;
                button_add.Enabled = false;
                buttonDelete.Enabled = false;
                //hacer update
                control.updateData(textBox_id.Text, int.Parse(textBox_idsupplier.Text), comboBox_status.Text, DateTime.Parse(dateTimePicker_creation.Text), DateTime.Parse(dateTimePicker_delivery.Text), double.Parse(textBox_total.Text));
            }
            else
            {
                isInEditMode = true;
                buttonSave.Text = "🖫 Guardar";
                dateTimePicker_creation.Enabled = true;
                dateTimePicker_delivery.Enabled = true;
                textBox_cantidad.Enabled = true;
                button_add.Enabled = true;
                buttonDelete.Enabled = true;
                comboBox_status.Enabled = true;

            }
        }
        
        private void verifying_quantity(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_cantidad.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números enteros en la cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_cantidad.Text = actualdata;
            int cantidad=int.Parse(textBox_cantidad.Text);
            double precio = 0; //CAMBIAR a->double.Parse(textBox_price.Text);
            double subtotal = precio * cantidad;
            textBox_subtotal.Text = subtotal.ToString();
        }

        private void verifying_factura(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_factura.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede números en la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_factura.Text = actualdata;
        }

        private int hallarId()
        {
            for (int i = 0; i < supList.Rows.Count; i++)
            {
                if (String.Compare(supList.Rows[i]["name"].ToString(), comboBox_supplier.Text) == 0)
                {
                    return int.Parse(supList.Rows[i]["id_supplier"].ToString());
                }
            }
            return -1;
        }
        private void cambiar_idsupplier(object sender, EventArgs e)
        {
            //cuando se elija un nuevo supplier se cambiará el id a mostrar
            textBox_idsupplier.Text = hallarId().ToString();
        }
    }
}