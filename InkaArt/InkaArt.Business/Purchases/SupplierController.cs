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

            supplier.connect();
            adap = supplier.supplierAdapter();

            data.Reset();
            data = supplier.getData(adap, "Supplier");

            DataTable supplierList = new DataTable();
            supplierList = data.Tables[0];

            return supplierList;
        }
        public void insertData(string nombre, int ruc,string contacto,int telefono,string correo,string direccion,int prioridad,string estado)
        {
            supplier.connect();

            table = data.Tables["Supplier"];
            row = table.NewRow();
            
            row["name"] = nombre;
            row["RUC"] = ruc;
            row["contact"] = contacto;
            row["telephone"] = telefono;
            row["email"] = correo;
            row["address"] = direccion;
            row["status"] = estado;
            row["priority"] = prioridad;

            table.Rows.Add(row);

            int rowsAffected = supplier.insertData(data, adap, "Supplier");

            supplier.closeConnection();
        }
        public void updateData(string id, string nombre, int ruc, string contacto, int telefono, string correo, string direccion, int prioridad, string estado)
        {
            supplier.connect();
            table = data.Tables["Supplier"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idSupplier"].ToString(), id) == 0)
                {
                    table.Rows[i]["name"] = nombre;
                    table.Rows[i]["RUC"] = ruc;
                    table.Rows[i]["contact"] = contacto;
                    table.Rows[i]["telephone"] = telefono;
                    table.Rows[i]["email"] = correo;
                    table.Rows[i]["address"] = direccion;
                    table.Rows[i]["status"] = estado;
                    table.Rows[i]["priority"] = prioridad;
                    break;
                }
            }
            supplier.updateData(data, adap, "Supplier");
            supplier.closeConnection();
        }
    }
}
