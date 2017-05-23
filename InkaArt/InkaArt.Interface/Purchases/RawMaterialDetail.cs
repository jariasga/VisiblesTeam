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
    public partial class RawMaterialDetail : Form
    {
        public RawMaterialDetail()
        {
            InitializeComponent();
        }

        private void button_create(object sender, EventArgs e)
        {
            Form new_unit_of_measurement = new UnitOfMeasurement();
            new_unit_of_measurement.Show();
        }

        private void button_save(object sender, EventArgs e)
        {
            /*closing*/
            this.textBox_id.Text = "";
            this.textBox_name.Text = "";
            this.textBox_description.Text = "";
            this.textBox_averagePrice.Text = "0";
            this.comboBox_unit.Text = "";
            this.comboBox_status.Text = "";
            this.Close();

        }
    }
}
