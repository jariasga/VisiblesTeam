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
/*        public DataTable getDataWithFilters()
        {
            supplier = new SupplierData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            supplier.connect();
            adap = supplier.supplierAdapter();
            data.Reset();
            adap.SelectCommand.CommandText = "SELECT * FROM inkaart.\"User\" WHERE username = :user;";
            //            userAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"User\" WHERE username = :user;", Connection);
            //            userAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("user", DbType.AnsiStringFixedLength));
            //            userAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            //            userAdapter.SelectCommand.Parameters[0].SourceColumn = "username";
            return supplierList;
        }*/
    }
}
