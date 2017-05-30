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
            worker.connect();

            adap = worker.workerAdapter();

            data = worker.getData(adap, "Worker");

            table = data.Tables["Worker"];
            return table;
        }

        public int insertData(string firstName, string lastName, long dni, int turn, int user, long phone, string address, string email)
        {
            worker.connect();
            
            table = data.Tables["Worker"];

            row = table.NewRow();
            
            row["firstName"] = firstName;
            row["lastName"] = lastName;
            row["dni"] = dni;
            row["turn"] = turn;
            row["user"] = user;
            row["phone"] = phone;
            row["address"] = address;
            row["email"] = email;
            
            table.Rows.Add(row);
            
            int rowsAffected = worker.insertData(data, adap, "Worker");
            return rowsAffected;
        }

        public int updateData(int workerID, string firstName, string lastName, long dni, int turn, int user, long phone, string address, string email)
        {
            worker.connect();

            row = getWorkerRowbyID(workerID);
            row["idWorker"] = workerID;
            row["firstName"] = firstName;
            row["lastName"] = lastName;
            row["dni"] = dni;
            row["turn"] = turn;
            row["user"] = user;
            row["phone"] = phone;
            row["address"] = address;
            row["email"] = email;
            /*
            adap.UpdateCommand.Parameters.AddWithValue("@idWorkerP", NpgsqlDbType.Text, 0, "\"idWorker\"", workerID);
            adap.UpdateCommand.Parameters.AddWithValue("@firstNameP", NpgsqlDbType.Text, 0, "\"firstName\"", firstName);
            adap.UpdateCommand.Parameters.AddWithValue("@lastNameP", NpgsqlDbType.Text, 0, "\"lastName\"", lastName);
            adap.UpdateCommand.Parameters.AddWithValue("@dniP", NpgsqlDbType.Integer, 0, "\"dni\"", dni);
            adap.UpdateCommand.Parameters.AddWithValue("@turnP", NpgsqlDbType.Integer, 0, "\"turn\"", turn);
            adap.UpdateCommand.Parameters.AddWithValue("@userP", NpgsqlDbType.Integer, 0, "\"user\"", user);
            adap.UpdateCommand.Parameters.AddWithValue("@phoneP", NpgsqlDbType.Integer, 0, "\"phone\"", phone);
            adap.UpdateCommand.Parameters.AddWithValue("@addressP", NpgsqlDbType.Text, 0, "\"address\"", address);
            adap.UpdateCommand.Parameters.AddWithValue("@emailP", NpgsqlDbType.Text, 0, "\"email\"", email);
            adap.UpdateCommand.CommandTimeout = 50;

            int rowsAffected = adap.Update(data, "Worker");
            worker.closeConnection();*/
            int rowsAffected = worker.updateData(data, adap, "Worker");
            return rowsAffected;
        }

        public int getUserID(string username)
        {
            UserController user = new UserController();
            
            return Convert.ToInt32(user.getUserRow(username)["idUser"].ToString().Trim());
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
            rows = table.Select("idWorker = " + id);
            row = rows[0];

            return row;
        }
    }
}
