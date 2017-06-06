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
        /*private NpgsqlDataAdapter adap;
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
            unitOfMeasurement.closeConnection();
            return unitOfMeasurementList;
        }
        public void insertData(string nombre, string abreviatura,string estado)
        {
            unitOfMeasurement.connect();

            table = data.Tables["UnitOfMeasurement"];
            row = table.NewRow();            

            row["name"] = nombre;
            row["abbreviature"] = abreviatura;
            row["status"] = estado;
            table.Rows.Add(row);

            int rowsAffected = unitOfMeasurement.insertData(data, adap, "UnitOfMeasurement");

            unitOfMeasurement.closeConnection();
        }
        public void updateData(string id, string nombre, string abreviatura,string estado)
        {
            unitOfMeasurement.connect();
            table = data.Tables["UnitOfMeasurement"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idUnit"].ToString(), id) == 0)
                {
                    table.Rows[i]["name"] = nombre;
                    table.Rows[i]["abbreviature"] = abreviatura;
                    table.Rows[i]["status"] = estado;
                    break;
                }
            }
            unitOfMeasurement.updateData(data,adap, "UnitOfMeasurement");
            unitOfMeasurement.closeConnection();
        }*/
        public UnitOfMeasurementController()
        {
            unitOfMeasurement = new UnitOfMeasurementData();
        }
        public DataTable GetUnits(string id = "", string name = "", string abreviatura = "", string estado = "")
        {
            int intId = -1, intAux;
            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            return unitOfMeasurement.GetUnits(intId, name, abreviatura, estado);
        }
        public void AddUnit(string name, string abrev, string state)
        {
            unitOfMeasurement.insertUnit(name, abrev, state);
        }
        public void UpdateUnit(string id, string name, string abrev, string state)
        {
            unitOfMeasurement.UpdateUnit(id, name, abrev, state);
        }
    }
}
