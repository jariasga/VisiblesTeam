using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Production
{
    public partial class FinalProducts : Form
    {
        public FinalProducts()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form production_process = new ProductionProcess();
            production_process.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form recipe = new Recipe();
            recipe.Show();
        }

        private void FinalProducts_Load(object sender, EventArgs e)
        {

        }
    }
}
