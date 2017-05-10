using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Presentation.Production
{
    public partial class WorkersAssignment : Form
    {
        public WorkersAssignment()
        {
            InitializeComponent();
        }

        private void ButtonSimulationConfig_Click(object sender, EventArgs e)
        {
            Form simulation_config = new SimulationConfig();
            simulation_config.MdiParent = this.MdiParent;
            simulation_config.Show();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            simulation_grid.Rows.Clear();
        }

        private void WorkersAssignment_Load(object sender, EventArgs e)
        {
            //Temporal
            string[] data = new string[5];
            data[0] = "09/05/2017";
            data[1] = "Tallado de piedras";
            data[2] = "";
            data[3] = "Moldeado de huacos";
            data[4] = "Pintado de retablos";
            simulation_grid.Rows.Add(data);

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Form new_simultation = new NewSimulation();
            new_simultation.MdiParent = this.MdiParent;
            new_simultation.Show();
        }
    }
}
