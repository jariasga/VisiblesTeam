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
        private OrderController orders;

        public WorkersAssignment()
        {
            InitializeComponent();

            workers = new WorkerController();
            workers.Load();
            orders = new OrderController();
            orders.Load();
            simulations = new SimulationController();

            // set elements
            combo_simulations.DataSource = simulations.BindingList();
            combo_simulations.DisplayMember = "Name";
            combo_simulations.SelectedIndex = -1;
            
            button_config.Text = "+ Crear";
            button_save.Enabled = false;
            button_start.Enabled = false;
            button_delete.Enabled = false;
            button_report.Enabled = false;
        }

        private void WorkersAssignment_Load(object sender, EventArgs e)
        {
            //Temporal
            //string[] data = new string[5];
            //data[0] = "09/05/2017";
            //data[1] = "Tallado de piedras";
            //data[2] = "";
            //data[3] = "Moldeado de huacos";
            //data[4] = "Pintado de retablos";
            //simulation_grid.Rows.Add(data);

        }

        private void ButtonStartClick(object sender, EventArgs e)
        {
            Simulation simulation = (Simulation) combo_simulations.SelectedItem;
            if (simulation == null) return;

            Form new_simultation = new NewSimulation();
            new_simultation.MdiParent = this.MdiParent;
            new_simultation.Show();
            simulation.Start();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            //Guardar simulación en BD
            Simulation simulation = (Simulation)combo_simulations.SelectedItem;
            simulation.Save();
        }

        private void ButtonConfigClick(object sender, EventArgs e)
        {
            Simulation simulation = (Simulation)combo_simulations.SelectedItem;
            Form simulation_config = new SimulationConfig(simulations, simulation, combo_simulations, workers, orders);
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
            //general_grid.Rows.Clear();
            simulation_grid.Rows.Clear();
            //summary_grid.Rows.Clear();
            combo_simulations.SelectedIndex = -1;

            Simulation simulation = (Simulation)combo_simulations.SelectedItem;
            simulations.Delete(simulation);
            combo_simulations.DataSource = simulations.BindingList();
        }

        private void ComboSimulationsSelectedIndexChanged(object sender, EventArgs e)
        {
            Simulation simulation = (Simulation) combo_simulations.SelectedItem;

            if (combo_simulations.SelectedIndex == -1 || simulation == null)
            {
                button_config.Text = "+ Crear";
                button_save.Enabled = false;
                button_start.Enabled = false;
                button_delete.Enabled = false;
                button_report.Enabled = false;
            }
            else
            {
                button_config.Text = "🖉 Editar";
                button_save.Enabled = true;
                button_start.Enabled = true;
                button_delete.Enabled = true;
                button_report.Enabled = true;
                if (simulation.AssignmentsToList().Count > 0)
                {
                    simulation_grid.DataSource = simulation.AssignmentsToList().Select(o => new
                    { Column1 = o.Date, Column2 = o.Worker.FullName, Column3 = o.Job.Name, Column4 = o.Recipe.Description }).ToList();
                }
            }
        }
        
        private void simulation_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupbox_summary_Enter(object sender, EventArgs e)
        {

        }
    }
}
