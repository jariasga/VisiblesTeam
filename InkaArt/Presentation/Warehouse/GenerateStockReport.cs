using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Presentation.Warehouse
{
    public partial class GenerateStockReport : Form
    {
        public GenerateStockReport()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            StockReport stock_form = new StockReport();
            stock_form.Show();
        }
    }
}
