using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Security
{
    public class UserData : BD_Connector
    {
        public NpgsqlDataAdapter userAdapter()
        {
            NpgsqlDataAdapter userAdapter = new NpgsqlDataAdapter();

            userAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"User\" WHERE username = :user;", Connection);
            userAdapter.SelectCommand.Parameters.Add(new NpgsqlParameter("user", DbType.AnsiStringFixedLength));
            userAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.Input;
            userAdapter.SelectCommand.Parameters[0].SourceColumn = "username";
            
            return userAdapter;
        }
        public DataSet getDataset(UserData user, string username)
        {
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
            user.connect();
            adap = user.userAdapter();
            adap.SelectCommand.Parameters[0].NpgsqlValue = username;
            return user.getData(adap,"Users");
        }
    }
}
