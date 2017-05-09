using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInkaArt.Presentation.Sales
{
    public partial class ClientOrderIndex : Form
    {
        public ClientOrderIndex()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClientOrderCreate form = new ClientOrderCreate();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
