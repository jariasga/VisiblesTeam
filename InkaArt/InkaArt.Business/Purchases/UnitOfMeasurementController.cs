using InkaArt.Data.Purchases;
using Npgsql;
using System.Data;
using System.IO;
using System;
using System.Linq;

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
            
            unitOfMeasurement.updateData(data,adap, "UnitOfMeasurement");
        }
        public bool comprobarCarga(string nombre, string abreviatura)
        {
            DataTable resultados = getData();
            DataRow[] rows;
            rows = resultados.Select("name LIKE '%" + nombre + "%' AND abbreviature LIKE '%" + abreviatura + "%'");
            
            if (rows.Any()) return true; //ya existe en la BD
            else return false;
        }
        public int massiveUpload(string filename)
        {
            bool primero=true;
            table = getData();     // obtenemos la tabla de unidades

            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    string nombre=values[0].Trim();
                    string abreviatura=values[1].Trim();
                    if (nombre.Length <= 280 && abreviatura.Length <= 10)
                    {
                        if (primero)
                        {
                            if (comprobarCarga(values[0],values[1])) return 2;
                            primero = false;
                        }
                        try
                        {
                            insertData(nombre, abreviatura, "Activo");
                        }
                        catch (Exception)
                        {
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
