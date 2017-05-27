using encription_SHA256;
using InkaArt.Data.Security;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace InkaArt.Business.Security
{
    public class UserController
    {
        private UserData user;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;
        public bool checkCredentials(string loginUsername, string loginPass)
        {
            bool verified = false;
            SHA_2 sha = new SHA_2();
            string key = sha.encrypt(loginPass);

            user = new UserData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            user.connect();
            adap = user.userAdapter();
            adap.SelectCommand.Parameters[0].NpgsqlValue = loginUsername;

            data.Reset();
            data = user.getData(adap);

            //  Read data from DB
            int rows = data.Tables[0].Rows.Count;
            string userDB, keyDB;

            if (rows > 0)
            {
                userDB = data.Tables[0].Rows[0][3].ToString();
                keyDB = data.Tables[0].Rows[0][4].ToString(); ;
            }
            else
            {
                userDB = "wrongUsername";
                keyDB = "badPassword";
            }


            if (string.Equals(key, keyDB) & string.Equals(loginUsername, userDB))
            {
                //  ToDo - GET ROLES

                //  GRANT ACCESS
                verified = true;
            }

            //updateData();

            return verified;
        }

        public void updateData()
        {
            user.connect();

            adap.TableMappings.Add("User", "User");

            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(adap);

            adap.UpdateCommand = builder.GetUpdateCommand();
            adap.InsertCommand = builder.GetInsertCommand();
            adap.DeleteCommand = builder.GetDeleteCommand();

            //DataRow row = data.Tables[0];


            int rowsAffected = adap.UpdateCommand.ExecuteNonQuery();
        }
    }
}
