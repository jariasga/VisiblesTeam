using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using InkaArt.Classes;

namespace InkaArt.Data.Warehouse
{
    public class PWarehouseData:BD_Connector
    {
        private DataSet data;

        public PWarehouseData()
        {
            data = new DataSet();
        }

        public NpgsqlDataAdapter pWarehouseAdapter()
        {
            NpgsqlDataAdapter rmWarehouseAdapter = new NpgsqlDataAdapter();
            rmWarehouseAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Product-Warehouse\"", Connection);
            return rmWarehouseAdapter;
        }




    }
}
