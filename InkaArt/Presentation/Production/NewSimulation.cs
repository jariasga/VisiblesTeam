using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Presentation.Production
{
    public partial class NewSimulation : Form
    {
        public NewSimulation()
        {
            InitializeComponent();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
