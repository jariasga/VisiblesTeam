using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InkaArt.Data;

namespace InkaArt.Interface.Security
{
    public partial class UserMaintenance : Form
    {
        public UserMaintenance()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void begin() {

        }
    }
}
