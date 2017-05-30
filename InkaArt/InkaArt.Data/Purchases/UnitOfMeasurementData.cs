using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Purchases
{
    public class UnitOfMeasurementData : BD_Connector
    {
        public NpgsqlDataAdapter unitOfMeasurementAdapter()
        {
            NpgsqlDataAdapter unitOfMeasurementAdapter = new NpgsqlDataAdapter();
            unitOfMeasurementAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"UnitOfMeasurement\";", Connection);
            

            return unitOfMeasurementAdapter;
        }
    }
}
