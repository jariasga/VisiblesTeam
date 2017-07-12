using System;
using System.Windows.Forms;
using InkaArt.Data.Warehouse;
using System.Data;
using System.IO;
using Npgsql;
using System.Linq;

namespace InkaArt.Business.Warehouse
{
    public class RawMaterialWarehouseController
    {
        private RMWarehouseData rmWarehouse;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public RawMaterialWarehouseController()
        {
            rmWarehouse = new RMWarehouseData();
            data = new DataSet();
        }

        public DataTable getData()
        {
            //adapt = new NpgsqlDataAdapter();

            adapt = rmWarehouse.rmWarehouseAdapter();

            data.Reset();
            data = rmWarehouse.getData(adapt, "RawMaterial-Warehouse");

            DataTable rmWarehouseList = new DataTable();
            rmWarehouseList = data.Tables[0];

            return rmWarehouseList;
        }

        public void updateMinMax(string idRmW, int min, int max)
        {
            adapt = rmWarehouse.rmWarehouseAdapter();

            string updateQuery;
            string minS = min.ToString();
            string maxS = max.ToString();
            table = getData();
            updateQuery = "UPDATE inkaart.\"RawMaterial-Warehouse\" SET ";
            updateQuery = updateQuery + "\"minimunStock\"= " + minS + ", ";
            updateQuery = updateQuery + "\"maximunStock\" = " + maxS;
            updateQuery = updateQuery + " WHERE \"idRawMaterialWarehouse\"= " + idRmW + " ;";
            rmWarehouse.execute(updateQuery);
        }

        public int insertData(string idW, string idRM, string name, string min, string max)
        {
            adapt = rmWarehouse.rmWarehouseAdapter();

            data.Reset();
            data = rmWarehouse.getData(adapt, "RawMaterial-Warehouse");
            table = data.Tables["RawMaterial-Warehouse"];
            row = table.NewRow();

            row["idWarehouse"] = idW;
            row["idRawMaterial"] = idRM;
            row["minimunStock"] = min;
            row["maximunStock"] = max;
            row["virtualStock"] = 0;
            row["currentStock"] = 0;
            row["state"] = "Activo";

            table.Rows.Add(row);
            int rowsAffected = rmWarehouse.insertData(data,adapt, "RawMaterial-Warehouse");
            return rowsAffected;
        }

        public int deleteData(string idRMW)
        {
            adapt = rmWarehouse.rmWarehouseAdapter();

            data.Reset();
            data = rmWarehouse.getData(adapt, "RawMaterial-Warehouse");
            table = data.Tables["RawMaterial-Warehouse"];
            
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (string.Compare(table.Rows[i]["idRawMaterialWarehouse"].ToString(), idRMW) == 0)
                {
                    table.Rows[i]["state"] = "Inactivo";
                    break;
                }
            }

            return rmWarehouse.updateData(data, adapt, "RawMaterial-Warehouse");            
        }

        public void updateStock(string idWh, string idRm, int logico, int fisico)
        {
            adapt = rmWarehouse.rmWarehouseAdapter();

            string updateQuery;
            string logStr = logico.ToString();
            string fidStr = fisico.ToString();
            table = getData();
            updateQuery = "UPDATE inkaart.\"RawMaterial-Warehouse\" SET ";
            updateQuery = updateQuery + "\"currentStock\" = " + logStr + ", ";
            updateQuery = updateQuery + "\"virtualStock\" = " + fidStr;
            updateQuery = updateQuery + " WHERE \"idWarehouse\" = " + idWh + " AND \"idRawMaterial\" = " + idRm + " AND state = 'Activo'"+" ;";
            rmWarehouse.execute(updateQuery);

        }
        private bool comprobarCarga(string idW,string idR)
        {
            DataTable resultados = getData();
            DataRow[] rows;
            rows = resultados.Select("idWarehouse LIKE '" + idW + "' AND idRawMaterial LIKE '" + idR + "'");

            if (rows.Any()) return true; //ya existe en la BD
            else return false;
        }
        public int massiveUpload(string filename)
        {
            bool primero=true;
            int intMod;
            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (!int.TryParse(values[0], out intMod)) continue;
                    if (!int.TryParse(values[1], out intMod)) continue;
                    if (!int.TryParse(values[2], out intMod)) continue;
                    if (!int.TryParse(values[3], out intMod)) continue;

                    // creamos almacen
                    if (primero)
                    {
                        if (comprobarCarga(values[0], values[1])) return 2;
                        primero = false;
                    }
                    try
                    {
                        //id_warehouse,id_rawMaterial,nombre,min,max
                        insertData(values[0], values[1], "",values[2],values[3]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El archivo de carga contiene errores", "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 1;
                    }
                }
                MessageBox.Show("La carga de stocks se realizó con éxito", "Cargar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return 0;
        }
    }
}
