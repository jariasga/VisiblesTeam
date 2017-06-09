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
    class IndexController
    {
        private List<Index> indexes;

        public IndexController()
        {
            indexes = new List<Index>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"RatioResume\" WHERE status = 1 " +
                "ORDER BY id_resume ASC", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_resume = reader.GetInt32(0);
                int id_worker = reader.GetInt32(1);
                int id_job = reader.GetInt32(2);
                int id_recipe = reader.GetInt32(3);
                double average_breakage = reader.GetDouble(4);
                double average_time = reader.GetDouble(5);
                Index turn_report_resume = new Index(id_resume, id_worker, id_job, id_recipe,
                    average_breakage, average_time);
                indexes.Add(turn_report_resume);
            }

            connection.Close();
        }

        public void Insert(Ratio ratio)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO inkaart.\"RatioResume\"(id_worker, id_job, "
                    + "id_recipe, average_breakage, average_time) VALUES(:id_worker, :id_job, :id_recipe, "
                    + ":average_breakage, :average_time)", connection);

            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, ratio.Worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, ratio.Job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, ratio.Recipe);
            command.Parameters.AddWithValue("average_breakage", NpgsqlDbType.Double, ratio.Breakage);
            command.Parameters.AddWithValue("average_time", NpgsqlDbType.Double, ratio.Time);

            command.ExecuteScalar();
            connection.Close();
        }

        public void Update(Ratio ratio, double average_breakage, double average_time)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE inkaart.\"RatioResume\" SET " +
                "average_breakage = :average_breakage, average_time = :average_time WHERE " +
                "id_worker = :id_worker, id_job = :id_job, id_recipe = :id_recipe", connection);

            command.Parameters.AddWithValue("average_breakage", NpgsqlDbType.Double, ratio.Breakage);
            command.Parameters.AddWithValue("average_time", NpgsqlDbType.Double, ratio.Time);
            command.Parameters.AddWithValue("id_worker", NpgsqlDbType.Integer, ratio.Worker);
            command.Parameters.AddWithValue("id_job", NpgsqlDbType.Integer, ratio.Job);
            command.Parameters.AddWithValue("id_recipe", NpgsqlDbType.Integer, ratio.Recipe);

            command.ExecuteScalar();
            connection.Close();
        }

        public void CalculateIndexes(JobController jobs, RecipeController recipes)
        {
            double[,] average_breakage_mean = new double[jobs.Count(), recipes.Count()];
            double[,] average_time_mean = new double[jobs.Count(), recipes.Count()];
            int[,] average_mean_count = new int[jobs.Count(), recipes.Count()];

            for (int i = 0; i < jobs.Count(); i++)
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
                index.BreakageIndex = index.AverageBreakage / average_breakage_mean[index.Job, index.Recipe];
                index.TimeIndex = index.AverageTime / average_time_mean[index.Job, index.Recipe];
            }
        }

        public Index GetByID(int id_resume)
        {
            foreach (Index resume in indexes)
                if (resume.ID == id_resume) return resume;
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

    }
}
