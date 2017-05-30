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
    public partial class UserRolesPermissions : Form
    {
        RoleController role;
        DataTable table;
        public UserRolesPermissions()
        {
            InitializeComponent();
            role = new RoleController();

            listRoles();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBoxNewRole.Text, "")) textBoxNewRole.Text = "";
            else role.insertData(textBoxNewRole.Text);
            textBoxNewRole.Text = "";
            listRoles();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            role.updateData(Convert.ToInt32(textBoxIDRole.Text), textBoxNewRole.Text);
            listRoles();
            comboBoxDescription.Text = textBoxNewRole.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxIDRole.Text = table.Rows[comboBoxDescription.SelectedIndex]["idRole"].ToString();
        }

        private void listRoles()
        {
            table = role.showData();
            comboBoxDescription.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBoxDescription.Items.Add(table.Rows[i]["description"]);
            }
        }
    }
}
