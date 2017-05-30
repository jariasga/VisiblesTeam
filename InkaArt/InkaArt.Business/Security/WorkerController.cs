using InkaArt.Data.Security;
using Npgsql;
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
            adap.SelectCommand.CommandText = "SELECT * FROM inkaart.\"Worker\";";
            adap.SelectCommand.Parameters.Clear();

            data = worker.getData(adap, "Worker");

            table = data.Tables["Worker"];

            worker.closeConnection();
            return table;
        }

        public int insertData(string firstName, string lastName, int dni, int turn, int user, int phone, string address, string email)
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
    }
}
