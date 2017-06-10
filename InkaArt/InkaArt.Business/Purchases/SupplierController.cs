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
        public int updateData(string id, string nombre, string ruc, string contacto, long telefono, string correo, string direccion, int prioridad, string estado)
        {
            table = data.Tables["Supplier"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["id_supplier"].ToString(), id) == 0)
                {
                    supplier.execute(string.Format("UPDATE \"inkaart\".\"Supplier\" " +
                        "SET name = '{0}', ruc = '{1}', contact = {2}, telephone = {3}, email = {4}, address = {5}, status = '{6}', email = '{7}' " +
                        "WHERE id_supplier = {8}", nombre, ruc, contacto, telefono, correo, direccion, estado, prioridad, id));
                    break;
                }
            }
            supplier.updateData(data, adap, "Supplier");
            return 1;
        }
    }
}
