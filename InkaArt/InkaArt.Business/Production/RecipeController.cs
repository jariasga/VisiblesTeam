using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Production;
using NpgsqlTypes;
using Npgsql;
using System.IO;

namespace InkaArt.Business.Production
{
    public class RecipeController
    {
        private RecipeData recipe;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable recipeList;
        private DataRow row;
        private DataTable table;

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

        public int massiveUpload(string filename)
        {
            table = getData();     // obtenemos la tabla de materia prima
            int res = 0;
            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    try{
                        //description(0), version(1), status (2), idProduct(3)
                        insertData(values[0], values[1], values[2], values[3]);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("No se pudo cargar el archivo.");
                        res = 1;
                    }
                    
                }
            }
            return res;
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
