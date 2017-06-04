using encription_SHA256;
using InkaArt.Data.Security;
using Npgsql;
using System.Data;

namespace InkaArt.Business.Security
{
    public class LoginController
    {
        private UserController user;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataRow row;

        public LoginController()
        {

            user = new UserController();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
        }
        public bool checkCredentials(string loginUsername, string loginPass)
        {
            bool verified = false;
            SHA_2 sha = new SHA_2();
            string key = sha.encrypt(loginPass);
            
            row = user.getUserRow(loginUsername);

            //  Read data from DB
            
            string userDB, keyDB;

            if (row != null)   //Encontro un usuario
            {
                userDB = row["username"].ToString();
                keyDB = row["password"].ToString();
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
