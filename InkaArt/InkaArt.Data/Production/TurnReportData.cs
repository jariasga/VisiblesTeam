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
    public class TurnReportData:BD_Connector
    {
        public NpgsqlDataAdapter turnReportAdapter()
        {
            NpgsqlDataAdapter turnReportAdapter = new NpgsqlDataAdapter();
            turnReportAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"TurnReport\";", Connection);

            return turnReportAdapter;
        }
    }
}
