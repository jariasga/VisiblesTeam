using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InkaArt.Interface.Production;

namespace InkaArt
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button_ratio_Click(object sender, EventArgs e)
        {
            Form ratio = new RegisterRatio();
            ratio.Show();
        }

        private void button_config_Click(object sender, EventArgs e)
        {
            Form config = new SimulationConfig();
            config.Show();
        }

        private void button_simulation_Click(object sender, EventArgs e)
        {
            Form simulation = new NewSimulation();
            simulation.Show();
        }
    }
}
