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

        public void updateStock(string idDoc, string idProd, int cant)
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

        public void updateReturn(string idDoc, string idProd, int cant)
        {
            string updateQuery;
            table = getData();
            updateQuery = "UPDATE inkaart.\"StockDocument\" SET ";
            updateQuery = updateQuery + "product_stock = " + cant + " ";
            updateQuery = updateQuery + " WHERE \"idDocument\"= " + idDoc + " AND \"product_id\"= " + idProd +
               " AND \"documentType\"= 'DEVOLUCION' " + " AND \"product_type\"= 'producto' ;";
            stockDocument.execute(updateQuery);
        }

        public void updateReturn(int id_stock, int pending)
        {
            string updateQuery;
            table = getData();
            updateQuery = "UPDATE inkaart.\"StockDocument\" SET product_stock = " + pending +
                " WHERE id = " + id_stock + ";";
            stockDocument.execute(updateQuery);
        }

        public void insertReturn(string idDoc, string idProd, int cant)
        {

            stockDocument = new StockDocumentData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();

            adapt = stockDocument.stockDocumentAdapter();

            string cantStr = cant.ToString();
            data.Clear();
            data = stockDocument.getData(adapt, "StockDocument");

            table = data.Tables["StockDocument"];
            stockDocument.execute(string.Format("INSERT INTO \"inkaart\".\"StockDocument\"(\"idDocument\", \"documentType\", product_id, product_stock, product_type) VALUES({0},  'DEVOLUCION', {1}, {2}, 'producto');", idDoc, idProd, cantStr));

        }

        public void insertData(string idFactura,string idProducto,int cant)
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

        public void updateInsertDevolution(int id_stock, int id_devolution, int id_product, int to_return, int total)
        {
            int pending = total - to_return;
            if (id_stock > 0)
                updateReturn(id_stock, pending);
            else
                insertReturn(id_devolution.ToString(), id_product.ToString(), pending);
        }
    }
}
