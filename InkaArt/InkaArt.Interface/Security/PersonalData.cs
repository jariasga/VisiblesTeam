using InkaArt.Business.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Security
{
    public partial class PersonalData : Form
    {
        private WorkerController worker;
        private UserController user;
        public PersonalData(DataGridView dataGridV, UserController userC, WorkerController workerC)
        {
            InitializeComponent();
            textBoxName.Text = dataGridV.SelectedRows[0].Cells["firstName"].Value.ToString();
            textBoxLastName.Text = dataGridV.SelectedRows[0].Cells["lastName"].Value.ToString();
            textBoxDNI.Text = dataGridV.SelectedRows[0].Cells["dni"].Value.ToString();
            textBoxPhone.Text = dataGridV.SelectedRows[0].Cells["phone"].Value.ToString();
            textBoxAddress.Text = dataGridV.SelectedRows[0].Cells["address"].Value.ToString();
            textBoxEmail.Text = dataGridV.SelectedRows[0].Cells["email"].Value.ToString();

            textBoxUsername.Enabled = false;
            comboBoxUserStatus.Enabled = false;
            comboBoxRoles.Enabled = false;

            buttonSave.Text = "Guardar";
            worker = workerC;
            user = userC;
        }
        public PersonalData(UserController userC, WorkerController workerC)
        {
            InitializeComponent();
            textBoxName.Text = "";
            textBoxLastName.Text = "";
            textBoxDNI.Text = "";
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
            textBoxEmail.Text = "";

            textBoxUsername.Enabled = true;
            textBoxUsername.Text = "";
            comboBoxUserStatus.Enabled = true;
            comboBoxUserStatus.Text = "";
            comboBoxRoles.Enabled = true;
            comboBoxRoles.Text = "";

            buttonSave.Text = "Crear";
            worker = workerC;
            user = userC;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.Equals(buttonSave.Text, "Crear"))
            {
                user.insertData(textBoxUsername.Text, textBoxDescription.Text, Int32.Parse(comboBoxUserStatus.SelectedText), textBoxPassword.Text);
                worker.insertData(textBoxName.Text, textBoxLastName.Text, Int32.Parse(textBoxDNI.Text), Int32.Parse(comboBoxUserTurn.SelectedText), 1, Int32.Parse(textBoxPhone.Text), textBoxAddress.Text, textBoxEmail.Text);
            }
            else if (string.Equals(buttonSave.Text, "Guardar"))
            {

            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
