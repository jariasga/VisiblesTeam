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
        

        public void insertData()
        {
            user.connect();
            
            table = data.Tables["User"];

            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adap);

            adap.UpdateCommand = builder.GetUpdateCommand();
            adap.InsertCommand = builder.GetInsertCommand();
            adap.DeleteCommand = builder.GetDeleteCommand();

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
