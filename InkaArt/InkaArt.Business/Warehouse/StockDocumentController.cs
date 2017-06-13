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
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            stockDocument = new StockDocumentData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            adap = stockDocument.stockDocumentAdapter();

            data.Reset();
            data = stockDocument.getData(adap, "StockDocument");

            DataTable stockDocumentList = new DataTable();
            stockDocumentList = data.Tables[0];
            return stockDocumentList;
        }
    }
}
