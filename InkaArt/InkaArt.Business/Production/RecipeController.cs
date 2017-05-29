using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Production;
using NpgsqlTypes;
using Npgsql;

namespace InkaArt.Business.Production
{
    public class RecipeController
    {
        private RecipeData recipe;
        private NpgsqlDataAdapter adapt;
        private DataSet data;

        public DataTable getData()
        {
            recipe = new RecipeData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();

            recipe.connect();
            adapt = recipe.recipeAdapter();

            data.Reset();
            data = recipe.getData(adapt, "Recipe");

            DataTable recipeList = new DataTable();
            recipeList = data.Tables[0];

            return recipeList;
        }
    }
}
