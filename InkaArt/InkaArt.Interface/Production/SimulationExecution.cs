using InkaArt.Business.Algorithm;
using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

            if (background_worker.CancellationPending && (e.Cancel = true)) return;
            JobController jobs = new JobController();
            jobs.Load();
            RecipeController recipes = new RecipeController();
            recipes.Load();
            IndexController indexes = new IndexController(workers, jobs, recipes);
            indexes.Load();
            indexes.CalculateIndexes(simulation);

            for (int i = 0; i < simulation.SelectedOrders.NumberOfOrders; i++)
            {
                LogHandler.WriteLine("Orden de compra #{0}: ID={1}, Descripcion={2}", i + 1, simulation.SelectedOrders[i].ID, simulation.SelectedOrders[i].Description);
                for (int j = 0; j < simulation.SelectedOrders[i].NumberOfLineItems; j++)
                    LogHandler.WriteLine("- Linea de orden #{0}-{1}: {2}", i + 1, j + 1, simulation.SelectedOrders[i][j].ToString());
            }

            //Temporal: Determinar el tiempo total del turno y los miniturnos
            if (background_worker.CancellationPending && (e.Cancel = true)) return;
            Turn turn = new Turn(1, TimeSpan.Parse("8:00"), TimeSpan.Parse("15:00"), null);
            for (int i = 0; i < workers.NumberOfWorkers; i++)
                if (workers[i].Turn.ID == 1) turn = workers[i].Turn;
            simulation.TotalMiniturns = turn.TotalMinutes / Simulation.MiniturnLength;

            background_worker.ReportProgress(0, "Estado de la simulación: Asignando trabajadores...");

            //Algoritmo GRASP

            Grasp grasp = new Grasp(simulation, jobs, recipes, indexes);
            List<Assignment> initial_assignments = new List<Assignment>();

            for (int day = 0; elapsed_seconds < Simulation.LimitTime && day < simulation.Days; day++)
            {
                if (background_worker.CancellationPending && (e.Cancel = true)) return;
                initial_assignments.Add(grasp.ExecuteGraspAlgorithm(day, ref elapsed_seconds));
                background_worker.ReportProgress(0, null);
            }

            try
            {
                if (background_worker.CancellationPending && (e.Cancel = true)) return;
                PrintGraspResults(initial_assignments, simulation.TotalMiniturns);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el Excel de los resultados del algoritmo GRASP. " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            background_worker.ReportProgress(0, "Estado de la simulación: Optimizando la asignación de trabajadores...");

            //Algoritmo de Búsqueda Tabú

            TabuSearch tabu = new TabuSearch(simulation, indexes, initial_assignments, elapsed_seconds);
            /*for (int day = 0; elapsed_seconds < Simulation.LimitTime && day < simulation.Days; day++)
            {
                if (background_worker.CancellationPending && (e.Cancel = true)) return;
                tabu.run(ref elapsed_seconds, day);
                background_worker.ReportProgress(0, null);
            }*/

            if (background_worker.CancellationPending && (e.Cancel = true)) return;
            simulation.Assignments = tabu.BestSolutionToList();
        }

        private void PrintGraspResults(List<Assignment> assignments, int total_miniturns)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add(Missing.Value);

            for (int day = 0; day < simulation.Days; day++)
            {
                Excel.Worksheet worksheet;
                if (day <= 0) worksheet = (Excel.Worksheet)workbook.Worksheets.Item[day + 1];
                else worksheet = (Excel.Worksheet)workbook.Worksheets.Add(Missing.Value, workbook.Worksheets[day]);

                worksheet.Name = "Día " + (day + 1);
                if (assignments[day] == null) worksheet.Cells[1, 1] = "Nada registrado para dicho día.";
                else
                {
                    worksheet.Cells[1, 1] = "Fecha:";
                    worksheet.Cells[1, 2] = "Valor de la función objetivo";
                    worksheet.Cells[1, 3] = "Huacos producidos";
                    worksheet.Cells[1, 4] = "Piedras producidas";
                    worksheet.Cells[1, 5] = "Retablos producidos";
                    worksheet.Cells[2, 1] = simulation.StartDate.AddDays(day).ToString("dd/MM/yyyy");
                    worksheet.Cells[2, 2] = assignments[day].ObjectiveFunction;
                    worksheet.Cells[2, 3] = assignments[day].HuacosProduced;
                    worksheet.Cells[2, 4] = assignments[day].HuamangaProduced;
                    worksheet.Cells[2, 5] = assignments[day].AltarpieceProduced;

                    for (int w = 0; w < simulation.SelectedWorkers.NumberOfWorkers; w++)
                    {
                        worksheet.Cells[4, w + 1] = simulation.SelectedWorkers[w].FullName;
                        for (int m = 0; m < simulation.TotalMiniturns; m++)
                        {
                            AssignmentLine line = assignments[day][w, m];
                            worksheet.Cells[m + 5, w + 1] = (line == null) ? "Nada" : line.ToString();
                        }
                    }
                }
            }
            
            app.Visible = true;
        }
        
        private void background_simulation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null) this.label_state.Text = e.UserState.ToString();
            else this.progress_bar.Value += Convert.ToInt32(Math.Floor(500.0 / simulation.Days));
        }

        private void background_simulation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.timer.Stop();
            
            if (e.Cancelled == false)
            {
                MessageBox.Show("¡Se realizó la asignación con éxito!", "Inka Art", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else this.DialogResult = DialogResult.Cancel;

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
