using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Common;
using InkaArt.Data.Algorithm;
using Npgsql;

namespace InkaArt.Business.Algorithm
{
    class ProcessController
    {
        private List<Process> processes;

        public ProcessController()
        {
            processes = new List<Process>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Process\"", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string description = reader.GetString(1);
                int position_count = reader.GetInt32(2);
                processes.Add(new Process(id, description, position_count));
            }

            connection.Close();
        }

        public int Count
        {
            get { return this.processes.Count; }
        }

        public Process GetByID(int id)
        {
            foreach (Process process in processes)
                if (process.ID == id) return process;
            return null;
        }
    }
}
