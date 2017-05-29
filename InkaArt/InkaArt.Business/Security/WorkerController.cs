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
    }
}
