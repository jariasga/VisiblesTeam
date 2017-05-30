using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Purchases
{
    public class RawMaterial_SupplierData : BD_Connector
    {
        public NpgsqlDataAdapter rawMaterial_SupplierAdapter()
        {
            NpgsqlDataAdapter rawMaterial_SupplierAdapter = new NpgsqlDataAdapter();

            rawMaterial_SupplierAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial-Supplier\" WHERE idRawMaterial = :rawMaterial ;", Connection);
            rawMaterial_SupplierAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("rawMaterial", DbType.Int32));
            rawMaterial_SupplierAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            rawMaterial_SupplierAdapter.SelectCommand.Parameters[0].SourceColumn = "idRawMaterial";

            //rawMaterial_SupplierAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial-Supplier\";", Connection);
            return rawMaterial_SupplierAdapter;
        }
    }
}
