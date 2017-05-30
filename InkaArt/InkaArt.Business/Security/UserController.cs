using encription_SHA256;
using InkaArt.Data.Security;
using Npgsql;
using System.Data;

namespace InkaArt.Business.Security
{
    public class UserController
    {
        private UserData user;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private SHA_2 sha;

        public UserController()
        {
            user = new UserData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
            sha = new SHA_2();
        }

        public DataTable showData()
        {
            user.connect();

            adap = user.userAdapter();
            adap.SelectCommand.CommandText = "SELECT * FROM inkaart.\"User\";";
            adap.SelectCommand.Parameters.Clear();
            
            data = user.getData(adap, "User");
            
            table = data.Tables["User"];

            user.closeConnection();
            return table;
        }

        public int updateData(string username, string description, int status, string password)
        {
            user.connect();

            table = data.Tables["User"];

            row = table.NewRow();

            row["username"] = username;
            row["password"] = sha.encrypt(password);
            row["status"] = status;
            row["description"] = description;
            
            table.Rows.Add(row);

            int rowsAffected = user.updateData(data, adap, "User");

            return rowsAffected;
            /*
             * ================================================
             * TEST LINE TO INSERT DATA
            insertData();
             * ================================================
            */
        }

        public int insertData(string username, string description, int status, ref string password)
        {
            //  Get connection string and connect to the database
            user.connect();
            
            //  Get the dataset table to modify
            table = data.Tables["User"];

            //  Create a new row for the table (Users)

            row = table.NewRow();

            password = sha.getMiniSHA();
            //  Add the necesary fields
            row["username"] = username;
            row["password"] = sha.encrypt(password);
            row["status"] = status;
            row["description"] = description;

            //  Add the row created into the table
            table.Rows.Add(row);

            //  Push the data to the database (Will only work once, as the DB only accepts unique users, please delete the user created)
            int rowsAffected = user.insertData(data, adap, "User");
            return rowsAffected;
        }

        public DataRow getUserRow(string username)
        {
            user.connect();
            adap = user.userAdapter();
            adap.SelectCommand.Parameters[0].NpgsqlValue = username;

            data.Clear();
            data = user.getData(adap, "User");

            if (data.Tables["User"].Rows.Count > 0) return data.Tables["User"].Rows[0];
            else return null;
        }

        public DataRow getUserRowbyID(int id)
        {
            table = showData();
            //table.Rows.IndexOf();

            if (data.Tables["User"].Rows.Count > 0) return data.Tables["User"].Rows[0];
            else return null;
        }
    }
}
