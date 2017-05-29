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

        public DataTable getData()
        {
            finalProduct = new FinalProductData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();

            finalProduct.connect();
            adapt = finalProduct.finalProductAdapter();

            data.Reset();
            data = finalProduct.getData(adapt, "Product");

            DataTable finalProductList = new DataTable();
            finalProductList = data.Tables[0];

            return finalProductList;
        }
    }
}
