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
        private DataTable worker_list;

        public WorkerController()
        {
            worker = new WorkerData();
            data = new DataSet();
        }
        public DataTable getData()
        {
            adapt = worker.workerAdapter();

            data.Clear();
            data = worker.getData(adapt, "Worker");
            
            worker_list = data.Tables[0];

            return worker_list;
        }

        public DataRow GetByID(int id_worker)
        {
            return worker_list.Rows.Find(id_worker);
        }

        public DataRow GetByFullName(string full_name)
        {
            foreach (DataRow row in worker_list.Rows)
            {
                string row_full_name = row["name"] + "" + row["last_name"];
                if (full_name == row_full_name) return row;
            }
            return null;
        }

        
    }
}
