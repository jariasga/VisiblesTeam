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

    class JobController
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

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Process-Product\"", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_job = reader.GetInt32(2);
                string name = reader.GetString(3);
                int id_process = reader.GetInt32(1);
                int id_product = reader.GetInt32(0);
                jobs.Add(new Job(id_job, name, id_process, id_product));
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

        public int Count()
        {
            return jobs.Count();
        }

        public Job this[int index]
        {
            get { return jobs[index]; }
        }
    }
}
