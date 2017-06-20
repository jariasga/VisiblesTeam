using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;
using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    public class RecipeController
    {
        private List<Recipe> recipes;

        public RecipeController()
        {
            recipes = new List<Recipe>();
        }

        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Recipe\" WHERE status = :status", connection);
            command.Parameters.AddWithValue("status", NpgsqlDbType.Integer, 1);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id_recipe = reader.GetInt32(0);
                string description = reader.GetString(1);
                string version = reader.GetString(2);
                int id_product = reader.GetInt32(4);
                recipes.Add(new Recipe(id_recipe, id_product, description, version));
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
        
        public int GetIndex(int id_recipe)
        {
            for (int i = 0; i < recipes.Count; i++)
                if (recipes[i].ID == id_recipe) return i;
            return -1;
        }

        public Recipe GetByVersion(string version)
        {
            foreach (Recipe recipe in recipes)
                if (recipe.Version == version) return recipe;
            return null;
        }

        public Recipe this[int index]
        {
            get { return recipes[index]; }
        }

        public int NumberOfRecipes
        {
            get { return recipes.Count; }
        }

        public List<Recipe> List()
        {
            return new List<Recipe>(recipes);
        }
    }
}
