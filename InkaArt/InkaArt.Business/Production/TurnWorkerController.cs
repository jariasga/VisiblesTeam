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
    public class TurnWorkerController
    {
        private TurnWorkerData turnWorker;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public TurnWorkerController()
        {
            turnWorker = new TurnWorkerData();
            data = new DataSet();
        }
        public DataTable getData()
        {
            adapt = turnWorker.turnWorkerAdapter();

            data.Clear();
            data = turnWorker.getData(adapt, "Turn-Worker");

            DataTable turnWorkerList = new DataTable();
            turnWorkerList = data.Tables[0];

            return turnWorkerList;
        }

        public void insertData(string idTurn, string idReport, string idWorker)
        {
            adapt = turnWorker.turnWorkerAdapter();

            data.Clear();
            data = turnWorker.getData(adapt, "Turn-Worker");

            table = data.Tables["Turn-Worker"];

            row = table.NewRow();

            row["idTurn"] = idTurn;
            row["idReport"] = idReport;
            row["idWorker"] = idWorker;

            table.Rows.Add(row);
            int rowsAffected = turnWorker.insertData(data, adapt, "Turn-Worker");
        }

        public void updateData(string idWorker, string idReport)
        {
            adapt = turnWorker.turnWorkerAdapter();

            data.Clear();
            data = turnWorker.getData(adapt, "Turn-Worker");

            table = data.Tables["Turn-Worker"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idWorker"].ToString(), idWorker) == 0)
                {
                    table.Rows[i]["idReport"] = idReport;
                    break;
                }
            }
            int rowUpdated = turnWorker.updateData(data, adapt, "Turn-Worker");
        }
    }
}
