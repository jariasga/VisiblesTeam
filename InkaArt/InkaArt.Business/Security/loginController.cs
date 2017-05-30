using encription_SHA256;
using InkaArt.Data.Security;
using Npgsql;
using System.Data;

namespace InkaArt.Business.Security
{
    public class LoginController
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
            data = user.getData(adap, "User");

            //  Read data from DB
            int rows = data.Tables[0].Rows.Count;
            string userDB, keyDB;

            if (rows > 0)   //Encontro un usuario
            {
                userDB = data.Tables["User"].Rows[0]["username"].ToString();
                keyDB = data.Tables["User"].Rows[0]["password"].ToString(); ;
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

            return verified;
        }
    }
}
