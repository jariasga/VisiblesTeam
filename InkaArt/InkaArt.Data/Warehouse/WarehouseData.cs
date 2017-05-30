using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Warehouse
{
    public class WarehouseData : BD_Connector
    {
        public NpgsqlDataReader warehouseAdapter(string query)
        {
            NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();

            //query = "Select * from inkaart.\"Warehouse\"";
            NpgsqlCommand command = new NpgsqlCommand(query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();
            
            //closeConnection();
            return dr;
        }
        
    }
}
