using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace InkaArt.Classes
{

    public class BD_Connector
    {
        protected NpgsqlConnection connection;
        public static NpgsqlConnectionStringBuilder connectionString;
        private string serverAddress;
        private string databaseName;
        private string uid, pwd;
        private int port;
        public BD_Connector()
        {
            connectionString = new NpgsqlConnectionStringBuilder();

            connectionString.Host = "skeletpiece.homeip.net";
            connectionString.Database = "desarrolloprogramas1";
            connectionString.Username = "admin";
            connectionString.Password = "fae48";
            connectionString.Pooling = true;
        }

        public void connect()
        {
            try
            {
                Connection = new NpgsqlConnection(connectionString.ConnectionString);
                Connection.Open();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }
        }

        public DataSet getData(NpgsqlDataAdapter adapter)
        {
            DataSet data = new DataSet();

            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adapter);
            
            adapter.Fill(data, Connection.ConnectionString);

            Connection.Close();

            return data;
        }

        private void execute(string command)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandText = command;
            cmd.Connection = Connection;
            try
            {
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.ToString());
            }
        }

        public void commit()
        {
            execute("COMMIT;");
        }        


        public string ServerAddress { get => serverAddress; set => serverAddress = value; }
        public int Port { get => port; set => port = value; }
        public string DatabaseName { get => databaseName; set => databaseName = value; }
        private string Uid { get => uid; set => uid = value; }
        private string Pwd { get => pwd; set => pwd = value; }
        protected NpgsqlConnection Connection { get => connection; set => connection = value; }
    }
}
