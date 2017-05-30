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
    public class UnitData: BD_Connector
    {
        public NpgsqlDataAdapter unitAdapter()
        {
            NpgsqlDataAdapter unitAdapter = new NpgsqlDataAdapter();
            unitAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"UnitOfMeasurement\";", Connection);

            return unitAdapter;
        }
    }
}
