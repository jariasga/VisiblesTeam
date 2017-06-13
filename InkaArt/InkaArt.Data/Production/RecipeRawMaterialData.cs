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
    public class RecipeRawMaterialData:BD_Connector
    {
        public NpgsqlDataAdapter recipeRawMaterialAdapter()
        {
            NpgsqlDataAdapter recipeRawMaterialAdapter = new NpgsqlDataAdapter();
            recipeRawMaterialAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM \"inkaart\".\"Recipe-RawMaterial\";", Connection);

            return recipeRawMaterialAdapter;
        }
    }
}
