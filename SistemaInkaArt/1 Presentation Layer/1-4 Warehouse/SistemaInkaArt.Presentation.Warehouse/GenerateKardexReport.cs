using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInkaArt.Presentation.Warehouse
{
    public partial class GenerateKardexReport : Form
    {
        public GenerateKardexReport()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            KardexReport kardex_form = new KardexReport();
            kardex_form.Show();
        }
    }
}
