using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;

namespace InkaArt.Business.Algorithm
{
    public class ProcessController
    {
        private List<Process> processes;

        public ProcessController()
        {
            processes = new List<Process>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Process\"", connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string description = reader.GetString(1);
                int number_of_jobs = reader.GetInt32(2);
                processes.Add(new Process(id, description, number_of_jobs));
            }

            connection.Close();
        }
    }
}
