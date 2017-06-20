using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Production
{
    public class ProcessProductData: BD_Connector
    {
        public NpgsqlDataAdapter processProductsAdapter()
        {
            NpgsqlDataAdapter processProductsAdapter = new NpgsqlDataAdapter();
            processProductsAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Process-Product\" WHERE idProcess = :process;", Connection);
            processProductsAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("process", DbType.Int32));
            processProductsAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            processProductsAdapter.SelectCommand.Parameters[0].SourceColumn = "idProcess";

            return processProductsAdapter;
        }

        public NpgsqlDataAdapter productProcesesAdapter()
        {
            NpgsqlDataAdapter productProcesesAdapter = new NpgsqlDataAdapter();
            productProcesesAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Process-Product\" WHERE idProduct = 1;", Connection);
            productProcesesAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("product", DbType.Int32));
            productProcesesAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            productProcesesAdapter.SelectCommand.Parameters[0].SourceColumn = "idProduct";

            return productProcesesAdapter;
        }

        public NpgsqlDataAdapter productProcessAdapter()
        {
            NpgsqlDataAdapter productProcessAdapter = new NpgsqlDataAdapter();
            productProcessAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Process-Product\";", Connection);

            return productProcessAdapter;
        }

    }
}
