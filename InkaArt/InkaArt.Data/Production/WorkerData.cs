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
    public class WorkerData:BD_Connector
    {
        public NpgsqlDataAdapter workerAdapter()
        {
            NpgsqlDataAdapter workerAdapter = new NpgsqlDataAdapter();
            workerAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Worker\";", Connection);

            return workerAdapter;
        }
    }
}
