using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;
using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony

    public class JobController
    {
        private List<Job> jobs;

        public JobController()
        {
            jobs = new List<Job>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Process-Product\" ORDER BY \"idJob\" ASC", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_job = Convert.ToInt32(reader["idJob"]);
                string name = reader["name"].ToString();
                int id_process = Convert.ToInt32(reader["idProcess"]);
                int id_product = Convert.ToInt32(reader["idProduct"]);
                int order = Convert.ToInt32(reader["order"]);
                jobs.Add(new Job(id_job, name, id_process, id_product, order));
            }

            connection.Close();
        }

        public Job GetByID(int id)
        {
            foreach (Job job in jobs)
                if (job.ID == id) return job;
            return null;
        }

        public Job GetByName(string name)
        {
            foreach (Job job in jobs)
                if (job.Name == name) return job;
            return null;
        }

        public int NumberOfJobs
        {
            get { return jobs.Count; }
        }

        public Job this[int index]
        {
            get { return jobs[index]; }
        }

        public List<Job> List()
        {
            return new List<Job>(jobs);
        }

        public int GetIndex(int id_job)
        {
            for (int i = 0; i < jobs.Count; i++)
                if (jobs[i].ID == id_job) return i;
            return -1;
        }

        public List<Job> GetJobsByProduct(int id_product)
        {
            return jobs.FindAll(job => job.Product == id_product);
        }
    }
}
