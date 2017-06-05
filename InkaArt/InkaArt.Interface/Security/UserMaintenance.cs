using InkaArt.Business.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Security
{
    public partial class UserMaintenance : Form
    {
        WorkerController worker;
        UserController user;
        RoleController role;

        public UserMaintenance()
        {
            InitializeComponent();

            worker = new WorkerController();
            user = new UserController();
            role = new RoleController();

            listUsers();
        }

        public void listUsers()
        {
            dataGridViewUserMaintenance.DataSource = worker.showData();

            dataGridViewUserMaintenance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;

            dataGridViewUserMaintenance.Columns["id_worker"].HeaderText = "ID";
            dataGridViewUserMaintenance.Columns["first_name"].HeaderText = "Nombre";
            dataGridViewUserMaintenance.Columns["last_name"].HeaderText = "Apellido";
            dataGridViewUserMaintenance.Columns["dni"].HeaderText = "DNI";
            dataGridViewUserMaintenance.Columns["phone"].HeaderText = "Teléfono";
            dataGridViewUserMaintenance.Columns["address"].HeaderText = "Dirección";
            dataGridViewUserMaintenance.Columns["email"].HeaderText = "E-Mail";
            dataGridViewUserMaintenance.Columns["id_user"].Visible = false;
            dataGridViewUserMaintenance.Columns["turn"].Visible = false;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Form personalData = new PersonalData(user, worker, role);
            personalData.ShowDialog(this);
            listUsers();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            Form personalData = new PersonalData(dataGridViewUserMaintenance, user, worker, role);
            personalData.ShowDialog(this);
            listUsers();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMassiveUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Users File";
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
                user.massiveUpload(dialog.FileName, worker);     
        }
    }
}
