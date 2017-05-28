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
    public class RawMaterialData : BD_Connector
    {
        public NpgsqlDataAdapter rawMaterialAdapter()
        {
            NpgsqlDataAdapter rawMaterialAdapter = new NpgsqlDataAdapter();
            
            rawMaterialAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"RawMaterial\";", Connection);
            //rawMaterialAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"MateriaPrima\" WHERE idMateria = :idmateria;", Connection);
            //rawMaterialAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("idmateria", DbType.AnsiStringFixedLength));
            //rawMaterialAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            //rawMaterialAdapter.SelectCommand.Parameters[0].SourceColumn = "idmateria";

            return rawMaterialAdapter;
        }
    }
}
