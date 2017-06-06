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
            data = recipeRawMaterial.getData(adapt, "Worker");

            DataTable recipeRawMaterialList = new DataTable();
            recipeRawMaterialList = data.Tables[0];

            return recipeRawMaterialList;
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


        public void updateDataNoAdapter(string idRecipe, string idRawMaterial)
        {
            string updateQuery;

            updateQuery = "UPDATE inkaart.\"Recipe-RawMaterial\" SET ";
            updateQuery = updateQuery + "status = 0 ";
            updateQuery = updateQuery + " WHERE \"idRecipe\"= " + idRecipe + "AND \"idRawMaterial\"= "+ idRawMaterial+" ;";
            recipeRawMaterial.execute(updateQuery);
        }
    }
}
