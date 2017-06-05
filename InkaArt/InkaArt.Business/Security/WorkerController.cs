using InkaArt.Data.Security;
using Npgsql;
using NpgsqlTypes;
using sendEmail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Security
{
    public class WorkerController
    {
        private WorkerData worker;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public object NpgsqlValue { get; private set; }

        public WorkerController()
        {
            worker = new WorkerData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
        }
        public DataTable showData()
        {

            adap = worker.workerAdapter();

            data = worker.getData(adap, "Worker");

            table = data.Tables["Worker"];
            return table;
        }

        public int insertData(string firstName, string lastName, long dni, int turn, int user, long phone, string address, string email)
        {   
            table = data.Tables["Worker"];

            row = table.NewRow();
            
            row["first_name"] = firstName;
            row["las_name"] = lastName;
            row["dni"] = dni;
            row["turn"] = turn;
            row["id_user"] = user;
            row["phone"] = phone;
            row["address"] = address;
            row["email"] = email;
            
            table.Rows.Add(row);
            
            int rowsAffected = worker.insertData(data, adap, "Worker");
            return rowsAffected;
        }

        public int updateData(int workerID, string firstName, string lastName, long dni, int turn, int user, long phone, string address, string email)
        {
            row = getWorkerRowbyID(workerID);

            worker.execute(string.Format("UPDATE \"inkaart\".\"Worker\" " +
                "SET first_name = '{0}', last_name = '{1}', dni = {2}, turn = {3}, id_user = {4}, phone = {5}, address = '{6}', email = '{7}' " +
                "WHERE id_worker = {8}", firstName, lastName, dni, turn, user, phone, address, email, workerID));
              
            /*
            row["first_name"] = firstName;
            row["last_name"] = lastName;
            row["dni"] = dni;
            row["turn"] = turn;
            row["id_user"] = user;
            row["phone"] = phone;
            row["address"] = address;
            row["email"] = email;
            
            int rowsAffected = worker.updateData(data, adap, "Worker");
            return rowsAffected;
            */
            return 1;
        }

        public int getUserID(string username)
        {
            UserController user = new UserController();
            
            return Convert.ToInt32(user.getUserRow(username)["id_user"].ToString().Trim());
        }

        public void sendPassword(string recipient, string username, string password)
        {
            googleMail mail = new googleMail();
            mail.sendEmail(recipient, username, password);
        }

        public DataRow getWorkerRowbyID(int id)
        {
            table = showData();
            DataRow[] rows;
            rows = table.Select("id_worker = " + id);
            row = rows[0];

            return row;
        }
    }
}
