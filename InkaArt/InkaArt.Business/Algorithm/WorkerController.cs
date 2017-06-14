using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using System.Windows.Forms;

namespace InkaArt.Business.Algorithm
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony
    public class WorkerController
    {
        private List<Worker> workers;

        public WorkerController()
        {
            workers = new List<Worker>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Worker\" ORDER BY last_name ASC", connection);

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
            foreach (Worker worker in workers)
                if (worker.ID == id) return worker;
            return null;
        }

        public Worker GetByFullName(string full_name)
        {
            foreach (Worker worker in workers)
                if (worker.FullName == full_name) return worker;
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

        public List<Worker> List()
        {
            return new List<Worker>(workers);
        }

        public void Add(Worker worker)
        {
            this.workers.Add(worker);
        }

        public bool Contains(Worker worker)
        {
            return this.workers.Contains(worker);
        }

        public int GetIndex(int id_worker)
        {
            for (int i = 0; i < workers.Count; i++)
                if (workers[i].ID == id_worker) return i;
            return -1;
        }
    }
}
