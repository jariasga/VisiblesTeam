using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Production;
using NpgsqlTypes;
using Npgsql;

namespace InkaArt.Business.Production
{
    public class WorkerController
    {
        private WorkerData worker;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public WorkerController()
        {
            worker = new WorkerData();
            data = new DataSet();
        }
        public DataTable getData()
        {

            worker.connect();
            adapt = worker.workerAdapter();

            data.Clear();
            data = worker.getData(adapt, "Worker");

            DataTable workerList = new DataTable();
            workerList = data.Tables[0];

            return workerList;
        }
    }
}
