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
            string personType = radio_juridic.Checked ? "0" : "1";
            string clientType = radio_national.Checked ? "0" : "1";
            string state = radio_inactive.Checked ? "0" : "1";
            string priority = textbox_priority.Text;
            int response = clientController.AddClient(personType, textbox_name.Text, textbox_ruc.Text, textbox_ruc.Text, priority, clientType, state, textbox_address.Text, textbox_phone.Text, textbox_contact.Text, textbox_email.Text);
            if (response > 0)
            {
                MessageBox.Show(this,"El cliente ha sido agregado correctamente.","Crear cliente",MessageBoxButtons.OK);
                ClearFields();
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
                documentLabel.Text = "DNI";
        }

        private void juridicRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_juridic.Checked)
                documentLabel.Text = "RUC";
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
            trackbar_priority.Value = int.Parse(textbox_priority.Text);
        }

        private void ClientCreate_Load(object sender, EventArgs e)
        {

        }
    }
}
