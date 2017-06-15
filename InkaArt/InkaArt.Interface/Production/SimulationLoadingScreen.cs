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
        private Thread simulation_thread;
        
        public SimulationLoadingScreen(Simulation simulation)
        {
            InitializeComponent();
            this.simulation = simulation;
        }


        private void NewSimulation_Load(object sender, EventArgs e)
        {
            simulation_thread = new Thread(simulation.Start);
            simulation_thread.Start();
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cancelar la simulación de la asignación de trabajadores?",
                "Inka Art", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;

            try
            {
                simulation_thread.Abort();
            }
            catch (Exception) { }
            finally
            {
                this.Close();
            }
        }

        private void SimulationLoadingScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cancelar la simulación de la asignación de trabajadores?",
                "Inka Art", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) e.Cancel = true;

            try
            {
                simulation_thread.Abort();
            }
            catch (Exception) { }
        }
    }
}
