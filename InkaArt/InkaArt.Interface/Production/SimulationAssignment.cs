using InkaArt.Business.Algorithm;
using InkaArt.Classes;
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
    public partial class SimulationAssignment : Form
    {
        private SimulationController simulations;
        private Simulation current_simulation = null;
        private WorkerController workers;
        private RecipeController recipes;
        private JobController jobs;
        private OrderController orders;

        public SimulationAssignment()
        {
            InitializeComponent();

            this.workers = new WorkerController();
            this.recipes = new RecipeController();
            this.jobs = new JobController();
            this.orders = new OrderController();
            this.simulations = new SimulationController();
        }

        private void WorkersAssignment_Load(object sender, EventArgs e)
        {
            try
            {
                this.workers.Load();
                this.recipes.Load();
                this.orders.Load(recipes);
                this.jobs.Load();
                this.simulations.Load(workers, orders, recipes, jobs);

                combo_simulations.DataSource = simulations.BindingList();
                combo_simulations.DisplayMember = "Name";
                combo_simulations.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error grave al cargar de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHandler.WriteLine("Error grave al cargar de base de datos: " + ex.ToString());
            }
        }

        private void ButtonConfigClick(object sender, EventArgs e)
        {
            Form simulation_config = new SimulationConfig(simulations, current_simulation, combo_simulations, workers, orders);
            simulation_config.MdiParent = this.MdiParent;
            simulation_config.Show();
        }

        private void ButtonSaveClick(object sender, EventArgs e)
        {
            if (current_simulation.ID > 0) return;
            if (simulations.Save(current_simulation))
                MessageBox.Show("Simulación guardada", "Guardar Simulación", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show("No se logró guardar la simulación correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButtonReportClick(object sender, EventArgs e)
        {
            if (current_simulation == null) return;
            SimulationReport simulation_report = new SimulationReport(current_simulation);
            simulation_report.Show();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            //general_grid.Rows.Clear();
            //summary_grid.Rows.Clear();
            
            if (simulations.Delete(current_simulation))
                MessageBox.Show("Simulación eliminada", "Eliminar Simulación", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show("No se logró eliminar la simulación correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            simulation_grid.Rows.Clear();

            combo_simulations.DataSource = simulations.BindingList();
            combo_simulations.SelectedItem = null;
            current_simulation = null;
        }

        private void ComboSimulationsSelectedIndexChanged(object sender, EventArgs e)
        {
            current_simulation = (Simulation) combo_simulations.SelectedItem;

            if (current_simulation == null)
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
                button_save.Enabled = (current_simulation.ID <= 0); // solo se puede guardar si es nueva
                button_delete.Enabled = true;
                button_report.Enabled = true;              
            }
            updateGrid();
        }

        public void updateGrid()
        {
            simulation_grid.Rows.Clear();
            if (current_simulation == null) return;

            foreach(Assignment day in current_simulation.Assignments)
            {
                string day_date = day.Date.ToShortDateString();
                foreach (AssignmentLine miniturn in day.AssignmentLinesList)
                {
                    // por ahora solo mostraremos los miniturnos con elementos activos
                    if (miniturn.Worker == null || miniturn.Job == null || miniturn.Recipe == null) continue;

                    DataGridViewRow row = (DataGridViewRow)simulation_grid.Rows[0].Clone();
                    row.Cells[date.Index].Value = day_date;
                    row.Cells[worker.Index].Value = miniturn.Worker.FullName;
                    row.Cells[job.Index].Value = miniturn.Job.Name;
                    row.Cells[recipe.Index].Value = miniturn.Recipe.Description;
                    row.Cells[quantity.Index].Value = miniturn.Produced;
                    row.Cells[index.Index].Value = miniturn.LossIndex;
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
