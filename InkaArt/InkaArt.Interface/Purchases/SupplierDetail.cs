using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Interface.Purchases;
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
        Suppliers suppliersWindow;
        public SupplierDetail()
        {
            mode = 1; //crear Supplier
            control = new SupplierController();
            control_rs = new RawMaterial_SupplierController();
            InitializeComponent();
            textBox_priority.Text = "0";
            textBox_idSupplier.Enabled = false;
            buttonSave.Text = "🖫 Guardar";
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            isInEditMode = true;
        }

        public SupplierDetail(SupplierController controlForm,Suppliers suppliersView)
        {
            mode = 1;
            control = controlForm;
            control_rs = new RawMaterial_SupplierController();
            InitializeComponent();
            textBox_idSupplier.Enabled = false;
            isInEditMode = true;
            textBox_priority.Text = "0";
            buttonSave.Text = "🖫 Guardar";
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            suppliersWindow = suppliersView;
            
        }
        public SupplierDetail(DataGridViewRow currentSupplier,SupplierController controlForm, Suppliers suppliersView)
        {
            mode = 2; //editar Supplier
            control = controlForm;
            suppliersWindow = suppliersView;
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

            llenarMaterias(textBox_idSupplier.Text);
            
        }

        private void llenarMaterias(string idSup)
        {
            DataTable rm_supList = control_rs.getDataSuppliers("", textBox_idSupplier.Text);
            dataGridView_rm_sup.DataSource = rm_supList;
            dataGridView_rm_sup.Columns["id_raw_material"].HeaderText = "ID";
            dataGridView_rm_sup.Columns["id_raw_material"].ReadOnly = true;
            dataGridView_rm_sup.Columns["price"].HeaderText = "Precio";
            dataGridView_rm_sup.Columns["id_supplier"].Visible = false;
        }
        private void button_add(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                MessageBox.Show("Primero debe crear el proveedor para agregar las materias primas", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Form pageAddSupply = new AddSupply(this,control_rs,textBox_idSupplier.Text);
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
            catch (Exception)
            {
                MessageBox.Show("El email no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private string crear_cadenaCampos()
        {
            string cadenaDeCampos = "";
            int numFaltante = 0;
            if (textBox_name.Text.Length < 1)
            {
                cadenaDeCampos += "nombre";
                numFaltante++;
            }
            if (textBox_ruc.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "RUC";
                numFaltante++;
            }
            if (textBox_address.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "dirección";
                numFaltante++;
            }
            if(comboBox_status.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "estado";
                numFaltante++;
            }
            if (textBox_contactName.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "contacto";
                numFaltante++;
            }
            if(textBox_email.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "correo";
                numFaltante++;
            }
            if (textBox_telephone.Text.Length < 1)
            {
                if (numFaltante > 0) cadenaDeCampos += ", ";
                cadenaDeCampos += "teléfono";
                numFaltante++;
            }
            if (numFaltante == 1) cadenaDeCampos = "Debe llenar el campo: " + cadenaDeCampos + ".";
            else if (numFaltante > 1) cadenaDeCampos = "Debe llenar los campos: " + cadenaDeCampos + ".";
            return cadenaDeCampos;
        }
        private bool validating_filled()
        {
            textBox_name.Text = textBox_name.Text.Trim();
            textBox_address.Text = textBox_address.Text.Trim();
            textBox_contactName.Text = textBox_contactName.Text.Trim();
            textBox_email.Text = textBox_email.Text.Trim();
            string cadena_Error = crear_cadenaCampos();       
            if (cadena_Error.Length>1)
            {
                MessageBox.Show(cadena_Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool verifying_length_ruc()
        {
            if (textBox_ruc.Text.Length != 11)
            {
                MessageBox.Show("El RUC debe tener 11 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool verifying_length_telephone()
        {
            if (textBox_ruc.Text.Length != 11)
            {
                MessageBox.Show("El teléfono debe tener al menos 7 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button_event_click(object sender, EventArgs e)
        {
            if (mode==2 && isInEditMode)
            {
                if (!validating_filled() || !verifying_length_ruc()||!verifying_length_telephone() || !verifying_email())
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
                control.updateData(textBox_idSupplier.Text,textBox_name.Text, textBox_ruc.Text, textBox_contactName.Text, int.Parse(textBox_telephone.Text), textBox_email.Text, textBox_address.Text, int.Parse(textBox_priority.Text), comboBox_status.Text);
                suppliersWindow.desarrolloBusqueda();
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
                if (!validating_filled() || !verifying_length_ruc() ||!verifying_length_telephone()|| !verifying_email())
                {
                    return;
                }
                control.insertData(textBox_name.Text, textBox_ruc.Text, textBox_contactName.Text, int.Parse(textBox_telephone.Text), textBox_email.Text, textBox_address.Text, int.Parse(textBox_priority.Text), comboBox_status.Text);
                mode = 2;
                suppliersWindow.desarrolloBusqueda();
                Close();

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

        private void verifying_contactname(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox_contactName.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (!Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    MessageBox.Show("Solo puede ingresar letras en el nombre de contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox_contactName.Text = actualdata;
        }
    }
}
