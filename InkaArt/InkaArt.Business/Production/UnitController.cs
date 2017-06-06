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
    public class UnitController
    {

        private UnitData unit;
        private NpgsqlDataAdapter adapt;
        private DataSet data;

        public UnitController()
        {
            unit = new UnitData();
            data = new DataSet();
        }
        public DataTable getData()
        {
            adapt = unit.unitAdapter();

            data.Clear();
            data = unit.getData(adapt, "Worker");

            DataTable unitList = new DataTable();
            unitList = data.Tables[0];

            return unitList;
        }
    }
}
