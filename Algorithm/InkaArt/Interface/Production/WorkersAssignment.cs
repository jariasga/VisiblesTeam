using InkaArt.Business.Algorithm;
using InkaArt.Data.Algorithm;
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
    public partial class WorkersAssignment : Form
    {
        private SimulationController simulations;
        private WorkerController workers;

        public WorkersAssignment()
        {
            InitializeComponent();

            workers = new WorkerController();
            workers.Load();
            simulations = new SimulationController();
            simulations.Add(new Simulation("simu 1", 0, 0, 0, 0, 0, 0, null)); // prueba
            
            combo_simulations.DataSource = simulations.BindingList();
            combo_simulations.DisplayMember = "Name";
            combo_simulations.SelectedIndex = -1;
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
                
        private void ButtonStartClick(object sender, EventArgs e)
        {
            Form new_simultation = new NewSimulation();
            new_simultation.MdiParent = this.MdiParent;
            new_simultation.Show();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            //Guardar simulación en BD

        }

        private void ButtonConfigClick(object sender, EventArgs e)
        {
            Simulation simulation = (Simulation) combo_simulations.SelectedItem;
            Form simulation_config = new SimulationConfig(simulations, simulation, combo_simulations, workers);
            simulation_config.MdiParent = this.MdiParent;
            simulation_config.Show();
        }

        private void ButtonReportClick(object sender, EventArgs e)
        {
            //GenerateSimulationReport simulation_report = new GenerateSimulationReport();
            //simulation_report.Show();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            general_grid.Rows.Clear();
            simulation_grid.Rows.Clear();
            summary_grid.Rows.Clear();
        }

        private void ComboSimulationsSelectedIndexChanged(object sender, EventArgs e)
        {
            Simulation simulation = (Simulation)combo_simulations.SelectedItem;

            if (simulation == null)
            {
                button_config.Text = "+ Crear";
            }
            else
            {
                button_config.Text = "Configuración";
                // completar asignaciones
            }
        }
        
    }
}
