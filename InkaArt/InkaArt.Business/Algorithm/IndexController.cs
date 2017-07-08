using Npgsql;
using NpgsqlTypes;
using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();
            
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Index\" WHERE status = TRUE ORDER BY id_index ASC", connection);
            
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

        /// <summary>
        /// Obtiene un <see cref="DataTable"/> con los índices de la base de datos.
        /// </summary>
        public DataTable GetDataTable()
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Index\" WHERE status = TRUE ORDER BY id_index ASC", connection);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            DataSet data_set = new DataSet();
            adapter.Fill(data_set);

            connection.Close();

            return data_set.Tables[0];
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
            double[,] average_breakage_mean = new double[this.recipes.NumberOfRecipes, this.jobs.NumberOfJobs];
            double[,] average_time_mean = new double[this.recipes.NumberOfRecipes, this.jobs.NumberOfJobs];
            int[,] average_mean_count = new int[this.recipes.NumberOfRecipes, this.jobs.NumberOfJobs];
            for (int i = 0; i < this.recipes.NumberOfRecipes; i++)
                for (int j = 0; j < this.jobs.NumberOfJobs; j++)
                {
                    average_mean_count[i, j] = 0;
                    average_breakage_mean[i, j] = 0;
                    average_time_mean[i, j] = 0;
                }

            //Calcular las sumas de AverageBreakage y AverageTime
            for (int i = this.indexes.Count - 1; i >= 0; i--)
            {
                Index index = this.indexes[i];
                if (index == null || index.Job == null || index.Recipe == null) this.indexes.RemoveAt(i);
                int job_index = this.jobs.GetIndex(index.Job.ID);
                int recipe_index = this.recipes.GetIndex(index.Recipe.ID);
                //Agregar a la suma de AverageBreakage y AverageTime
                average_mean_count[recipe_index, job_index]++;
                average_breakage_mean[recipe_index, job_index] += index.AverageBreakage;
                average_time_mean[recipe_index, job_index] += index.AverageTime;
            }

            //Calcular los promedios de AverageBreakage y AverageTime
            for (int r = 0; r < recipes.NumberOfRecipes; r++)
            {
                LogHandler.Write("{0}", recipes[r].Version);
                for (int j = 0; j < jobs.NumberOfJobs; j++)
                {
                    LogHandler.Write(";{0},{1:0.0000},{2:0.0000}", average_mean_count[r, j], average_breakage_mean[r, j], average_time_mean[r, j]);
                    average_breakage_mean[r, j] = average_breakage_mean[r, j] / average_mean_count[r, j];
                    average_time_mean[r, j] = average_time_mean[r, j] / average_mean_count[r, j];
                    LogHandler.Write(",{0:0.0000},{1:0.0000}", average_breakage_mean[r, j], average_time_mean[r, j]);
                }
                LogHandler.WriteLine();
            }

            //Calcular el BreakageIndex, TimeIndex y LossIndex
            for (int r = 0; r < recipes.NumberOfRecipes; r++)
            {
                for (int j = 0; j < jobs.NumberOfJobs; j++)
                {
                    //Debemos asegurar que la receta y el puesto de trabajo tengan coherencia
                    if (recipes[r].Product != jobs[j].Product) continue;

                    double product_weight = simulation.ProductWeight(recipes[r].Product);

                    //Si el contador de índices por receta y puesto de trabajo es 0, entonces para cada trabajador debe crearse un índice ficticio
                    if (average_mean_count[r, j] <= 0)
                    {
                        double loss_index = (simulation.BreakageWeight + simulation.TimeWeight) / product_weight;
                        for (int w = 0; w < simulation.SelectedWorkers.NumberOfWorkers; w++)
                            indexes.Add(new Index(simulation.SelectedWorkers[w], jobs[j], recipes[r], 0, Simulation.MiniturnLength, loss_index));
                        continue;
                    }

                    for (int w = 0; w < simulation.SelectedWorkers.NumberOfWorkers; w++)
                    {
                        Index index = FindByWorkerJobAndRecipe(simulation.SelectedWorkers[w], jobs[j], recipes[r]);

                        if (index != null)
                        {
                            index.BreakageIndex = index.AverageBreakage / average_breakage_mean[r, j];
                            index.TimeIndex = index.AverageTime / average_time_mean[r, j];
                            LogHandler.Write("{0};{1};{2};{3:0.0000} / [{4},{5}]={6:0.0000} = {7:0.0000};{8:0.0000} / [{4},{5}]={9:0.0000} = {10:0.0000};",
                                   index.Worker.FullName, index.Recipe.Version, index.Job.Name, index.AverageBreakage, r + 1, j + 1, average_breakage_mean[r, j],
                                   index.BreakageIndex, index.AverageTime, average_time_mean[r, j], index.TimeIndex);
                            index.LossIndex = (index.BreakageIndex * simulation.BreakageWeight + index.TimeIndex * simulation.TimeWeight) / product_weight;
                            index.CostValue = index.LossIndex;
                            LogHandler.WriteLine("({0:0.0000}*{1:0.0000} + {2:0.0000}*{3:0.0000}) / {4:0.0000} = {5:0.0000};{6:0.0000}", index.BreakageIndex,
                                simulation.BreakageWeight, index.TimeIndex, simulation.TimeWeight, product_weight, index.LossIndex, index.CostValue);
                            continue;
                        }
                        //Si el índice es nulo, crear un índice ficticio para el trabajador
                        double loss_index = (simulation.BreakageWeight + simulation.TimeWeight) / product_weight;
                        indexes.Add(new Index(simulation.SelectedWorkers[w], jobs[j], recipes[r], average_breakage_mean[r, j],
                            average_time_mean[r, j], loss_index));
                    }
                    LogHandler.WriteLine("Terminado el puesto de trabajo {0} para la receta {1} (count={2}, breakage={3}, mean={4})",
                        jobs[j].Name, recipes[r].Version, average_mean_count[r, j], average_breakage_mean[r, j], average_time_mean[r, j]);
                }
                LogHandler.WriteLine("Terminada la receta {0}", recipes[r].Version);
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
