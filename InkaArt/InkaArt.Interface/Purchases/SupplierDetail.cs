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
using System.Net.Mail;
namespace InkaArt.Interface.Purchases
{
    public partial class SupplierDetail : Form
    {
        int mode;
        SupplierController control;
        RawMaterial_SupplierController control_rs;
        bool isInEditMode = false;
        bool editPriceMode = false;

        public SupplierDetail()
        {
            mode = 1; //crear Supplier
            control = new SupplierController();
            control_rs = new RawMaterial_SupplierController();
            InitializeComponent();
            textBox_priority.Text = "0";
            textBox_idSupplier.Enabled = false;
            buttonSave.Text = "🖫 Guardar";
        }

        public SupplierDetail(SupplierController controlForm)
        {
            mode = 1;
            control = controlForm;
            control_rs = new RawMaterial_SupplierController();
            InitializeComponent();
            textBox_idSupplier.Enabled = false;
            textBox_priority.Text = "0";
            buttonSave.Text = "🖫 Guardar";
        }
        public SupplierDetail(DataGridViewRow currentSupplier,SupplierController controlForm)
        {
            mode = 2; //editar Supplier
            control = controlForm;
            control_rs = new RawMaterial_SupplierController();
            InitializeComponent();
            textBox_idSupplier.Text = currentSupplier.Cells[1].Value.ToString();
            textBox_name.Text = currentSupplier.Cells[2].Value.ToString();
            textBox_ruc.Text = currentSupplier.Cells[3].Value.ToString();
            textBox_address.Text = currentSupplier.Cells[8].Value.ToString();
            trackBar_priority.Value = (int) currentSupplier.Cells[9].Value;
            textBox_priority.Text = trackBar_priority.Value.ToString();
            comboBox_status.Text = currentSupplier.Cells[7].Value.ToString();
            textBox_contactName.Text = currentSupplier.Cells[4].Value.ToString();
            textBox_email.Text = currentSupplier.Cells[6].Value.ToString();
            textBox_telephone.Text = currentSupplier.Cells[5].Value.ToString();
            textBox_idSupplier.Enabled = false;
            textBox_name.Enabled = false;
            textBox_ruc.Enabled = false;
            textBox_address.Enabled = false;
            trackBar_priority.Enabled = false;
            comboBox_status.Enabled = false;
            textBox_telephone.Enabled = false;
            textBox_contactName.Enabled = false;
            textBox_email.Enabled = false;
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;

            DataTable rm_supList=control_rs.getDataSuppliers("", textBox_idSupplier.Text);
            dataGridView_rm_sup.DataSource = rm_supList;
            dataGridView_rm_sup.Columns["id_raw_material"].HeaderText = "ID";
            dataGridView_rm_sup.Columns["id_raw_material"].ReadOnly = true;
            dataGridView_rm_sup.Columns["price"].HeaderText = "Precio";
            dataGridView_rm_sup.Columns["id_supplier"].Visible = false;
            
        }

        private void button_add(object sender, EventArgs e)
        {
            Form pageAddSupply = new AddSupply(this);
            pageAddSupply.Show();
        }

        private void button_delete(object sender, EventArgs e)
        {
            
        }
        

        private void trackBar_priority_Scroll(object sender, EventArgs e)
        {
            this.textBox_priority.Text = trackBar_priority.Value.ToString();
        }
        private bool verifying_email()
        {
            try
            {
                new MailAddress(textBox_email.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("El email no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool validating_filled()
        {
            textBox_name.Text = textBox_name.Text.Trim();
            textBox_address.Text = textBox_address.Text.Trim();
            textBox_contactName.Text = textBox_contactName.Text.Trim();
            textBox_email.Text = textBox_email.Text.Trim();

            if(textBox_name.Text.Length<1 || textBox_address.Text.Length<1 || textBox_contactName.Text.Length<1 || textBox_email.Text.Length<1 || textBox_ruc.Text.Length<1 || textBox_telephone.Text.Length < 1 || comboBox_status.Text.Length<1)
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button_event_click(object sender, EventArgs e)
        {
            if (mode==2 && isInEditMode)
            {
                if (!validating_filled() || !verifying_email())
                {
                    return;
                }
                isInEditMode = false;
                textBox_name.Enabled = false;
                textBox_ruc.Enabled = false;
                textBox_address.Enabled = false;
                trackBar_priority.Enabled = false;
                comboBox_status.Enabled = false;
                textBox_telephone.Enabled = false;
                textBox_contactName.Enabled = false;
                textBox_email.Enabled = false;
                buttonAdd.Enabled = false;
                buttonDelete.Enabled = false;
                dataGridView_rm_sup.Columns["price"].ReadOnly = true;
                control.updateData(textBox_idSupplier.Text,textBox_name.Text, long.Parse(textBox_ruc.Text), textBox_contactName.Text, long.Parse(textBox_telephone.Text), textBox_email.Text, textBox_address.Text, int.Parse(textBox_priority.Text), comboBox_status.Text);
                buttonSave.Text = "Editar";
            }
            else if (mode==2)
            {
                isInEditMode = true;
                textBox_name.Enabled = true;
                textBox_ruc.Enabled = true;
                textBox_address.Enabled = true;
                trackBar_priority.Enabled = true;
                comboBox_status.Enabled = true;
                textBox_telephone.Enabled = true;
                textBox_contactName.Enabled = true;
                textBox_email.Enabled = true;
                buttonAdd.Enabled = true;
                buttonDelete.Enabled = true;
                dataGridView_rm_sup.Columns["price"].ReadOnly = false;
                buttonSave.Text = "🖫 Guardar";
            }
            else
            {
                if (!validating_filled() || !verifying_email())
                {
                    return;
                }
                control.insertData(textBox_name.Text, long.Parse(textBox_ruc.Text), textBox_contactName.Text, long.Parse(textBox_telephone.Text), textBox_email.Text, textBox_address.Text, int.Parse(textBox_priority.Text), comboBox_status.Text);
                mode = 2;
                isInEditMode = false;
                textBox_name.Enabled = false;
                textBox_ruc.Enabled = false;
                textBox_address.Enabled = false;
                trackBar_priority.Enabled = false;
                comboBox_status.Enabled = false;
                textBox_telephone.Enabled = false;
                textBox_contactName.Enabled = false;
                textBox_email.Enabled = false;
                buttonAdd.Enabled = false;
                buttonDelete.Enabled = false;
                dataGridView_rm_sup.Columns["price"].ReadOnly = true;
                buttonSave.Text = "Editar";

            }
        }

        private void verifying_number(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_ruc.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el RUC", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_ruc.Text = actualdata;
        }

        private void verifying_telephone(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_telephone.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar números en el teléfono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_telephone.Text = actualdata;
        }

        private void veryfing_id(object sender, EventArgs e)
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

        private void button_doSearch(object sender, EventArgs e)
        {
            DataTable matList;
            textBox_idRawMaterial.Text = textBox_idRawMaterial.Text.Trim();
            matList = control_rs.getDataSuppliers(textBox_idRawMaterial.Text, textBox_idSupplier.Text);
            dataGridView_rm_sup.DataSource = matList;
            dataGridView_rm_sup.Columns["id_raw_material"].HeaderText = "ID";
            dataGridView_rm_sup.Columns["price"].HeaderText = "Precio";
            dataGridView_rm_sup.Columns["id_supplier"].Visible = false;
            dataGridView_rm_sup.Columns["price"].ReadOnly = false;
        }
        
        private void actualizar_precio(int fila)
        {
            string id_rm = dataGridView_rm_sup.Rows[fila].Cells[1].Value.ToString();
            string id_sup = dataGridView_rm_sup.Rows[fila].Cells[2].Value.ToString();
            string price = dataGridView_rm_sup.Rows[fila].Cells[3].Value.ToString();
            //control_rs.UpdateRM_Sup(id_rm, id_sup, price);
        }

        private void obtain_idEdit(object sender, EventArgs e)
        {
            if (isInEditMode)
            {
                editPriceMode = true;
            }
        }

        private void update_price(object sender, DataGridViewCellEventArgs e)
        {
            if (editPriceMode)
            {                   
                actualizar_precio(e.RowIndex);
            }
            editPriceMode = false;
        }
    }
}
