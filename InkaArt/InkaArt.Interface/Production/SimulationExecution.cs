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
        private int elapsed_seconds;
        private WorkerController workers;

        public SimulationExecution(Simulation simulation, WorkerController workers)
        {
            InitializeComponent();
            this.simulation = simulation;
            this.elapsed_seconds = 0;
            this.workers = workers;
        }

        private void NewSimulation_Load(object sender, EventArgs e)
        {
            background_simulation.RunWorkerAsync();
        }

        /*************************** Subproceso de simulación de asignación de trabajadores ***************************/

        private void background_simulation_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker background_worker = sender as BackgroundWorker;
            this.timer.Start();

            //label_state(1, "Estado de la simulación: Cargando datos...");
            //progress_bar_reset();

            //Carga de controladores 

            ProcessController processes = new ProcessController();
            processes.Load();
            //progress_bar_update(20);
            JobController jobs = new JobController();
            jobs.Load();
            //progress_bar_update(20);
            RecipeController recipes = new RecipeController();
            recipes.Load();
            //progress_bar_update(20);
            IndexController indexes = new IndexController(workers, jobs, recipes);
            indexes.Load();
            //progress_bar_update(20);
            indexes.CalculateIndexes(simulation);
            //progress_bar_update(20);

            //label_state("Estado de la simulación: Asignando trabajadores...");
            //progress_bar_reset();

            //Algoritmo GRASP

            Grasp grasp = new Grasp(simulation, jobs, recipes, indexes);
            List<Assignment> initial_assignments = new List<Assignment>();

            for (int day = 0; elapsed_seconds < Simulation.LimitTime && day < simulation.Days; day++)
            {
                initial_assignments.Add(grasp.ExecuteGraspAlgorithm(day, ref elapsed_seconds));
                //progress_bar_update(Convert.ToInt32(100.0 / day));
            }

            //label_state("Estado de la simulación: Optimizando la asignación de trabajadores...");
            //progress_bar_reset();

            //Algoritmo de Búsqueda Tabú

            //TabuSearch tabu = new TabuSearch(simulation, initial_assignments);
            //tabu.run();
            //assignments = tabu.BestSolution;

        }

        private void background_simulation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void background_simulation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.timer.Stop();

            MessageBox.Show("¡Se realizó la asignación con éxito!", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /*************************** Varios ***************************/

        private void timer_Tick(object sender, EventArgs e)
        {
            this.elapsed_seconds++;
            this.label_time.Text = string.Format("Tiempo: {0:2}:{1:2} s", elapsed_seconds / 60, elapsed_seconds % 60);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SimulationLoadingScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (elapsed_seconds >= Simulation.LimitTime) return;

            DialogResult result = MessageBox.Show("¿Está seguro de cancelar la simulación de la asignación de trabajadores?",
                "Inka Art", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) e.Cancel = true;

            background_simulation.CancelAsync();
        }
    }
}
