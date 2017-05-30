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
    public class TurnController
    {
        private TurnData turn;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            turn = new TurnData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();

            turn.connect();
            adapt = turn.turnAdapter();

            data.Reset();
            data = turn.getData(adapt, "Turn");

            DataTable turnList = new DataTable();
            turnList = data.Tables[0];

            return turnList;
        }

        public void insertData(string ini, string fin, string desc)
        {
            turn = new TurnData();
            adapt = new NpgsqlDataAdapter();
            data = new DataSet();

            turn.connect();
            adapt = turn.turnAdapter();

            data.Reset();
            data = turn.getData(adapt, "Turn");

            table = new DataTable();
            table = data.Tables["Turn"];

            row = table.NewRow();

            row["start"] = ini;
            row["end"] = fin;
            row["description"] = desc;

            table.Rows.Add(row);
            int rowsAffected = turn.insertData(data, adapt, "Turn");
        }

    }

}
