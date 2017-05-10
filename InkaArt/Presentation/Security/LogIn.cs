using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Presentation.Security
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            Form menu = new Menu(this);
            this.Hide();
            this.textbox_user.Clear();
            this.textbox_password.Clear();
            menu.Show();
        }
        
    }
}
