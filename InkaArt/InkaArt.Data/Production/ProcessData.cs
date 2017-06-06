using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Production
{
    public class ProcessData: BD_Connector
    {
        public NpgsqlDataAdapter processAdapter()
        {
            NpgsqlDataAdapter processAdapter = new NpgsqlDataAdapter();
            processAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Process\";", Connection);

            return processAdapter;
        }

        public NpgsqlDataReader processAdapterForUpdate(string query)
        {
            //NpgsqlDataAdapter processAdapter = new NpgsqlDataAdapter();

            //query = "Select * from inkaart.\"Warehouse\";";
            NpgsqlCommand command = new NpgsqlCommand(query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            //closeConnection();
            return dr;
        } 
    }
}
