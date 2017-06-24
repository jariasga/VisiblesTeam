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
        private Simulation current_simulation;
        private WorkerController workers;
        private OrderController orders;

        public WorkersAssignment()
        {
            InitializeComponent();

            this.workers = new WorkerController();
            this.orders = new OrderController();
            this.simulations = new SimulationController();
        }

        private void WorkersAssignment_Load(object sender, EventArgs e)
        {
            this.workers.Load();
            this.orders.Load();
            this.simulations.Load();

            combo_simulations.DataSource = simulations.BindingList();
            combo_simulations.DisplayMember = "Name";
            combo_simulations.SelectedIndex = -1;
        }

        private void ButtonConfigClick(object sender, EventArgs e)
        {
            Simulation simulation = (Simulation)combo_simulations.SelectedItem;

            Form simulation_config = new SimulationConfig(simulations, simulation, combo_simulations, workers, orders);
            simulation_config.MdiParent = this.MdiParent;
            simulation_config.Show();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            //Guardar simulación en BD
            Simulation simulation = (Simulation)combo_simulations.SelectedItem;
            simulation.save();
        }

        private void ButtonReportClick(object sender, EventArgs e)
        {
            Simulation simulation = (Simulation)combo_simulations.SelectedItem;
            SimulationReport simulation_report = new SimulationReport(simulation);
            simulation_report.Show();
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

            if (combo_simulations.SelectedIndex < 0 || simulation == null)
            {
                button_config.Text = "+ Nueva simulación";
                button_config.BackColor = Color.SteelBlue;
                button_save.Enabled = false;
                button_delete.Enabled = false;
                button_report.Enabled = false;
            }
            else
            {
                button_config.Text = "Ver detalles de asignación";
                button_config.BackColor = Color.Gray;
                button_save.Enabled = true;
                button_delete.Enabled = true;
                button_report.Enabled = true;
                updateGrid(simulation);
            }
        }

        public void updateGrid(Simulation simulation)
        {
            foreach(Assignment day in simulation.Assignments)
            {
                foreach(AssignmentLine miniturn in day.toList())
                {
                    DataGridViewRow row = (DataGridViewRow)simulation_grid.Rows[0].Clone();
                    row.Cells[worker.Index].Value = miniturn.Worker.FullName;
                    row.Cells[job.Index].Value = miniturn.Job.Name;
                    row.Cells[recipe.Index].Value = miniturn.Recipe.Description;
                    row.Cells[quantity.Index].Value = miniturn.Produced;
                    row.Cells[index.Index].Value = simulation.getLossIndex(miniturn);
                    simulation_grid.Rows.Add(row);
                }
            }
        }

        private void simulation_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combo_simulations_MouseClick(object sender, MouseEventArgs e)
        {
            combo_simulations.DataSource = simulations.BindingList();
        }
    }
}
