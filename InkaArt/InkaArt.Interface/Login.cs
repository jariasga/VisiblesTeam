using System;
using System.Windows.Forms;
using InkaArt.Business.Security;
using System.Data;

namespace InkaArt.Interface
{
    public partial class Login : Form
    {
        private LoginController control;
        public Login()
        {
            InitializeComponent();
            control = new LoginController();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            bool pass;
            pass = control.checkCredentials(textbox_user.Text, textbox_password.Text);

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
                DialogResult badPassword = MessageBox.Show("El usuario/contraseña ingresado(a) es incorrecto(a)", "Inka Art",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_forgot_Click(object sender, EventArgs e)
        {
            if (string.Equals(textbox_user.Text, ""))
            {
                DialogResult insertUser = MessageBox.Show("Por favor ingrese un usuario", "Inka Art", 
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
            }
            else
            {
                DialogResult resetPassword = MessageBox.Show("Desea enviar una nueva contraseña a su correo?", "Inka Art", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resetPassword == DialogResult.Yes)
                {
                    control.sendResetPassword(textbox_user.Text);
                    DialogResult infor = MessageBox.Show("Si el usuario se encuentra registrado, recibirá" +
                        " un email con su nueva clave", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                    
            }
        }
    }
}
