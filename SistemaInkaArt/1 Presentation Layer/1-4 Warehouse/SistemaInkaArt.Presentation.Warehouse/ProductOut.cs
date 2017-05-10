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
    public partial class ProductOut : Form
    {
        public ProductOut()
        {
            InitializeComponent();
        }


        private void button_register_out_Click(object sender, EventArgs e)
        {
            ProductRegisterOutTotal product_registerT_form = new ProductRegisterOutTotal();
            product_registerT_form.Show();
        }

        private void gridProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductRegisterOut product_register_form = new ProductRegisterOut();
            product_register_form.Show();
        }
    }
}
