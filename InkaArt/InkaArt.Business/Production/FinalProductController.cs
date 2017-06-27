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
            
            adapt = finalProduct.finalProductAdapter();

            data.Reset();
            data = finalProduct.getData(adapt, "Product");

            DataTable finalProductList = new DataTable();
            finalProductList = data.Tables[0];

            return finalProductList;
        }

        public void insertData(string name, string description, string localP, string exportP, string actualS, string logicS)
        {
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


        public void insertDataNoAdapter(string name, string description, string localPrice, string basePrice, string exportPrice, string actualStock, string logicalStock, string status)
        {
            adapt = finalProduct.finalProductAdapter();

            data.Clear();
            data = finalProduct.getData(adapt, "Product");

            table = data.Tables["Product"];
            finalProduct.execute(string.Format("INSERT INTO \"inkaart\".\"Product\"( name, description,\"localPrice\",\"basePrice\",\"exportPrice\",\"actualStock\",\"logicalStock\",status) VALUES('{0}',  '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", name,  description,  localPrice,  basePrice,  exportPrice,  actualStock,  logicalStock,  status));
        }



        public int massiveUpload(string filename)
        {
            table = getData();     // obtenemos la tabla de productos
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
                        insertDataNoAdapter(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
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

        public int updateData(string id,string localPrice, string exportPrice)
        {
            int retorno = 0;
            adapt = finalProduct.finalProductAdapter();
            double basePrice=0;
            data.Clear();
            data = finalProduct.getData(adapt, "Product");

            table = data.Tables["Product"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idProduct"].ToString(), id) == 0)
                {
                    table.Rows[i]["localPrice"] = localPrice;
                    table.Rows[i]["exportPrice"] = exportPrice;
                    basePrice = double.Parse(table.Rows[i]["basePrice"].ToString());
                    break;
                }
            }
            //retorno es 0 si no hace update porque los precios son menores al base y uno si es satisfactorio
            if (basePrice <= double.Parse(localPrice) && basePrice <= double.Parse(exportPrice))
            {
                int rowUpdated = finalProduct.updateData(data, adapt, "Product");
                retorno = 1;
            }
            return retorno;
            
        }   

        public int updateStock(int h, int p,int r, int hl, int pl, int rl)
        {


            adapt = finalProduct.finalProductAdapter();
            data = finalProduct.getData(adapt, "Product");

            table = data.Tables["Product"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["name"].ToString()=="Huaco")
                {
                    table.Rows[i]["actualStock"] = h;
                    table.Rows[i]["logicalStock"] = hl;
                }
                if (table.Rows[i]["name"].ToString() == "Piedra Huamanga")
                {
                    table.Rows[i]["actualStock"] = p;
                    table.Rows[i]["logicalStock"] = pl;
                }
                if (table.Rows[i]["name"].ToString() == "Retablo")
                {
                    table.Rows[i]["actualStock"] = r;
                    table.Rows[i]["logicalStock"] = rl;
                }
            }
            return finalProduct.updateData(data, adapt, "Product");
        }
    }
}
