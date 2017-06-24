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
        private SimulationController simulations;
        private Simulation simulation;
        private int elapsed_seconds;
        private WorkerController workers;

        public SimulationExecution(SimulationController simulations, Simulation simulation, WorkerController workers)
        {
            InitializeComponent();
            this.simulations = simulations;
            this.simulation = simulation;
            this.elapsed_seconds = 0;
            this.workers = workers;
        }

        private void NewSimulation_Load(object sender, EventArgs e)
        {
            this.timer.Start();
            background_simulation.RunWorkerAsync();
        }

        /*************************** Subproceso de simulación de asignación de trabajadores ***************************/

        private void background_simulation_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker background_worker = sender as BackgroundWorker;
            background_worker.ReportProgress(0, "Estado de la simulación: Cargando datos...");

            //Carga de controladores

            ProcessController processes = new ProcessController();
            processes.Load();
            JobController jobs = new JobController();
            jobs.Load();
            RecipeController recipes = new RecipeController();
            recipes.Load();
            IndexController indexes = new IndexController(workers, jobs, recipes);
            indexes.Load();
            indexes.CalculateIndexes(simulation);

            //Temporal: Determinar el tiempo total del turno y los miniturnos
            Turn turn = null;
            for (int i = 0; i < workers.NumberOfWorkers; i++)
                if (workers[i].Turn.ID == 1) turn = workers[i].Turn;
            int total_miniturns = turn.TotalMinutes / Simulation.MiniturnLength;

            background_worker.ReportProgress(0, "Estado de la simulación: Asignando trabajadores...");

            //Algoritmo GRASP

            Grasp grasp = new Grasp(simulation, jobs, recipes, indexes);
            List<Assignment> initial_assignments = new List<Assignment>();

            for (int day = 0; elapsed_seconds < Simulation.LimitTime && day < simulation.Days; day++)
            {
                initial_assignments.Add(grasp.ExecuteGraspAlgorithm(day, total_miniturns, ref elapsed_seconds));
                background_worker.ReportProgress(Convert.ToInt32(50.0 / simulation.Days), null);
            }

            indexes.indexesToCSV();

            background_worker.ReportProgress(0, "Estado de la simulación: Optimizando la asignación de trabajadores...");

            //Algoritmo de Búsqueda Tabú

            TabuSearch tabu = new TabuSearch(simulation, indexes, initial_assignments, elapsed_seconds);

            //for (int day = 0; elapsed_seconds < Simulation.LimitTime && day < simulation.Days; day++)
            //{
            //    tabu.run(ref elapsed_seconds, day);
            //    background_worker.ReportProgress(Convert.ToInt32(50.0 / simulation.Days), null);
            //}

            //simulation.Assignments = tabu.BestSolution;
            simulation.Assignments = initial_assignments;
        }
                
        private void background_simulation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState == null) this.progress_bar.Value += e.ProgressPercentage;
            if (e.UserState != null) this.label_state.Text = e.UserState.ToString();
        }

        private void background_simulation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.timer.Stop();

            MessageBox.Show("¡Se realizó la asignación con éxito!", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Information);
            simulations.Add(simulation);
            this.Close();
        }

        /*************************** Varios ***************************/

        private void timer_Tick(object sender, EventArgs e)
        {
            this.elapsed_seconds++;
            this.label_time.Text = string.Format("Tiempo: {0:00} m {1:00} s", elapsed_seconds / 60, elapsed_seconds % 60);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SimulationLoadingScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!background_simulation.IsBusy || elapsed_seconds >= Simulation.LimitTime) return;

            DialogResult result = MessageBox.Show("¿Está seguro de cancelar la simulación de la asignación de trabajadores?",
                "Inka Art", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) e.Cancel = true;

            background_simulation.CancelAsync();
        }
    }
}
