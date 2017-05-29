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
    public class RecipeData: BD_Connector
    {
        public NpgsqlDataAdapter recipeAdapter()
        {
            NpgsqlDataAdapter recipeAdapter = new NpgsqlDataAdapter();

            recipeAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Recipe\";", Connection);

            return recipeAdapter;
        }
    }
}
