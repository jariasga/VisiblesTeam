using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using System.IO;

namespace InkaArt.Business.Algorithm
{
    public class IndexController
    {
        private List<Index> indexes;

        private WorkerController workers;
        private JobController jobs;
        private RecipeController recipes;

        public IndexController(WorkerController workers, JobController jobs, RecipeController recipes)
        {
            this.indexes = new List<Index>();

            this.workers = workers;
            this.jobs = jobs;
            this.recipes = recipes;
        }

        public IndexController()
        {
            this.indexes = new List<Index>();

            this.workers = new WorkerController();
            this.workers.Load();
            this.jobs = new JobController();
            this.jobs.Load();
            this.recipes = new RecipeController();
            this.recipes.Load();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();
            
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Index\" WHERE status = :status ORDER BY id_index ASC", connection);
            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, true);
            
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_index = reader.GetInt32(0);
                Worker worker = workers.GetByID(reader.GetInt32(1));
                Job job = jobs.GetByID(reader.GetInt32(2));
                Recipe recipe = recipes.GetByID(reader.GetInt32(3));
                double average_breakage = reader.GetDouble(4);
                double average_time = reader.GetDouble(5);
                if (worker == null || job == null || recipe == null) continue;
                Index index = new Index(id_index, worker, job, recipe, average_breakage, average_time);
                indexes.Add(index);
            }

            connection.Close();
        }

        /************************ INSERTAR O ACTUALIZAR EN LAS TABLAS INDEX Y RATIOPERDAY ************************/

        public string InsertOrUpdate(Ratio ratio, int initial_count_ratios)
        {
            //Si el número de ratios que cumple los parámetros de ratio es 0, se inserta.
            if (initial_count_ratios <= 0) return Index.Insert(ratio);

            //Si el número de ratios que cummple los parámetros es mayor que 0, se actualiza el ya existente.
            double average_breakage, average_time;
            ratio.AverageValues(out average_breakage, out average_time);

            return Index.Update(ratio, average_breakage, average_time);
        }

        public string UpdateOrDelete(Ratio ratio)
        {
            double average_breakage, average_time;
            ratio.AverageValues(out average_breakage, out average_time);

            //Si ambos valores son mayores que cero, entonces se actualiza.
            if (average_breakage >= 0 && average_time >= 0) return Index.Update(ratio, average_breakage, average_time);

            //Sino, se procede a realizar un soft deletion.
            return Index.Delete(ratio);
        }

        /*********************** ALGORITMO ***********************/

        public void CalculateIndexes(Simulation simulation)
        {
            double[,] average_breakage_mean = new double[recipes.NumberOfRecipes, jobs.NumberOfJobs];
            double[,] average_time_mean = new double[recipes.NumberOfRecipes, jobs.NumberOfJobs];
            int[,] average_mean_count = new int[recipes.NumberOfRecipes, jobs.NumberOfJobs];

            //Calcular los promedios de average_breakage y average_time. Esta función es O(n^3) :(
            for (int recipe = 0; recipe < recipes.NumberOfRecipes; recipe++)
            {
                List<Job> product_jobs = jobs.GetJobsByProduct(recipes[recipe].Product);
                LogHandler.WriteLine("Receta {0}: {1}", recipe + 1, "ID: " + recipes[recipe].ID + ", Version: " + recipes[recipe].Version);
                for (int job = 0; job < product_jobs.Count; job++)
                {
                    int job_index = jobs.GetIndex(product_jobs[job].ID);
                    int recipe_index = recipes.GetIndex(recipes[recipe].ID);
                    if (job_index < 0 || recipe_index < 0) continue;
                    LogHandler.WriteLine("- Puesto de trabajo {0}: index={1}, ID={2}, Nombre={3}", job + 1, job_index, product_jobs[job].ID, product_jobs[job].Name);

                    for (int index = 0; index < indexes.Count; index++)
                    {
                        //LogHandler.WriteLine("  - index.Job={0}={1}=product_jobs[{2}], index.Recipe={3}={4}=recipes[{5}]", indexes[index].Job.ID, product_jobs[job].ID, job, indexes[index].Recipe.ID, recipes[recipe].ID, recipe);
                        if (indexes[index].Job.ID == product_jobs[job].ID && indexes[index].Recipe.ID == recipes[recipe].ID)
                        {
                            average_mean_count[recipe_index, job_index]++;
                            average_breakage_mean[recipe_index, job_index] += indexes[index].AverageBreakage;
                            average_time_mean[recipe_index, job_index] += indexes[index].AverageTime;
                            LogHandler.WriteLine("    Nuevo average_mean[{0},{1}]: Count={2}, Breakage={3}, Time={4}", recipe_index, job_index,
                                average_mean_count[recipe_index, job_index], average_breakage_mean[recipe_index, job_index], average_time_mean[recipe_index, job_index]);
                        }
                    }

                    if (average_mean_count[recipe_index, job_index] <= 0)
                    {
                        average_breakage_mean[recipe_index, job_index] = 0; //Asumimos que no demora nada
                        average_time_mean[recipe_index, job_index] = Simulation.MiniturnLength; //Asumimos que se demora un miniturno en hacer un producto
                    }
                    else
                    {
                        average_breakage_mean[recipe_index, job_index] /= average_mean_count[recipe_index, job_index];
                        average_time_mean[recipe_index, job_index] /= average_mean_count[recipe_index, job_index];
                    }
                }
            }

            //Calcular los promedios de average_breakage y average_time. Esta función es O(n^4). Ineficiencia 100% :(
            for (int worker = 0; worker < simulation.SelectedWorkers.Count(); worker++)
            {
                for (int recipe = 0; recipe < recipes.NumberOfRecipes; recipe++)
                {
                    List<Job> product_jobs = jobs.GetJobsByProduct(recipes[recipe].Product);
                    for (int job = 0; job < product_jobs.Count; job++)
                    {
                        int job_index = jobs.GetIndex(product_jobs[job].ID);
                        int recipe_index = recipes.GetIndex(recipes[recipe].ID);
                        Worker worker_object = simulation.SelectedWorkers[worker];

                        Index index = FindByWorkerJobAndRecipe(worker_object, jobs[job_index], recipes[recipe_index]);
                        bool is_new_index = false;
                        if (index == null)
                        {
                            index = new Index(0, worker_object, jobs[job_index], recipes[recipe_index],
                                average_breakage_mean[recipe_index, job_index], average_time_mean[recipe_index, job_index]);
                            is_new_index = true;
                        }

                        double breakage_mean = (average_mean_count[recipe_index, job_index] <= 0) ? 1 : average_breakage_mean[recipe_index, job_index];
                        double product_weight = simulation.ProductWeight(jobs.GetByID(index.Job.ID).Product);
                        index.CalculateIndexes(breakage_mean, average_time_mean[recipe_index, job_index], simulation.BreakageWeight, simulation.TimeWeight, product_weight);
                        if (is_new_index) indexes.Add(index);
                    }
                }
            }
        }

        /********************************* FUNCIONES AUXILIARES *********************************/

        public Index GetByID(int id_index)
        {
            foreach (Index index in indexes)
                if (index.ID == id_index) return index;
            return null;
        }

        public Index this[int index]
        {
            get { return indexes[index]; }
        }

        public int Count()
        {
            return indexes.Count;
        }

        public void Add(Index index)
        {
            this.indexes.Add(index);
        }

        public void RemoveFirst()
        {
            this.indexes.RemoveAt(0);
        }

        public void Remove(Index index)
        {
            this.indexes.Remove(index);
        }

        public Index FindByAssignment(AssignmentLine line)
        {
            return (line == null) ? null : FindByWorkerJobAndRecipe(line.Worker, line.Job, line.Recipe);
        }

        public Index FindByWorkerJobAndRecipe(Worker worker, Job job, Recipe recipe)
        {
            if (worker == null || job == null || recipe == null) return null;
            for (int i = 0; i < indexes.Count; i++)
            {
                if (indexes[i] == null || indexes[i].Worker == null || indexes[i].Job == null || indexes[i].Recipe == null) continue;
                if (indexes[i].Worker.ID == worker.ID && indexes[i].Job.ID == job.ID && indexes[i].Recipe.ID == recipe.ID) return indexes[i];
            }
            return null;
        }

        public void indexesToCSV()
        {
            //before your loop
            var csv = new StringBuilder();

            foreach (Index index in indexes)
            {
                var worker = index.Worker.FullName;
                var worker_id = index.Worker.ID.ToString();
                var job = index.Job.ID.ToString();
                var recipe = index.Recipe.ID.ToString();
                var br = index.BreakageIndex.ToString();
                var ti = index.TimeIndex.ToString();
                var lo = index.LossIndex.ToString();
                var newLine = string.Format("{0};{1};{2};{3};{4};{5};{6}", worker_id, worker, job, recipe, br, ti, lo);
                csv.AppendLine(newLine);
            }
                        
            //after your loop
            File.WriteAllText("indexes.csv", csv.ToString());
        }
    }
}
