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
        private DataTable recipeList;
        private DataRow row;

        public RecipeController()
        {
            recipe = new RecipeData();
            data = new DataSet();
        }

        public DataTable getData()
        {
            //adapt = new NpgsqlDataAdapter();
            
            adapt = recipe.recipeAdapter();

            data.Reset();
            data = recipe.getData(adapt, "Recipe");
            
            recipeList = data.Tables["Recipe"];

            return recipeList;
        }

        public void insertData(string description, string version, string status, string idProduct)
        {
            adapt = recipe.recipeAdapter();

            data.Clear();
            data = recipe.getData(adapt, "Recipe");

            recipeList = data.Tables["Recipe"];

            row = recipeList.NewRow();

            row["description"] = description;
            row["version"] = version;
            row["status"] = status;
            row["idProduct"] = idProduct;

            recipeList.Rows.Add(row);
            int rowsAffected = recipe.insertData(data, adapt, "Recipe");
        }
    }
}
