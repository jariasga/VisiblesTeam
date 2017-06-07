using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;

namespace InkaArt.Data.Warehouse
{
    public class RawWarehouseData : BD_Connector
    {
        public NpgsqlDataAdapter rawWarehouseAdapterMaterial()
        {
            NpgsqlDataAdapter rawWarehouseAdapterMaterial = new NpgsqlDataAdapter();

            rawWarehouseAdapterMaterial.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial\";", Connection);

            //rawMaterialAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"MateriaPrima\" WHERE idMateria = :idmateria;", Connection);
            //rawMaterialAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("idmateria", DbType.AnsiStringFixedLength));
            //rawMaterialAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            //rawMaterialAdapter.SelectCommand.Parameters[0].SourceColumn = "idmateria";

            return rawWarehouseAdapterMaterial;
        }

        public NpgsqlDataAdapter rawWarehouseAdapterProduct()
        {
            NpgsqlDataAdapter rawWarehouseAdapterProduct = new NpgsqlDataAdapter();

            rawWarehouseAdapterProduct.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial\";", Connection);

            //rawMaterialAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"MateriaPrima\" WHERE idMateria = :idmateria;", Connection);
            //rawMaterialAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("idmateria", DbType.AnsiStringFixedLength));
            //rawMaterialAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            //rawMaterialAdapter.SelectCommand.Parameters[0].SourceColumn = "idmateria";

            return rawWarehouseAdapterProduct;
        }

    }
}
