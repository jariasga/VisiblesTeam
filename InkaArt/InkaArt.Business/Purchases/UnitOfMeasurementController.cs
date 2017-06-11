using InkaArt.Data.Purchases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            
            adap = unitOfMeasurement.unitOfMeasurementAdapter();

            data.Reset();
            data = unitOfMeasurement.getData(adap, "UnitOfMeasurement");

            table = new DataTable();
            table = data.Tables[0];
            return table;
        }
        public void insertData(string nombre, string abreviatura,string estado)
        {

            table = data.Tables["UnitOfMeasurement"];
            row = table.NewRow();            

            row["name"] = nombre;
            row["abbreviature"] = abreviatura;
            row["status"] = estado;
            table.Rows.Add(row);

            int rowsAffected = unitOfMeasurement.insertData(data, adap, "UnitOfMeasurement");
            
        }
        public void updateData(string id, string nombre, string abreviatura,string estado)
        {
            table = data.Tables["UnitOfMeasurement"];
            unitOfMeasurement.execute(string.Format("UPDATE \"inkaart\".\"UnitOfMeasurement\" " +
                        "SET name = '{0}', abbreviature = '{1}', status = '{2}'" +
                        "WHERE id_unit = {3}", nombre, abreviatura, estado, id));

            /*            for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (String.Compare(table.Rows[i]["idUnit"].ToString(), id) == 0)
                            {
                                table.Rows[i]["name"] = nombre;
                                table.Rows[i]["abbreviature"] = abreviatura;
                                table.Rows[i]["status"] = estado;
                                break;
                            }
                        }*/
            unitOfMeasurement.updateData(data,adap, "UnitOfMeasurement");
        }
        public void massiveUpload(string filename)
        {
            table = getData();     // obtenemos la tabla de usuarios

            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    // creamos unidades
                    insertData(values[0], values[1], values[2]);
                }
            }
        }
    }
}
