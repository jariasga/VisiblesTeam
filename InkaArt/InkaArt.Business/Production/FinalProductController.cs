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
    public class FinalProductController
    {
        private FinalProductData finalProduct;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public FinalProductController()
        {
            finalProduct = new FinalProductData();
            data = new DataSet();
        }

        public DataTable getData()
        {
            //adapt = new NpgsqlDataAdapter();

            finalProduct.connect();
            adapt = finalProduct.finalProductAdapter();

            data.Reset();
            data = finalProduct.getData(adapt, "Product");

            DataTable finalProductList = new DataTable();
            finalProductList = data.Tables[0];

            return finalProductList;
        }

        public void insertData(string name, string description, string localP, string exportP, string actualS, string logicS)
        {
            finalProduct.connect();
            adapt = finalProduct.finalProductAdapter();

            data.Clear();
            data = finalProduct.getData(adapt, "Product");

            table = data.Tables["Product"];

            row = table.NewRow();

            row["name"] = name;
            row["description"] = description;
            row["localPrice"] = localP;
            row["basePrice"] = exportP;
            row["actualStock"] = actualS;
            row["logicalStock"] = logicS;
            row["status"] = "1";

            table.Rows.Add(row);
            int rowsAffected = finalProduct.insertData(data, adapt, "Product");
        }

        public void updateData(string id,string localPrice, string exportPrice)
        {
            finalProduct.connect();
            adapt = finalProduct.finalProductAdapter();

            data.Clear();
            data = finalProduct.getData(adapt, "Product");

            table = data.Tables["Product"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idProduct"].ToString(), id) == 0)
                {
                    table.Rows[i]["localPrice"] = localPrice;
                    table.Rows[i]["exportPrice"] = exportPrice;
                    break;
                }
            }
            int rowUpdated = finalProduct.updateData(data, adapt, "Product");
        }   
    }
}
