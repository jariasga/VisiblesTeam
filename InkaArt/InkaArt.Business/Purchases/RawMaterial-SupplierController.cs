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
    public class RawMaterial_SupplierController
    {
        private RawMaterial_SupplierData rawMaterial_supplier;
        private NpgsqlDataAdapter adap;
        private DataSet data;

        public DataTable getDataSuppliers(int idRawMaterial)
        {
            rawMaterial_supplier = new RawMaterial_SupplierData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            rawMaterial_supplier.connect();
            adap = rawMaterial_supplier.rawMaterial_SupplierAdapter();
            adap.SelectCommand.Parameters[0].NpgsqlValue = idRawMaterial;
            
            data.Reset();
            data = rawMaterial_supplier.getData(adap, "RawMaterial-Supplier");
            
            DataTable rawMaterial_supplierList = new DataTable();
            rawMaterial_supplierList = data.Tables[0];

            return rawMaterial_supplierList;
        }

    }
}
