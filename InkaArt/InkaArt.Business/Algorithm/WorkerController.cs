using InkaArt.Business.Production;
using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            TurnController turns = new TurnController();
            DataTable table = turns.getData();
            
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT DISTINCT w.* FROM inkaart.\"Worker\" w, inkaart.\"User\" u " +
                "WHERE w.id_user = u.id_user AND u.status = :status AND u.id_role = :id_role ORDER BY last_name ASC", connection);
            command.Parameters.Add(new NpgsqlParameter("status", 1)); // activos
            command.Parameters.Add(new NpgsqlParameter("id_role", 2)); // id del rol de obrero (sin permisos)
            
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id_worker"]);
                string name = reader["first_name"].ToString();
                string last_name = reader["last_name"].ToString();

                DataRow turn_info = table.Select("idTurn = " + Convert.ToInt32(reader["turn"]))[0];
                int id_turn = int.Parse(turn_info["idTurn"].ToString());
                TimeSpan start_time = TimeSpan.Parse(turn_info["start"].ToString());
                TimeSpan end_time = TimeSpan.Parse(turn_info["end"].ToString());
                string description = turn_info["description"].ToString();
                Turn turn = new Turn(id_turn, start_time, end_time, description);

                workers.Add(new Worker(id, name, last_name, turn));
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

        public int NumberOfWorkers
        {
            get { return workers.Count; }
        }

        public List<Worker> Workers
        {
            get
            {
                return workers;
            }

            set
            {
                workers = value;
            }
        }

        public Worker this[int index]
        {
            get { return workers[index]; }
        }

        public List<Worker> List()
        {
            return new List<Worker>(workers);
        }

        public int Count()
        {
            return workers.Count();
        }

        public void Add(Worker worker)
        {
            this.workers.Add(worker);
        }

        public int GetIndex(int id_worker)
        {
            for (int i = 0; i < workers.Count; i++)
                if (workers[i].ID == id_worker) return i;
            return -1;
        }
    }
}
