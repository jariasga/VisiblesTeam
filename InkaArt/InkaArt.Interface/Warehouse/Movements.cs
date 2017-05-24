using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Warehouse
{
    public partial class Movements : Form
    {
        public Movements()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form sales_out = new InkaArt.Interface.Warehouse.SalesOut();
            sales_out.Show();
        }
    }
}
