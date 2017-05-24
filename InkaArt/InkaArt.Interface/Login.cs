using System;
using System.Windows.Forms;
using InkaArt.Business.Security;

namespace InkaArt.Interface
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            var auth = new AuthenticationController();
            bool pass = auth.CheckCredentials(textbox_user.Text,textbox_password.Text);

            if (pass)
            {
                this.textbox_user.Clear();
                this.textbox_password.Clear();
                //  ToDo - Roles

                Form menu = new Menu(this);
                this.Hide();
                menu.Show();
            }
            else
            {
                DialogResult badPassword = MessageBox.Show("El usuario/password ingresado es incorrecto", "Inka Art",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
