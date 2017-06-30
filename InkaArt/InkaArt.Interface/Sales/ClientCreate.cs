using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Business.Sales;

namespace InkaArt.Interface.Sales
{
    public partial class ClientCreate : Form
    {
        ClientController clientController = new ClientController();
        public ClientCreate()
        {
            InitializeComponent();
        }

        public ClientCreate(string text)
        {
            InitializeComponent();
            Text = text;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string personType = "-1", clientType = "-1", state = "-1";
            if (radio_juridic.Checked) personType = "0";
            if (radio_natural.Checked) personType = "1";
            if (radio_national.Checked) clientType = "0";
            if (inter_radio.Checked) clientType = "1";
            if (radio_inactive.Checked) state = "0";
            if (radio_active.Checked) state = "1";
            string priority = textbox_priority.Text;
            string messageResponse = clientController.makeValidations(personType, textbox_name.Text, textbox_ruc.Text, textbox_ruc.Text, priority, clientType, state, textbox_address.Text, textbox_phone.Text, textbox_contact.Text, textbox_email.Text);
            if (messageResponse.Equals("OK"))
            {
                int response = clientController.AddClient(personType, textbox_name.Text, textbox_ruc.Text, textbox_ruc.Text, priority, clientType, state, textbox_address.Text, textbox_phone.Text, textbox_contact.Text, textbox_email.Text);
                if (response >= 0)
                {
                    MessageBox.Show(this, "El cliente ha sido agregado correctamente.", "Crear cliente", MessageBoxButtons.OK);
                    ClearFields();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show(this, messageResponse, "Error", MessageBoxButtons.OK);
            }
        }

        private void ClearFields()
        {
            textbox_address.Clear();
            textbox_contact.Clear();
            textbox_email.Clear();
            textbox_name.Clear();
            textbox_phone.Clear();
            textbox_priority.Clear();
            textbox_ruc.Clear();
            radio_juridic.Checked = false;
            radio_natural.Checked = false;
            radio_national.Checked = false;
            inter_radio.Checked = false;
        }

        private void personRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_natural.Checked)
            {
                documentLabel.Text = "DNI";
                textbox_ruc.Text = "";
                textbox_ruc.MaxLength = 8;
            }
        }

        private void juridicRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_juridic.Checked)
            {
                documentLabel.Text = "RUC";
                textbox_ruc.Text = "";
                textbox_ruc.MaxLength = 11;
            }
        }

        private void trackbar_priority_Scroll(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void trackbar_priority_ValueChanged(object sender, EventArgs e)
        {
            textbox_priority.Text = trackbar_priority.Value.ToString();
        }

        private void textbox_priority_KeyUp(object sender, KeyEventArgs e)
        {
            if (clientController.validateTrackBar(textbox_priority.Text))
            {
                trackbar_priority.Value = int.Parse(textbox_priority.Text);
            }
            else
            {
                MessageBox.Show(this, "La prioridad debe ser un número", "Error", MessageBoxButtons.OK);
            }
        }

        private void ClientCreate_Load(object sender, EventArgs e)
        {

        }

        private void textbox_priority_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
