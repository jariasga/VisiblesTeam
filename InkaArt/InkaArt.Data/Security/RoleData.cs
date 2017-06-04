using InkaArt.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Security
{
    public class RoleData : BD_Connector
    {
        public NpgsqlDataAdapter roleAdapter()
        {
            NpgsqlDataAdapter roleAdapter = new NpgsqlDataAdapter();

            roleAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Role\";", Connection);

            return roleAdapter;
        }
    }
}
