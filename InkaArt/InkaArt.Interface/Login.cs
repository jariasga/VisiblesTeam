using encription_SHA256;
using System;
using System.Windows.Forms;


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
            bool pass;
            pass = checkCredentials();

            if (pass)
            {
                this.textbox_user.Clear();
                this.textbox_password.Clear();
                //  ToDo - Roles

                Form menu = new Menu(this);
                this.Hide();
                menu.Show();
            }
        }

        private bool checkCredentials()
        {
            bool verified = false;
            SHA_2 sha = new SHA_2();
            string key = sha.encrypt(textbox_password.Text);

            //  Read data from DB
            string userDB = "admin";
            string keyDB = "e00dd57436b2905f5c424528dc2e8bbc08e04a61ef20b13e6765c4ff7f6134c";   //  SHA256 for "admin" password

            if (string.Equals(key, keyDB) & string.Equals(textbox_user.Text, userDB)){
                //  ToDo - GET ROLES

                //  GRANT ACCESS
                verified = true;
            }
            return verified;
        }
    }
}
