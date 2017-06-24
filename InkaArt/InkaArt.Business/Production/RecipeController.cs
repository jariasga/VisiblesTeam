using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Production;
using InkaArt.Business.Purchases;
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
            //adapt = new NpgsqlDataAdapter();            
            recipe = new RecipeData();
            adapt = recipe.recipeAdapter();
            data = new DataSet();
        }

        public void updateRecipeStatus()
        {
            data.Reset();
            data = recipe.getData(adapt, "Recipe");
            recipeList = data.Tables["Recipe"];

            RecipeRawMaterialController controlrrm = new RecipeRawMaterialController();
            DataTable r_rmList = controlrrm.getData();

            RawMaterialController controlrm = new RawMaterialController();
            DataTable rmList = controlrm.getData();

            int activar = 0;

            for(int i = 0; i < recipeList.Rows.Count; i++)
            {
                string idRecipe = recipeList.Rows[i]["idRecipe"].ToString();
                for(int j = 0; j < r_rmList.Rows.Count; j++)
                {
                    if (r_rmList.Rows[j]["idRecipe"].ToString() == idRecipe 
                        && r_rmList.Rows[j]["status"].ToString()=="1")
                    {
                        string idRm = r_rmList.Rows[j]["idRawMaterial"].ToString();
                        for(int k = 0; k < rmList.Rows.Count; k++)
                        {
                            if (rmList.Rows[k]["id_raw_material"].ToString() == idRm)
                            {
                                if (rmList.Rows[k]["status"].ToString() == "Inactivo" && activar == 0)//hay una materia prima inactiva en la receta
                                {
                                    recipe.execute(string.Format("UPDATE \"inkaart\".\"Recipe\" " +
                                        "SET status = {0} WHERE \"idRecipe\" = '{1}'", 0,idRecipe));
                                    activar = 1;
                                    break;
                                }
                            }
                        }
                    }

                }

                //Reactivar la materia prima
                if (activar == 0)
                {
                    if (recipeList.Rows[i]["status"].ToString() == "0")
                        recipe.execute(string.Format("UPDATE \"inkaart\".\"Recipe\" " +
                                "SET status = {0} WHERE \"idRecipe\" = '{1}'", 1, idRecipe));
                }

            }
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
