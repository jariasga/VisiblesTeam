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
    public class StockDocumentData: BD_Connector
    {
        public NpgsqlDataAdapter stockDocumentAdapter()
        {
            NpgsqlDataAdapter stockDocumentAdapter = new NpgsqlDataAdapter();
            stockDocumentAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"StockDocument\";", Connection);
            return stockDocumentAdapter;
        }

    }
}
