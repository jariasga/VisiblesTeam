using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;
using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    public class IndexController
    {
        private List<Index> indexes;

        public IndexController()
        {
            this.indexes = new List<Index>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Index\" WHERE status = :status " +
                "ORDER BY id_index ASC", connection);

            command.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, true);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_index = reader.GetInt32(0);
                int id_worker = reader.GetInt32(1);
                int id_job = reader.GetInt32(2);
                int id_recipe = reader.GetInt32(3);
                double average_breakage = reader.GetDouble(4);
                double average_time = reader.GetDouble(5);
                Index index = new Index(id_index, id_worker, id_job, id_recipe, average_breakage, average_time);
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

        public void CalculateIndexes(JobController jobs, RecipeController recipes, Simulation simulation)
        {
            double[,] average_breakage_mean = new double[jobs.NumberOfJobs, recipes.Count()];
            double[,] average_time_mean = new double[jobs.NumberOfJobs, recipes.Count()];
            int[,] average_mean_count = new int[jobs.NumberOfJobs, recipes.Count()];

            for (int i = 0; i < jobs.NumberOfJobs; i++)
            {
                for (int j = 0; j < recipes.Count(); j++)
                {
                    foreach (Index index in indexes)
                    {
                        if (index.Job == jobs[i].ID && index.Recipe == recipes[j].ID)
                        {
                            average_mean_count[i, j]++;
                            average_breakage_mean[i, j] += index.AverageBreakage;
                            average_time_mean[i, j] += index.AverageTime;
                        }
                    }

                    average_breakage_mean[i, j] = (average_mean_count[i, j] <= 0) ? 1 :
                        average_breakage_mean[i, j] / average_mean_count[i, j];
                    average_time_mean[i, j] = (average_mean_count[i, j] <= 0) ? 1 :
                        average_time_mean[i, j] / average_mean_count[i, j];
                }
            }

            foreach (Index index in indexes)
            {
                int job_index = jobs.GetIndex(index.Job);
                int recipe_index = recipes.GetIndex(index.Recipe);
                double product_weight = simulation.ProductWeight(jobs.GetByID(index.Job).Product);
                index.CalculateIndexes(average_breakage_mean[job_index, recipe_index], average_time_mean[job_index, recipe_index],
                    simulation.BreakageWeight, simulation.TimeWeight, product_weight);
            }
        }

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

        public Index FindByWorkerAndJob(Worker worker, Job job)
        {
            if (worker == null || job == null) return null;
            foreach (Index index in indexes)
                if (index.Worker == worker.ID && index.Job == job.ID) return index;
            return null;
        }
    }
}
