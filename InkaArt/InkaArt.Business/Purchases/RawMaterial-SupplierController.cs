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

        public RawMaterial_SupplierController()
        {
            rawMaterial_supplier = new RawMaterial_SupplierData();

        }
        /* public DataTable getDataSuppliers(int idRawMaterial)
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
         }*/
        public DataTable getDataSuppliers(string idMat = "", string idSup = "")
        {
            int intIdMat = -1, intAux; int intIdSup = -1;
            if (!idMat.Equals("")) if (int.TryParse(idMat, out intAux)) intIdMat = int.Parse(idMat);
            if (!idSup.Equals("")) if (int.TryParse(idSup, out intAux)) intIdSup = int.Parse(idSup);
            return rawMaterial_supplier.GetRmSup(intIdMat, intIdSup);
        }
        public void UpdateRM_Sup(string idMat, string idSup, string price)
        {
            double douPrice = -1;
            if (!price.Equals("0")) if (double.TryParse(price, out douPrice)) douPrice = double.Parse(price);
            rawMaterial_supplier.UpdateRM_Sup(idMat, idSup, douPrice);
        }
        public void insertRM_Sup(string idMat,int idSup,string price)
        {
            double douPrice = 0;
            int intIdMat = -1, intAux;
            if (!idMat.Equals("")) if (int.TryParse(idMat, out intAux)) intIdMat = int.Parse(idMat);
            if (!price.Equals("0")) if (double.TryParse(price, out douPrice)) douPrice = double.Parse(price);
            rawMaterial_supplier.InsertRM_Sup(intIdMat, idSup, douPrice);
        }
    }
}
