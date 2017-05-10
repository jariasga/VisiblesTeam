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
    public partial class ClientOrderShow : Form
    {
        public ClientOrderShow()
        {
            InitializeComponent();
        }

        private void ClientOrderShow_Load(object sender, EventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {

        }

        private void button_devolution_Click(object sender, EventArgs e)
        {
            ClientOrderDevolution dev_form = new ClientOrderDevolution();
            dev_form.Show();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            ClientOrderCreate edit_form = new ClientOrderCreate("Editar Cliente");
            Close();
            edit_form.Show();
        }

        private void button_doc_Click(object sender, EventArgs e)
        {

        }
    }
}
