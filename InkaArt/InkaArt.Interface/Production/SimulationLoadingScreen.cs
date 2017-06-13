using InkaArt.Business.Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Production
{
    public partial class SimulationLoadingScreen : Form
    {
        private Simulation simulation;
        private bool canceled;

        public SimulationLoadingScreen(Simulation simulation)
        {
            InitializeComponent();
            this.simulation = simulation;
            this.canceled = false;
        }


        private void NewSimulation_Load(object sender, EventArgs e)
        {
            Thread simulation_thread = new Thread(simulation.Start);
            simulation_thread.Start();
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cancelar la simulación de la asignación de trabajadores?",
                "Inka Art", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) this.canceled = true;
        }
    }
}
