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
    public partial class ClientsIndex : Form
    {
        public ClientsIndex()
        {
            InitializeComponent();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            ClientCreate create_form = new ClientCreate();
            create_form.Show();
        }

        private void grid_clients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ClientShow show_form = new ClientShow();
            show_form.Show();
        }
    }
}
