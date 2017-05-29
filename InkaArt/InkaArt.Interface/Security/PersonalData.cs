﻿using System;
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
        DataGridView data;
        public PersonalData(DataGridView dataGridV)
        {
            InitializeComponent();
            textBoxName.Text = dataGridV.SelectedRows[0].Cells["firstName"].Value.ToString();
            textBoxLastName.Text = dataGridV.SelectedRows[0].Cells["lastName"].Value.ToString();
            textBoxDNI.Text = dataGridV.SelectedRows[0].Cells["dni"].Value.ToString();
            textBoxPhone.Text = dataGridV.SelectedRows[0].Cells["phone"].Value.ToString();
            textBoxAddress.Text = dataGridV.SelectedRows[0].Cells["address"].Value.ToString();
            textBoxEmail.Text = dataGridV.SelectedRows[0].Cells["email"].Value.ToString();

            
        }
        public PersonalData()
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
        }
       

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonModifyRole_Click(object sender, EventArgs e)
        {
            Form roles = new UserRolesPermissions();
            roles.ShowDialog();
        }
    }
}
