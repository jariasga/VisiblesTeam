using InkaArt.Data.Purchases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using InkaArt.Data.Warehouse;

namespace InkaArt.Business.Warehouse
{
    public class StockDocumentController
    {
        private StockDocumentData stockDocument;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            stockDocument = new StockDocumentData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();

            adapt = stockDocument.stockDocumentAdapter();

            data.Reset();
            data = stockDocument.getData(adapt, "StockDocument");

            DataTable stockDocumentList = new DataTable();
            stockDocumentList = data.Tables[0];
            return stockDocumentList;
        }

        public void updateStock(string idDoc, string idProd, int cant,string date)
        {
            string updateQuery;
            //string materiaPrima = "materia_prima";
            table = getData();
            updateQuery = "UPDATE inkaart.\"StockDocument\" SET ";
            updateQuery = updateQuery + "product_stock = "+cant+" ";
            //updateQuery = updateQuery + "fecha = " + date;
            updateQuery = updateQuery + " WHERE \"idDocument\"= " + idDoc + " AND \"product_id\"= " + idProd +
                " AND \"product_type\"= 'materia_prima' ;";
            stockDocument.execute(updateQuery);
        }

        public void insertData(string idFactura,string idProducto,int cant,string fecha)
        {
            stockDocument = new StockDocumentData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();

            adapt = stockDocument.stockDocumentAdapter();

            string cantStr = cant.ToString();
            data.Clear();
            data = stockDocument.getData(adapt, "StockDocument");

            table = data.Tables["StockDocument"];
            stockDocument.execute(string.Format("INSERT INTO \"inkaart\".\"StockDocument\"(\"idDocument\", \"documentType\", product_id, product_stock, product_type) VALUES({0},  'FACTURA', {1}, {2}, 'materia_prima');", idFactura ,idProducto, cantStr));

        }
    }
}
