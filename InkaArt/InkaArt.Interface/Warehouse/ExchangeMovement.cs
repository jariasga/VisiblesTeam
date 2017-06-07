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
    public partial class ExchangeMovement : Form
    {
        public ExchangeMovement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form new_warehouse_window = new WarehouseSearchMovement(textBox5, textBox6);
            new_warehouse_window.Show();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            //Form new_warehouse_window = new Form1(ref textBox1,ref textBox2,ref textBox4);
            Form new_warehouse_window = new Form1(textBox1, textBox2, textBox4);
            new_warehouse_window.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
