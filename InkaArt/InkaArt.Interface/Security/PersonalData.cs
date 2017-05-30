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
        private DataRow userRow;
        public PersonalData(DataGridView dataGridV, UserController userC, WorkerController workerC)
        {
            InitializeComponent();
            textBoxName.Text = dataGridV.SelectedRows[0].Cells["firstName"].Value.ToString();
            textBoxLastName.Text = dataGridV.SelectedRows[0].Cells["lastName"].Value.ToString();
            textBoxDNI.Text = dataGridV.SelectedRows[0].Cells["dni"].Value.ToString();
            textBoxPhone.Text = dataGridV.SelectedRows[0].Cells["phone"].Value.ToString();
            textBoxAddress.Text = dataGridV.SelectedRows[0].Cells["address"].Value.ToString();
            textBoxEmail.Text = dataGridV.SelectedRows[0].Cells["email"].Value.ToString();

            worker = workerC;
            user = userC;

            int idUserDataGrid = Int32.Parse(dataGridV.SelectedRows[0].Cells["user"].Value.ToString());
            userRow = user.getUserRowbyID(idUserDataGrid);

            textBoxUsername.Text = userRow["username"].ToString();
            textBoxDescription.Text = userRow["description"].ToString();
            comboBoxUserStatus.Text = userRow["status"].ToString();
            comboBoxUserTurn.Text = userRow["turn"].ToString();

            textBoxUsername.Enabled = false;
            comboBoxUserStatus.Enabled = false;
            comboBoxRoles.Enabled = false;

            buttonSave.Text = "Guardar";
            
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
                string password = "";
                user.showData();
                user.insertData(textBoxUsername.Text, textBoxDescription.Text, /*Int32.Parse(comboBoxUserStatus.SelectedText)*/ 1, ref password);                
                worker.insertData(textBoxName.Text, textBoxLastName.Text, Int32.Parse(textBoxDNI.Text), /*Int32.Parse(comboBoxUserTurn.SelectedText)*/ 1, worker.getUserID(textBoxUsername.Text), Int32.Parse(textBoxPhone.Text), textBoxAddress.Text, textBoxEmail.Text);

                worker.sendPassword(textBoxEmail.Text, textBoxUsername.Text, password);
            }
            else if (string.Equals(buttonSave.Text, "Guardar"))
            {
                user.showData();
                //user.updateData(textBoxUsername.Text, textBoxDescription.Text, /*Int32.Parse(comboBoxUserStatus.SelectedText)*/ 1);
                //worker.updateData(textBoxName.Text, textBoxLastName.Text, Int32.Parse(textBoxDNI.Text), /*Int32.Parse(comboBoxUserTurn.SelectedText)*/ 1, worker.getUserID(textBoxUsername.Text), Int32.Parse(textBoxPhone.Text), textBoxAddress.Text, textBoxEmail.Text);
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
