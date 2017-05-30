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
    public class TurnWorkerData:BD_Connector
    {
        public NpgsqlDataAdapter turnWorkerAdapter()
        {
            NpgsqlDataAdapter turnWorkerAdapter = new NpgsqlDataAdapter();
            turnWorkerAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Turn-Worker\";", Connection);

            return turnWorkerAdapter;
        }
    }
}
