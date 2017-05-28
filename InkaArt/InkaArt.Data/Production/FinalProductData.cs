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
    public class FinalProductData : BD_Connector
    {
        public NpgsqlDataAdapter finalProductAdapter()
        {
            NpgsqlDataAdapter finalProductAdapter = new NpgsqlDataAdapter();

            finalProductAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Product\" WHERE username = :user;", Connection);

            return finalProductAdapter;
        }
    }
}
