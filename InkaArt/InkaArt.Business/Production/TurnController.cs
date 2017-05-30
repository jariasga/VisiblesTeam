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

        public TurnController()
        {
            turn = new TurnData();
            data = new DataSet();
        }
        public DataTable getData()
        {
            
            turn.connect();
            adapt = turn.turnAdapter();

            data.Clear();
            data = turn.getData(adapt, "Turn");

            DataTable turnList = new DataTable();
            turnList = data.Tables[0];

            return turnList;
        }

        public void insertData(string ini, string fin, string desc)
        {
            turn.connect();
            adapt = turn.turnAdapter();

            data.Clear();
            data = turn.getData(adapt, "Turn");
            
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
