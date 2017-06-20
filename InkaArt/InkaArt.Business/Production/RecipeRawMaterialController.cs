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
    public class RecipeRawMaterialController
    {
        private RecipeRawMaterialData recipeRawMaterial;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public RecipeRawMaterialController()
        {
            recipeRawMaterial = new RecipeRawMaterialData();
            data = new DataSet();
        }
        public DataTable getData()
        {
            
            adapt = recipeRawMaterial.recipeRawMaterialAdapter();

            data.Clear();
            data = recipeRawMaterial.getData(adapt, "Recipe-RawMaterial");
            
            table = data.Tables["Recipe-RawMaterial"];

            return table;
        }

        public void insertData(string idRecipe, string idRawMaterial, string materialCount)
        {
            adapt = recipeRawMaterial.recipeRawMaterialAdapter();

            data.Clear();
            data = recipeRawMaterial.getData(adapt, "Recipe-RawMaterial");

            table = data.Tables["Recipe-RawMaterial"];

            row = table.NewRow();

            row["idRecipe"] = idRecipe;
            row["idRawMaterial"] = idRawMaterial;
            row["materialCount"] = materialCount;
            row["status"] = "1";

            table.Rows.Add(row);
            int rowsAffected = recipeRawMaterial.insertData(data, adapt, "Recipe-RawMaterial");
        }
        public void insertDataNoAdapter(string idRecipe, string idRawMaterial, string materialCount)
        {
            adapt = recipeRawMaterial.recipeRawMaterialAdapter();

            data.Clear();
            data = recipeRawMaterial.getData(adapt, "Recipe-RawMaterial");

            table = data.Tables["Recipe-RawMaterial"];
            recipeRawMaterial.execute(string.Format("INSERT INTO \"inkaart\".\"Recipe-RawMaterial\"(\"idRecipe\", \"idRawMaterial\", \"materialCount\", status) VALUES({0},  {1}, {2}, {3});", idRecipe, idRawMaterial, materialCount, 1));
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

                    try
                    {
                        //idRecipe(0), idRawMaterial(1), quantity (2), status(3)
                        insertDataNoAdapter(values[0], values[1], values[2]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("No se pudo cargar el archivo.");
                        res = 1;
                    }

                }
            }

            return res;
        }


        public void updateDataNoAdapter(string idRecipe, string idRawMaterial,string quantity)
        {
            string updateQuery;
            table = getData();
            updateQuery = "UPDATE inkaart.\"Recipe-RawMaterial\" SET ";
            updateQuery = updateQuery + "status = 0 ";
            updateQuery = updateQuery + " WHERE \"idRecipe\"= " + idRecipe + " AND \"idRawMaterial\"= "+ idRawMaterial+
                " AND \"materialCount\"= " + quantity + " ;";
            recipeRawMaterial.execute(updateQuery);
        }
    }
}
