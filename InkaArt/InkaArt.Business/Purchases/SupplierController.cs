using InkaArt.Data.Purchases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace InkaArt.Business.Purchases
{
    public class SupplierController
    {
        private SupplierData supplier;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            supplier = new SupplierData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            supplier.connect();
            adap = supplier.supplierAdapter();

            data.Reset();
            data = supplier.getData(adap, "Supplier");

            DataTable supplierList = new DataTable();
            supplierList = data.Tables[0];

            return supplierList;
        }
    }
}
