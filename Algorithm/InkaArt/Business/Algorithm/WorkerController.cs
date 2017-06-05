using InkaArt.Data.Algorithm;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony
    class WorkerController
    {
        private List<Worker> workers;

        public WorkerController()
        {
            workers = new List<Worker>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Worker\"", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string last_name = reader.GetString(2);
                workers.Add(new Worker(id, name, last_name));
            }

            connection.Close();
        }

        public Worker GetByID(int id)
        {
            for (int i = 0; i < workers.Count; i++)
                if (workers[i].ID == id) return workers[i];
            return null;
        }

        public Worker GetByFullName(string full_name)
        {
            for (int i = 0; i < workers.Count; i++)
                if (workers[i].FullName() == full_name) return workers[i];
            return null;
        }

        public int Count()
        {
            return workers.Count();
        }

        public Worker this[int index]
        {
            get { return workers[index]; }
        }
    }
}
