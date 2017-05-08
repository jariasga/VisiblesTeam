using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Security
{
    public partial class UserMaintenance : Form
    {
        public UserMaintenance()
        {
            InitializeComponent();
        }

        private void UserMaintenance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personDataSet.Turn' table. You can move, or remove it, as needed.
            this.turnTableAdapter.Fill(this.personDataSet.Turn);
            // TODO: This line of code loads data into the 'personDataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.personDataSet.User);
            // TODO: This line of code loads data into the 'personDataSet.Person' table. You can move, or remove it, as needed.
            this.personTableAdapter.Fill(this.personDataSet.Person);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
