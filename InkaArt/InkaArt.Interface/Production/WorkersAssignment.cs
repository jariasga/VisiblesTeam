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
        private Simulation current_simulation = null;
        private WorkerController workers;
        private RecipeController recipes;
        private OrderController orders;

        public WorkersAssignment()
        {
            InitializeComponent();

            this.workers = new WorkerController();
            this.recipes = new RecipeController();
            this.orders = new OrderController();
            this.simulations = new SimulationController();
        }

        private void WorkersAssignment_Load(object sender, EventArgs e)
        {
            this.workers.Load();
            this.orders.Load(recipes);
            this.simulations.Load();

            combo_simulations.DataSource = simulations.BindingList();
            combo_simulations.DisplayMember = "Name";
            combo_simulations.SelectedIndex = -1;
        }

        private void ButtonConfigClick(object sender, EventArgs e)
        {
            Form simulation_config = new SimulationConfig(simulations, current_simulation, combo_simulations, workers, orders);
            simulation_config.MdiParent = this.MdiParent;
            simulation_config.Show();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            current_simulation.save();
        }

        private void ButtonReportClick(object sender, EventArgs e)
        {
            SimulationReport simulation_report = new SimulationReport(current_simulation);
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
            current_simulation = (Simulation) combo_simulations.SelectedItem;

            if (combo_simulations.SelectedIndex < 0 || current_simulation == null)
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
                updateGrid();
            }
        }

        public void updateGrid()
        {
            if (current_simulation == null) return;
            foreach(Assignment day in current_simulation.Assignments)
            {
                foreach(AssignmentLine miniturn in day.toList())
                {
                    DataGridViewRow row = (DataGridViewRow)simulation_grid.Rows[0].Clone();
                    row.Cells[worker.Index].Value = miniturn.Worker.FullName;
                    row.Cells[job.Index].Value = miniturn.Job.Name;
                    row.Cells[recipe.Index].Value = miniturn.Recipe.Description;
                    row.Cells[quantity.Index].Value = miniturn.Produced;
                    row.Cells[index.Index].Value = current_simulation.getLossIndex(miniturn);
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
