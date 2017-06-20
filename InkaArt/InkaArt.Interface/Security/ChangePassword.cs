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
            bool active;
            LoginController verify = new LoginController();
            bool pass = verify.checkCredentials(LoginController.userName, textbox_password_old.Text, out active);
            if (pass)
            {
                if (string.Equals(textbox_password_new_1.Text, textbox_password_new_2.Text) & verifyPasswordRequeriments())
                {
                    user.updatePassword(LoginController.userID, textbox_password_new_2.Text, false);
                    DialogResult goodPassword = MessageBox.Show("Se cambió la contraseña", "Inka Art",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    DialogResult badPassword = MessageBox.Show("Las contraseñas no coinciden y/o no cumple con los requisitos", "Inka Art",
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
            
    

        private bool verifyPasswordRequeriments()
        {
            bool upper = false, lower = false, number = false, lengh = false;
            char[] pass = textbox_password_new_1.Text.ToCharArray();

            for (int i = 0; i < pass.GetLength(0); i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textbox_password_new_1.Text, "(?:[A-Z])")) upper = true;
                if (System.Text.RegularExpressions.Regex.IsMatch(textbox_password_new_1.Text, "(?:[a-z])")) lower = true;
                if (System.Text.RegularExpressions.Regex.IsMatch(textbox_password_new_1.Text, "(?:[0-9])")) number = true;
                if (textbox_password_new_1.Text.Length > 7) lengh = true;
            }
            return upper & lower & number & lengh & (pass.GetLength(0) > 5);
        }

        private void textbox_password_new_1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textbox_password_new_1.Text, "(?:[A-Z])")) labelUpperChar.ForeColor = System.Drawing.Color.Green;
            else labelUpperChar.ForeColor = System.Drawing.Color.Black;

            if (System.Text.RegularExpressions.Regex.IsMatch(textbox_password_new_1.Text, "(?:[a-z])")) labelLowerChar.ForeColor = System.Drawing.Color.Green;
            else labelLowerChar.ForeColor = System.Drawing.Color.Black;

            if (System.Text.RegularExpressions.Regex.IsMatch(textbox_password_new_1.Text, "(?:[0-9])")) labelNumberChar.ForeColor = System.Drawing.Color.Green;
            else labelNumberChar.ForeColor = System.Drawing.Color.Black;

            if (textbox_password_new_1.Text.Length > 7) label8Char.ForeColor = System.Drawing.Color.Green;
            else label8Char.ForeColor = System.Drawing.Color.Black;
        }
    }
}
