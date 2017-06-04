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
    public class SupplierData: BD_Connector
    {
        public NpgsqlDataAdapter supplierAdapter()
        {
            NpgsqlDataAdapter supplierAdapter = new NpgsqlDataAdapter();
            supplierAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Supplier\";", Connection);
            
            return supplierAdapter;
        }
    }
}
