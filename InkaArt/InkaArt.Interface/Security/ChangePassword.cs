using System;
using System.Windows.Forms;
using System.Data;
using InkaArt.Business.Security;

namespace InkaArt.Interface.Security
{
    public partial class ChangePassword : Form
    {
        UserController user;
        DataTable userTable;
        DataRow row;
        public ChangePassword()
        {
            InitializeComponent();
            user = new UserController();
            userTable = user.showData();
            row = user.getUserRowbyID(LoginController.userID);
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            LoginController verify = new LoginController();
            bool pass = verify.checkCredentials(LoginController.userName, textbox_password_old.Text);
            if (pass)
            {
                if (string.Equals(textbox_password_new_1.Text, textbox_password_new_2.Text))
                {
                    user.updatePassword(LoginController.userID, textbox_password_new_2.Text);
                    DialogResult goodPassword = MessageBox.Show("Se cambió la contraseña", "Inka Art",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    DialogResult badPassword = MessageBox.Show("Las contraseñas no coinciden", "Inka Art",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textbox_password_new_1.Text = "";
                    textbox_password_new_2.Text = "";
                }
            }
            else
            {
                textbox_password_old.Text = "";
                DialogResult badPassword = MessageBox.Show("La contraseña ingresada es incorrecta", "Inka Art",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
