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
    public class TurnData: BD_Connector
    {
        public NpgsqlDataAdapter turnAdapter()
        {
            NpgsqlDataAdapter turnAdapter = new NpgsqlDataAdapter();
            turnAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Turn\";", Connection);

            return turnAdapter;
        }
         
    }
}
