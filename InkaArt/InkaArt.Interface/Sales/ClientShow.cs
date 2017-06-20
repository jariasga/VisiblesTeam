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
    public partial class ClientShow : Form
    {
        int clientId;
        bool first;
        ClientController clientController;
        public ClientShow(string id)
        {
            InitializeComponent();
            clientId = int.Parse(id);
            first = true;
            clientController = new ClientController();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void ClientShow_Load(object sender, EventArgs e)
        {
            DataTable clientObject = clientController.GetClients(clientId.ToString());
            populateFields(clientObject);
        }

        private void populateFields(DataTable clientObject)
        {
            foreach (DataRow row in clientObject.Rows)
            {
                radio_active.Checked = row["status"].ToString().Equals("1");
                radio_inactive.Checked = row["status"].ToString().Equals("0");
                radio_inter.Checked = row["type"].ToString().Equals("1");
                radio_national.Checked = row["type"].ToString().Equals("0");
                radio_juridic.Checked = row["clientType"].ToString().Equals("0");
                radio_natural.Checked = row["clientType"].ToString().Equals("1");
                textbox_address.Text = row["address"].ToString();
                textbox_doc.Text = row["clientType"].Equals("0") ? row["ruc"].ToString() : row["dni"].ToString();
                textbox_contact.Text = row["contactName"].ToString();
                textbox_name.Text = row["name"].ToString();
                textbox_email.Text = row["email"].ToString();
                textbox_phone.Text = row["phone"].ToString();
                textbox_priority.Text = row["priority"].ToString();
                trackbar_priority.Value = int.Parse(row["priority"].ToString());
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            List<string> client = new List<string>();
            client.Add(clientId.ToString());
            clientController.deleteClients(client);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (first)
            {
                enableFields();
                button_edit.Text = "🖫 Guardar";
            }
            else
            {
                string personType = "-1", clientType = "-1", state = "-1";
                if (radio_juridic.Checked) personType = "0";
                if (radio_natural.Checked) personType = "1";
                if (radio_national.Checked) clientType = "0";
                if (radio_inter.Checked) clientType = "1";
                if (radio_inactive.Checked) state = "0";
                if (radio_active.Checked) state = "1";
                string priority = textbox_priority.Text;
                string messageResponse = clientController.makeValidations(personType, textbox_name.Text, textbox_doc.Text, textbox_doc.Text, priority, clientType, state, textbox_address.Text, textbox_phone.Text, textbox_contact.Text, textbox_email.Text);
                if (messageResponse.Equals("OK"))
                {
                    int response = clientController.UpdateClient(clientId.ToString(), personType, textbox_name.Text, textbox_doc.Text, textbox_doc.Text, priority, clientType, state, textbox_address.Text, textbox_phone.Text, textbox_contact.Text, textbox_email.Text);
                    if (response >= 0)
                    {
                        MessageBox.Show(this, "El cliente ha sido actualizado correctamente.", "Editar cliente", MessageBoxButtons.OK);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show(this, messageResponse, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void enableFields()
        {
            first = false;
            radio_active.Enabled = true;
            radio_inactive.Enabled = true;
            radio_inter.Enabled = true;
            radio_juridic.Enabled = true;
            radio_national.Enabled = true;
            radio_natural.Enabled = true;
            textbox_address.Enabled = true;
            textbox_contact.Enabled = true;
            textbox_doc.Enabled = true;
            textbox_email.Enabled = true;
            textbox_name.Enabled = true;
            textbox_phone.Enabled = true;
            textbox_priority.Enabled = true;
            trackbar_priority.Enabled = true;
        }

        private void radio_juridic_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_juridic.Checked)
                documentLabel.Text = "RUC";
        }

        private void radio_natural_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_natural.Checked)
                documentLabel.Text = "DNI";
        }
    }
}
