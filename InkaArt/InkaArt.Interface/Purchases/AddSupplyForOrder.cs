using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Purchases
{
    public partial class AddSupplyForOrder : Form
    {
        public AddSupplyForOrder()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_return(object sender, EventArgs e)
        {
            this.textBox_id.Text = "";
            this.textBox_name.Text = "";
            this.dataGridView1.Rows.Clear();
            this.Close();
        }

        private void button_add(object sender, EventArgs e)
        {
            this.textBox_id.Text = "";
            this.textBox_name.Text = "";
            this.dataGridView1.Rows.Clear();
            this.Close();
        }
    }
}
