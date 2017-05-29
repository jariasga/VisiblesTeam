using InkaArt.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Security
{
    public class WorkerData : BD_Connector
    {        
        public NpgsqlDataAdapter workerAdapter()
        {
            NpgsqlDataAdapter workerAdapter = new NpgsqlDataAdapter();

            workerAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Worker\";", Connection);

            return workerAdapter;
        }
    }
}
