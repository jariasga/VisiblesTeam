using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.ComponentModel;

namespace InkaArt.Classes
{

    public class BD_Connector
    {
        private NpgsqlConnection connection;
        private static NpgsqlConnectionStringBuilder connectionString;
        public static string serverAddress;
        public static string databaseName;
        private string uid, pwd;
        private int port;
        public BD_Connector()
        {
            ConnectionString = new NpgsqlConnectionStringBuilder();

            serverAddress = "skeletpiece.homeip.net";
            databaseName = "desarrolloprogramas1";

            ConnectionString.Host = serverAddress;
            ConnectionString.Database = databaseName;
            ConnectionString.Username = "admin";
            ConnectionString.Password = "fae48";
            ConnectionString.Pooling = true;
            ConnectionString.ApplicationName = Environment.UserName + "@" + Environment.UserDomainName + " on InkaArt Application";
        }

        private void connect()
        {
            try
            {
                Connection = new NpgsqlConnection(ConnectionString.ConnectionString);
                Connection.Open();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }
        }

        public DataSet getData(NpgsqlDataAdapter adapter, string srcTable)
        {
            if (Connection == null) connect();
            adapter.SelectCommand.Connection = Connection;
            DataSet data = new DataSet();
            adapter.Fill(data, srcTable);
            closeConnection();
            return data;
        }

        public int updateData(DataSet data, NpgsqlDataAdapter adap, string srcTable)
        {
            return callAdapter(data, adap, srcTable);
        }

        public int insertData(DataSet data, NpgsqlDataAdapter adap, string srcTable)
        {
            return callAdapter(data, adap, srcTable);
        }

        public int deleteData(DataSet data, NpgsqlDataAdapter adap, string srcTable)
        {
            return callAdapter(data, adap, srcTable);
        }

        public int callAdapter(DataSet data, NpgsqlDataAdapter adap, string srcTable)
        {
            int code = 0;
            if (Connection.State != System.Data.ConnectionState.Open) connect();
            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adap);
            adap.UpdateCommand = builder.GetUpdateCommand();
            adap.InsertCommand = builder.GetInsertCommand();
            adap.DeleteCommand = builder.GetDeleteCommand();
            adap.UpdateCommand.Connection = Connection;
            adap.InsertCommand.Connection = Connection;
            adap.DeleteCommand.Connection = Connection;

            try
            {
                adap.Update(data, srcTable);
            }
            catch (Exception ex)
            {
                code = System.Runtime.InteropServices.Marshal.GetExceptionCode();
                if (code == 23505) return 23505;
            }

            closeConnection();
            return code;
        }

        private void closeConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }

        public int execute(string command)
        {
            int rowsAffected = 0;
            if (Connection.State != System.Data.ConnectionState.Open) connect();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = command;
            cmd.Connection = Connection;
            try
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }
            finally
            {
                Connection.Close();
            }
            return rowsAffected;
        }

        

        public string ServerAddress { get { return serverAddress; } set { serverAddress = value; } }
        protected NpgsqlConnection Connection { get { return connection; } set { connection = value; } }
        public static NpgsqlConnectionStringBuilder ConnectionString { get { return connectionString; } set { connectionString = value; } }
        public string DatabaseName { get { return databaseName; } set { databaseName = value; } }
        public string Uid { get { return uid; } set { uid = value; } }
        public string Pwd { get { return pwd; } set { pwd = value; } }
        public int Port { get { return port; } set { port = value; } }
    }
}
