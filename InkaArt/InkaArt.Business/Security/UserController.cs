using encription_SHA256;
using InkaArt.Data.Security;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;
using System.IO;

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
            adap = user.userAdapter();
            adap.SelectCommand.CommandText = "SELECT * FROM inkaart.\"User\";";
            adap.SelectCommand.Parameters.Clear();
            
            data = user.getData(adap, "User");
            
            table = data.Tables["User"];
            
            return table;
        }

        public int updatePassword(int idUser, string password, bool passReset)
        {
            return user.execute(string.Format("UPDATE \"inkaart\".\"User\" " +
                "SET password = '{0}', need_pass_reset = {1} " +
                "WHERE id_user = '{2}'", sha.encrypt(password), passReset, idUser));

            /* TODO
            row = getUserRow(username);

            row["username"] = username;
            //row["password"] = sha.encrypt(password);
            row["status"] = status;
            row["description"] = description;
            row["id_role"] = role;
            
            int rowsAffected = user.updateData(data, adap, "User");

            return rowsAffected;
            */
        }

        public int updateData(string username, string description, int status, int role, System.Byte[] photo, int userID)
        {
            table = data.Tables["User"];

            return user.execute(string.Format("UPDATE \"inkaart\".\"User\" " +
                "SET username = '{0}', status = {1}, description = '{2}', id_role = {3} " +
                "WHERE id_user = {4}", username, status, description, role, userID));
            
            /* TODO
            row = getUserRow(username);

            row["username"] = username;
            //row["password"] = sha.encrypt(password);
            row["status"] = status;
            row["description"] = description;
            row["id_role"] = role;
            
            int rowsAffected = user.updateData(data, adap, "User");

            return rowsAffected;
            */
        }

        public int insertData(string username, string description, int status, ref string password, int role, System.Byte [] photo)
        {   
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
            row["id_role"] = role;
            if (photo != null) row["photo"] = photo;

            //  Add the row created into the table
            table.Rows.Add(row);

            //  Push the data to the database (Will only work once, as the DB only accepts unique users, please delete the user created)
            int rowsAffected = user.insertData(data, adap, "User");
            return rowsAffected;
        }

        public DataRow getUserRow(string username)
        {
            adap = user.userAdapter();
            adap.SelectCommand.Parameters[0].NpgsqlValue = username;

            if (data != null) data.Clear();
            data = user.getData(adap, "User");
            if (data != null)
            {
                if (data.Tables["User"].Rows.Count > 0) return data.Tables["User"].Rows[0];
                else return null;
            }
            else return null;
        }
        
        public DataRow getUserRowbyID(int id)
        {
            table = showData();
            DataRow[] rows;
            rows = table.Select("id_user = " + id);
            row = rows[0];

            return row;
        }

        public void massiveUpload(string filename, WorkerController worker)
        {
            string password = "";   // las contrase;as las creamos vacias
            table = showData();     // obtenemos la tabla de usuarios

            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    // creamos usuario
                    insertData(values[0], values[1], int.Parse(values[2]), ref password, int.Parse(values[3]), null);
                    // creamos trabajador
                    worker.insertData(values[4], values[5], int.Parse(values[6]), int.Parse(values[7]), worker.getUserID(values[0]), int.Parse(values[8]), values[9], values[10]);
                    worker.sendPassword(values[10], values[0], password);
                }
            }            
        }

        public void sendResetPass(string username)
        {
            WorkerController worker = new WorkerController();
            row = getUserRow(username);
            DataTable workerTable = worker.showData();
            int idUser = Convert.ToInt32(row["id_user"]);

            DataRow [] rows = workerTable.Select("id_user = " + idUser);
            row = rows[0];
            if (row != null)
            {
                string newPass = sha.getMiniSHA();
                worker.sendPassword(row["email"].ToString(), username, newPass);
                updatePassword(idUser, newPass, true);
            }
        }
    }
}
