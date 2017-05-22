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
        
        private void button_search_Click(object sender, EventArgs e)
        {            

        }

        private void button_create_Click(object sender, EventArgs e)
        {
            ClientOrderCreate create_form = new ClientOrderCreate();
            create_form.Show();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }

        private void grid_orders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientOrderShow show_form = new ClientOrderShow();
            show_form.Show();
        }
    }
}
