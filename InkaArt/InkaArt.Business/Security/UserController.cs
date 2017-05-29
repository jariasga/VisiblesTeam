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

        public UserController()
        {
            user = new UserData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
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

        public int updateData()
        {
            user.connect();

            table = data.Tables["User"];

            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adap);

            adap.UpdateCommand = builder.GetUpdateCommand();

            row = table.NewRow();

            row["username"] = "test1";
            row["password"] = "test1";
            row["status"] = 1;
            row["description"] = "descrip";
            

            table.Rows.Add(row);

            int rowsAffected = adap.Update(data, "User");

            user.closeConnection();

            return rowsAffected;
        }

        public void insertData()
        {
            user.connect();
            
            table = data.Tables["User"];

            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adap);
            
            adap.InsertCommand = builder.GetInsertCommand();            

            row = table.NewRow();
            
            row["username"] = "test1";
            row["password"] = "test1";
            row["status"] = 1;
            row["description"] = "descrip";

            table.Rows.Add(row);
            
            int rowsAffected = adap.Update(data, "User");

            user.closeConnection();
        }
    }
}
