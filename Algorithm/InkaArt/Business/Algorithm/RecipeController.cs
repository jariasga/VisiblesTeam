using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Common;
using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    class RecipeController
    {
        private List<Recipe> recipes;

        public RecipeController()
        {
            recipes = new List<Recipe>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = DatabaseConnection.ConnectionString();
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Recipe\" WHERE status = :status",
                connection);

            command.Parameters.AddWithValue("status", NpgsqlDbType.Integer, 1);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_recipe = reader.GetInt32(0);
                string description = reader.GetString(1);
                int id_product = reader.GetInt32(4);
                recipes.Add(new Recipe(id_recipe, id_product, description));
            }

            connection.Close();
        }

        public Recipe GetByID(int id)
        {
            foreach (Recipe recipe in recipes)
                if (recipe.ID == id) return recipe;
            return null;
        }

        public Recipe GetByDescription(string description)
        {
            foreach (Recipe recipe in recipes)
                if (recipe.Description == description) return recipe;
            return null;
        }

        public Recipe this[int index]
        {
            get { return recipes[index]; }
        }

        public int Count()
        {
            return recipes.Count;
        }
    }
}
