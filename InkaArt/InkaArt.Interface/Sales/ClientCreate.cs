using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Sales
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

        private void button_save_Click(object sender, EventArgs e)
        {

        }

        private void personRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (naturalRadio.Checked)
                documentLabel.Text = "DNI";
        }

        private void juridicRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (juridicRadio.Checked)
                documentLabel.Text = "RUC";
        }
    }
}
