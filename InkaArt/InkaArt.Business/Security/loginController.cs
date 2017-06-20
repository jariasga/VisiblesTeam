using encription_SHA256;
using InkaArt.Data.Security;
using Npgsql;
using System;
using System.Data;
using sendEmail;
using System.Windows.Forms;

namespace InkaArt.Business.Security
{
    public class LoginController
    {
        private UserController user;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataRow row;
        public static int userID, roleID;
        public static string userName, firstName, lastName;
        public static bool needPassChange, validConnection;

        public LoginController()
        {
            user = new UserController();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
        }
        public bool checkCredentials(string loginUsername, string loginPass, out bool active)
        {
            bool verified = false;
            SHA_2 sha = new SHA_2();
            string key = sha.encrypt(loginPass);            
            
            row = user.getUserRow(loginUsername);
            active = true;
            //  Read data from DB
            if (row == null)
            {
                validConnection = false;
                return false;
            }

            validConnection = true;
            string userDB, keyDB;

            if (row != null)   //Encontro un usuario
            {
                userDB = row["username"].ToString();
                userName = userDB;
                keyDB = row["password"].ToString();
                userID = Convert.ToInt32(row["id_user"]);
                roleID = Convert.ToInt32(row["id_role"]);

                if (Convert.ToInt32(row["Status"]) != 1) active = false;

                needPassChange = (bool) row["need_pass_reset"];
            }
            else
            {
                userDB = "wrongUsername";
                keyDB = "badPassword";
            }

            if (string.Equals(key, keyDB) & string.Equals(loginUsername, userDB))
            {
                verified = true;
            }
            return verified;
        }
        public void sendResetPassword(string username)
        {
            user.sendResetPass(username);
        }
    }
}
