using InkaArt.Data.Purchases;
using Npgsql;
using System.Data;
using System.IO;

namespace InkaArt.Business.Purchases
{
    public class RawMaterialController
    {
        private RawMaterialData rawMaterial;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            rawMaterial = new RawMaterialData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
            
            adap = rawMaterial.rawMaterialAdapter();

            data.Reset();
            data = rawMaterial.getData(adap, "RawMaterial");

            DataTable rawMaterialList = new DataTable();
            rawMaterialList = data.Tables[0];

            return rawMaterialList;
        }

        public void insertData(string nombre,string descripcion,string unidad,string estado,double precioPromedio)
        {

            table = data.Tables["RawMaterial"];
            row = table.NewRow();

            row["name"] = nombre;
            row["description"] = descripcion;
            row["unit"] = unidad;
            row["status"] = estado;
            row["average_price"] = precioPromedio;

            table.Rows.Add(row);

            int rowsAffected = rawMaterial.insertData(data, adap, "RawMaterial");
        }
        public int updateData(string id, string nombre, string descripcion, string unidad, string estado, double precioPromedio)
        {
            table = data.Tables["RawMaterial"];
            rawMaterial.execute(string.Format("UPDATE \"inkaart\".\"RawMaterial\" " +
                        "SET name = '{0}', description = '{1}', unit='{2}',status = '{3}',average_price={4}" +
                        "WHERE id_raw_material = {5}", nombre, descripcion, unidad, estado, precioPromedio,id));
           
            return rawMaterial.updateData(data, adap, "RawMaterial");
        }
        public void massiveUpload(string filename)
        {
            table = getData();     // obtenemos la tabla de materia prima

            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    double precioProm = 0, doubleMod;
                    int intMod;
                    //si no cumple con los tipos de datos, no lo insertará y pasará al siguiente.
                    if (double.TryParse(values[3], out doubleMod))
                    {
                        precioProm = double.Parse(values[3]);
                    }
                    else continue;
                    if (!int.TryParse(values[2], out intMod)) continue;
                    // creamos materia prima
                    insertData(values[0], values[1], values[2],"Activo",precioProm);
                }
            }
        }
    }
}