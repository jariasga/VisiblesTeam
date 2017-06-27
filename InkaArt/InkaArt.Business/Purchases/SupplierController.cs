using InkaArt.Data.Purchases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using System.IO;

namespace InkaArt.Business.Purchases
{
    public class SupplierController
    {
        private SupplierData supplier;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            supplier = new SupplierData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
            
            adap = supplier.supplierAdapter();

            data.Reset();
            data = supplier.getData(adap, "Supplier");

            DataTable supplierList = new DataTable();
            supplierList = data.Tables[0];

            return supplierList;
        }
        public void insertData(string nombre, string ruc,string contacto,int telefono,string correo,string direccion,int prioridad,string estado)
        {

            table = data.Tables["Supplier"];
            row = table.NewRow();
            
            row["name"] = nombre;
            row["ruc"] = ruc;
            row["contact"] = contacto;
            row["telephone"] = telefono;
            row["email"] = correo;
            row["address"] = direccion;
            row["status"] = estado;
            row["priority"] = prioridad;

            table.Rows.Add(row);

            int rowsAffected = supplier.insertData(data, adap, "Supplier");
        }
        public int updateData(string id, string nombre, string ruc, string contacto, int telefono, string correo, string direccion, int prioridad, string estado)
        {
            table = data.Tables["Supplier"];
            supplier.execute(string.Format("UPDATE \"inkaart\".\"Supplier\" " +
                        "SET name = '{0}', ruc = '{1}', contact = '{2}', telephone = {3}, email = '{4}', address = '{5}', status = '{6}', priority = {7} " +
                        "WHERE id_supplier = {8}", nombre, ruc, contacto, telefono, correo, direccion, estado, prioridad, id));
            
            supplier.updateData(data, adap, "Supplier");
            return 1;
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
                    int phone = 0,prioridad=0, intMod;

                    if (values[3].Length>6 && values[3].Length<10 && int.TryParse(values[3], out intMod))
                    {
                        phone = int.Parse(values[3]);
                    }
                    else continue;
                    if (int.TryParse(values[6], out intMod))
                    {
                        prioridad = int.Parse(values[6]);
                        if (prioridad < 0 || prioridad > 10) continue;
                    }
                    else continue;
                    if (values[1].Length != 11) continue;
                    if (values[2].Length < 6) continue;
                    if (values[5].Length < 7) continue;

                    // creamos materia prima
                    //nombre (0), ruc (1), contacto (2),telefono (3),correo (4),dirección (5),prioridad(6),estado (7)
                    insertData(values[0], values[1], values[2], phone, values[4],values[5],prioridad,"Activo");
                }
            }
        }
    }
}
