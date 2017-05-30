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
            string priority = "4";
            string response = clientController.AddClient(personType, textbox_name.Text, textbox_ruc.Text, textbox_ruc.Text, priority, clientType, state, textbox_address.Text, textbox_phone.Text, textbox_contact.Text, textbox_email.Text);
            Console.WriteLine(response);
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
            textbox_priority.Text = "Nivel " + trackbar_priority.Value.ToString();
        }
    }
}
