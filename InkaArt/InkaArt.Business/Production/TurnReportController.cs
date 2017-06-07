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
    public class TurnReportController
    {
        private TurnReportData turnReport;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public TurnReportController()
        {
            turnReport = new TurnReportData();
            data = new DataSet();
        }
        public DataTable getData()
        {
            adapt = turnReport.turnReportAdapter();

            data.Clear();
            data = turnReport.getData(adapt, "TurnReport");

            DataTable turnReportList = new DataTable();
            turnReportList = data.Tables[0];

            return turnReportList;
        }

        public void insertData(string broken, string finished, string date, string start, string end,
            string product, string process,string idWorker)
        {
            adapt = turnReport.turnReportAdapter();

            data.Clear();
            data = turnReport.getData(adapt, "TurnReport");

            table = data.Tables["TurnReport"];

            row = table.NewRow();

            row["brokenAmount"] = broken;
            row["finishedAmount"] = finished;
            row["start"] = start;
            row["end"] = end;
            row["date"] = date;
            row["product"] = product;
            row["process"] = process;
            row["idWorker"] = idWorker;

            table.Rows.Add(row);
            int rowsAffected = turnReport.insertData(data, adapt, "TurnReport");
        }
    }
}
