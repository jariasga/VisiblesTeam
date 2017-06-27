using InkaArt.Data.Purchases;
using Npgsql;
using System.Data;
using System.IO;
using System;

namespace InkaArt.Business.Purchases
{
    public class RawMaterial_SupplierController
    {
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private RawMaterial_SupplierData rawMaterial_supplier;

        public RawMaterial_SupplierController()
        {
            rawMaterial_supplier = new RawMaterial_SupplierData();

        }
        public DataTable getData()
         {
            rawMaterial_supplier = new RawMaterial_SupplierData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            adap = rawMaterial_supplier.rawMaterial_SupplierAdapter();

            data.Reset();
            data = rawMaterial_supplier.getData(adap, "RawMaterial-Supplier");

            table = new DataTable();
            table = data.Tables[0];
            return table;
            
         }
        public void UpdateRM_Sup(string idRM_Sup,string idMat, string idSup, string price,string status)
        {
            double douPrice = 0;
            if (!price.Equals("0")) if (double.TryParse(price, out douPrice)) douPrice = double.Parse(price);
            table = data.Tables["RawMaterial-Supplier"];
            rawMaterial_supplier.execute(string.Format("UPDATE \"inkaart\".\"RawMaterial-Supplier\" " +
                        "SET price = {0}, status='{1}'" +
                        "WHERE id_rawmaterial_supplier = {2}", price,status, idRM_Sup));

            
            rawMaterial_supplier.updateData(data, adap, "RawMaterial-Supplier");
        }
        public int insertRM_Sup(string idMat,string idSup,string price,string status)
        {
            double douPrice = 0;
            if (!price.Equals("0")) if (double.TryParse(price, out douPrice)) douPrice = double.Parse(price);
            getData();
            table = data.Tables["RawMaterial-Supplier"];
            row = table.NewRow();

            row["id_raw_material"] = idMat;
            row["id_supplier"] = idSup;
            row["price"] = price;
            row["status"] = status;
            table.Rows.Add(row);

            return rawMaterial_supplier.insertData(data, adap, "RawMaterial-Supplier");
        }
        public int massiveUpload(string filename)
        {
            table = getData();     // obtenemos la tabla de productos
            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    try
                    {
                        //string idMat,string idSup,string price,string status)
                        insertRM_Sup(values[0], values[1], values[2], "Activo");
                    }
                    catch (Exception e)
                    {
                        return 1;
                    }

                }
            }
            return 0;
        }
    }
}
