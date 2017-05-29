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
    }
}
