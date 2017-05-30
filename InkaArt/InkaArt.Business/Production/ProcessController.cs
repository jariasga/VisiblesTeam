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
    public class ProcessController
    {
        private ProcessData process;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public ProcessController()
        {
            process = new ProcessData();
            data = new DataSet();
        }

        public DataTable getData()
        {
            //adapt = new NpgsqlDataAdapter();

            process.connect();
            adapt = process.processAdapter();

            data.Reset();
            data = process.getData(adapt, "Process");

            DataTable processList = new DataTable();
            processList = data.Tables[0];

            return processList;
        }

        public void insertData(string desc, string totalWorkstations)
        {
            process.connect();
            adapt = process.processAdapter();

            data.Clear();
            data = process.getData(adapt, "Process");

            table = data.Tables["Process"];

            row = table.NewRow();

            row["description"] = desc;
            row["positionCount"] = totalWorkstations;

            table.Rows.Add(row);
            int rowsAffected = process.insertData(data, adapt, "Process");
        }

        public void updateData(string id, int totatWorkstations)
        {
            process.connect();
            adapt = process.processAdapter();

            data.Clear();
            data = process.getData(adapt, "Process");

            table = data.Tables["Process"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idProcess"].ToString(), id) == 0)
                {
                    table.Rows[i]["positionCount"] = totatWorkstations;
                    break;
                }
            }
            int rowUpdated = process.updateData(data, adapt, "Process");
        }
    }
}
