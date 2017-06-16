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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Interface.Production
{
    public partial class SimulationExecution : Form
    {
        private Simulation simulation;
        private Thread simulation_thread;
        private int[] elapsed_seconds;

        public SimulationExecution(Simulation simulation)
        {
            InitializeComponent();
            this.simulation = simulation;
            this.elapsed_seconds = new int[1];
        }

        private void NewSimulation_Load(object sender, EventArgs e)
        {
            simulation_thread = new Thread(() => ExecuteWorkersAssignmentSimulation(simulation));
            simulation_thread.Start();
        }

        private void ExecuteWorkersAssignmentSimulation(Simulation simulation)
        {
            this.timer.Start();

            this.label_state.Text = "Estado de la simulación: Cargando datos...";
            this.progress_bar.Value = 0;

            //Carga de controladores 

            ProcessController processes = new ProcessController();
            processes.Load();
            this.progress_bar.Value += 20;
            JobController jobs = new JobController();
            jobs.Load();
            this.progress_bar.Value += 20;
            RecipeController recipes = new RecipeController();
            recipes.Load();
            this.progress_bar.Value += 20;
            IndexController indexes = new IndexController();
            indexes.Load();
            this.progress_bar.Value += 20;
            indexes.CalculateIndexes(jobs, recipes, simulation);
            this.progress_bar.Value += 20;

            this.label_state.Text = "Estado de la simulación: Asignando trabajadores...";
            this.progress_bar.Value = 0;

            //Algoritmo GRASP

            Grasp grasp = new Grasp(simulation, jobs, recipes, indexes);
            List<Assignment> assignments = new List<Assignment>();

            for (int day = 0; elapsed_seconds[0] < Simulation.LimitTime && day < simulation.Days; day++)
            {
                assignments.Add(grasp.ExecuteGraspAlgorithm(day, elapsed_seconds));
                this.progress_bar.Value += Convert.ToInt32(100.0 / day);
            }

            this.label_state.Text = "Estado de la simulación: Optimizando la asignación de trabajadores...";
            this.progress_bar.Value = 0;

            //Algoritmo de Búsqueda Tabú

            //TabuSearch tabu = new TabuSearch(simulation, assignments);
            //tabu.run();
            //assignments = tabu.BestSolution;

            //Finalizar
            MessageBox.Show("¡Se realizó la asignación con éxito!", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.elapsed_seconds[0]++;
            this.label_time.Text = string.Format("Tiempo: {0:2}:{1:2} s", elapsed_seconds[0] / 60, elapsed_seconds[0] % 60);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            catch (Exception ex)
            {
                LogHandler.WriteLine(ex.Message);
            }
        }
    }
}
