using InkaArt.Business.Algorithm;
using InkaArt.Data.Algorithm;
using InkaArt.Data.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Reports
{
    public class ReportsController
    {
        private ReportsData reportData;

        public ReportsController()
        {
            reportData = new ReportsData();
        }

        public DataTable getDataSales(string fechaIni, string fechaFin, string producto)
        {
            return reportData.getDataSales(fechaIni, fechaFin, producto);
        }

        public DataTable getDataStocks(int flag)
        {
            return reportData.getDataStocks(flag);
        }

        /// <summary>
        /// Obtiene los ratios y calcula los índices a mostrar en el reporte de rendimiento, limitados por un intervalo de fechas.
        /// </summary>
        public DataTable GetDataPerformance(WorkerController selected_workers, DateTime start_date, DateTime end_date)
        {
            RecipeController recipes = new RecipeController();
            recipes.Load();
            JobController jobs = new JobController();
            jobs.Load();

            RatioController ratios = new RatioController(selected_workers, jobs, recipes);
            DataTable initial_table = ratios.GetDataTable(start_date, end_date);

            int[,,] counter = new int[selected_workers.NumberOfWorkers, recipes.NumberOfRecipes, jobs.NumberOfJobs];
            double[,,] average_breakage = new double[selected_workers.NumberOfWorkers, recipes.NumberOfRecipes, jobs.NumberOfJobs];
            double[,,] average_time = new double[selected_workers.NumberOfWorkers, recipes.NumberOfRecipes, jobs.NumberOfJobs];

            for (int i = initial_table.Rows.Count - 1; i >= 0; i--)
            {
                int worker_index = selected_workers.GetIndex(int.Parse(initial_table.Rows[i]["id_worker"].ToString()));
                int recipe_index = recipes.GetIndex(int.Parse(initial_table.Rows[i]["id_recipe"].ToString()));
                int job_index = jobs.GetIndex(int.Parse(initial_table.Rows[i]["id_job"].ToString()));
                if (worker_index < 0 || recipe_index < 0 || job_index < 0) continue;
                //Aumentar las variables contadoras y sumatorias
                counter[worker_index, recipe_index, job_index]++;
                average_breakage[worker_index, recipe_index, job_index] += double.Parse(initial_table.Rows[i]["breakage"].ToString());
                average_time[worker_index, recipe_index, job_index] += double.Parse(initial_table.Rows[i]["time"].ToString());
            }

            //Insertar los datos leídos de Ratio en la nueva tabla
            DataTable table = reportData.GetDataPerformance();
            for (int w = 0; w < selected_workers.NumberOfWorkers; w++)
                for (int r = 0; r < recipes.NumberOfRecipes; r++)
                    for (int j = 0; j < jobs.NumberOfJobs; j++)
                    {
                        if (counter[w, r, j] <= 0) continue;
                        string worker = (selected_workers[w] != null) ? selected_workers[w].FullName : "null";
                        string recipe = (recipes[r] != null) ? recipes[r].Version : "null";
                        string job = (jobs[j] != null) ? jobs[j].Name: "null";
                        double breakage = average_breakage[w, r, j] * 100 / counter[w, r, j];
                        double time = average_time[w, r, j] / counter[w, r, j];
                        table.Rows.Add(worker, recipe, job, breakage, time);
                    }

            return table;
        }

        /// <summary>
        /// Obtiene todos los índices a mostrar en el reporte de rendimiento.
        /// </summary>
        public DataTable GetDataPerformance(WorkerController selected_workers)
        {
            RecipeController recipes = new RecipeController();
            recipes.Load();
            JobController jobs = new JobController();
            jobs.Load();

            IndexController indexes = new IndexController(selected_workers, jobs, recipes);
            DataTable initial_table = indexes.GetDataTable();

            DataTable table = reportData.GetDataPerformance();
            for (int i = 0; i < initial_table.Rows.Count; i++)
            {
                int id_worker = 0, id_recipe = 0, id_job = 0;
                if (!int.TryParse(initial_table.Rows[i]["id_worker"].ToString(), out id_worker)) continue;
                if (!int.TryParse(initial_table.Rows[i]["id_recipe"].ToString(), out id_recipe)) continue;
                if (!int.TryParse(initial_table.Rows[i]["id_job"].ToString(), out id_job)) continue;
                Worker worker = selected_workers.GetByID(id_worker);
                Recipe recipe = recipes.GetByID(id_recipe);
                Job job = jobs.GetByID(id_job);
                if (worker == null || recipe == null || job == null) continue;
                double breakage, time;
                if (!double.TryParse(initial_table.Rows[i]["average_breakage"].ToString(), out breakage)) continue;
                if (!double.TryParse(initial_table.Rows[i]["average_time"].ToString(), out time)) continue;
                table.Rows.Add(worker.FullName, recipe.Version, job.Name, breakage * 100, time);
            }

            return table;
        }

        public DataTable getDataSimulation(string name)
        {
            return reportData.getDataSimulation(name);
        }
        public DataTable getDataMovements(string fechaIni, string fechaFin, List<string> items, List<string> warehouses)
        {
            return reportData.getDataMovements(fechaIni, fechaFin, items, warehouses);
        }
    }
}
