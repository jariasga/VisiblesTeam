using InkaArt.Data.Purchases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace InkaArt.Business.Purchases
{
    public class UnitOfMeasurementController
    {
        private UnitOfMeasurementData unitOfMeasurement;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            unitOfMeasurement = new UnitOfMeasurementData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            unitOfMeasurement.connect();
            adap = unitOfMeasurement.unitOfMeasurementAdapter();

            data.Reset();
            data = unitOfMeasurement.getData(adap, "UnitOfMeasurement");

            DataTable unitOfMeasurementList = new DataTable();
            unitOfMeasurementList = data.Tables[0];

            return unitOfMeasurementList;
        }

    }
}
