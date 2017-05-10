using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Presentation.Sales
{
    public partial class ClientCreate : Form
    {
        public ClientCreate()
        {
            InitializeComponent();
        }

        public ClientCreate(string text)
        {
            InitializeComponent();
            Text = text;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {

        }
    }
}
