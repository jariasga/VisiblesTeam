using encription_SHA256;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Security;
using InkaArt.Business.Model.Security;
using System.Data;

namespace InkaArt.Business.Security
{
    public class AuthenticationController
    {
        public bool CheckCredentials(string username, string password)
        {
            bool verified = false;
            SHA_2 sha = new SHA_2();
            string key = sha.encrypt(password);

            UserData user = new UserData();
            DataSet data = new DataSet();
            data = user.getDataset(user, username);

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


            if (string.Equals(key, keyDB) & string.Equals(user, userDB))
            {
                //  ToDo - GET ROLES

                //  GRANT ACCESS
                verified = true;
            }
            return verified;
        }
    }
}
