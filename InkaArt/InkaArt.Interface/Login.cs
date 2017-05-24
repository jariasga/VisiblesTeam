using encription_SHA256;
using System;
using System.Windows.Forms;
using InkaArt.Data.Security;
using Npgsql;
using System.Data;

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
            else
            {
                DialogResult badPassword = MessageBox.Show("El usuario/password ingresado es incorrecto", "Inka Art",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkCredentials()
        {
            bool verified = false;
            SHA_2 sha = new SHA_2();
            string key = sha.encrypt(textbox_password.Text);

            UserData user = new UserData();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
            DataSet data = new DataSet();

            user.connect();
            adap = user.userAdapter();
            adap.SelectCommand.Parameters[0].NpgsqlValue = textbox_user.Text;
            
            data = user.getData(adap);

            //  Read data from DB
            int rows = data.Tables[0].Rows.Count;
            string userDB, keyDB;

            if (rows > 0)
            {
                userDB = data.Tables[0].Rows[0][3].ToString();
                keyDB = data.Tables[0].Rows[0][4].ToString(); ;
            }
            else
            {
                userDB = "wrongUsername";
                keyDB = "badPassword";
            }
            

            if (string.Equals(key, keyDB) & string.Equals(textbox_user.Text, userDB)){
                //  ToDo - GET ROLES

                //  GRANT ACCESS
                verified = true;
            }
            return verified;
        }
    }
}
