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
    public class RawMaterialData: BD_Connector
    {
        public NpgsqlDataAdapter rawMaterialAdapter()
        {
            NpgsqlDataAdapter rawMaterialAdapter = new NpgsqlDataAdapter();
            rawMaterialAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial\";", Connection);

            return rawMaterialAdapter;
        }
    }

}
