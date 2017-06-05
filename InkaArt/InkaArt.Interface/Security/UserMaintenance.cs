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
        DataTable workerTable;

        public UserMaintenance()
        {
            InitializeComponent();

            worker = new WorkerController();
            user = new UserController();
            role = new RoleController();

            workerTable = new DataTable();
            showTable();
        }
        
        private void buttonNew_Click(object sender, EventArgs e)
        {
            Form personalData = new PersonalData(user, worker, role);
            personalData.ShowDialog(this);
            showTable();
            
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (dataGridViewUserMaintenance.Rows.Count > 0)
            {
                Form personalData = new PersonalData(dataGridViewUserMaintenance, user, worker, role);
                personalData.ShowDialog(this);
                showTable();
            }
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

        private void dataGridViewUserMaintenance_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form personalData = new PersonalData(dataGridViewUserMaintenance, user, worker, role);
            personalData.ShowDialog(this);
            showTable();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            showTable();
        }

        public void filter()
        {
            DataRow[] rows;
            workerTable = worker.showData();
            rows = workerTable.Select("first_name LIKE '%" + textBoxNameFilter.Text + "%' AND last_name LIKE '%" + textBoxLastnameFilter.Text + "%'");
            if (rows.Any()) workerTable = rows.CopyToDataTable();
            else workerTable.Rows.Clear();
            string sortQuery = string.Format("id_worker");
            workerTable.DefaultView.Sort = sortQuery;
        }

        public void showTable()
        {
            filter();
            dataGridViewUserMaintenance.DataSource = workerTable;

            dataGridViewUserMaintenance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridViewUserMaintenance.Columns["id_worker"].HeaderText = "ID";
            dataGridViewUserMaintenance.Columns["first_name"].HeaderText = "Nombre";
            dataGridViewUserMaintenance.Columns["last_name"].HeaderText = "Apellido";
            dataGridViewUserMaintenance.Columns["dni"].HeaderText = "DNI";
            dataGridViewUserMaintenance.Columns["phone"].HeaderText = "Teléfono";
            dataGridViewUserMaintenance.Columns["address"].HeaderText = "Dirección";
            dataGridViewUserMaintenance.Columns["email"].HeaderText = "E-Mail";
            dataGridViewUserMaintenance.Columns["id_user"].Visible = false;
            dataGridViewUserMaintenance.Columns["turn"].Visible = false;

            dataGridViewUserMaintenance.AllowUserToAddRows = false;
            dataGridViewUserMaintenance.AllowUserToDeleteRows = false;
            dataGridViewUserMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUserMaintenance.MultiSelect = false;
        }
    }
}
