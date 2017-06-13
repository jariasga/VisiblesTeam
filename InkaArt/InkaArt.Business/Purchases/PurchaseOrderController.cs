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
    public class PurchaseOrderController
    {
        private PurchaseOrderData purchaseOrder;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public DataTable getData()
        {
            purchaseOrder = new PurchaseOrderData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            adap = purchaseOrder.purchaseOrderAdapter();

            data.Reset();
            data = purchaseOrder.getData(adap, "PurcharseOrder");

            DataTable purchaseOrderList = new DataTable();
            purchaseOrderList = data.Tables[0];
            return purchaseOrderList;
        }
        public void inserData(int proveedor,string estado,DateTime creacion, DateTime entrega,double total)
        {

            table = data.Tables["PurcharseOrder"];
            row = table.NewRow();

            row["id_supplier"] = proveedor;
            row["status"] = estado;
            row["creation_date"] = creacion;
            row["delivery_date"] = entrega;
            row["total"] = total;
            table.Rows.Add(row);

            int rowsAffected = purchaseOrder.insertData(data, adap, "PurcharseOrder");
        }
        public void updateData(string id,int proveedor, string estado, DateTime creacion, DateTime entrega, double total)
        {
            
            table = data.Tables["PurcharseOrder"];
            purchaseOrder.execute(string.Format("UPDATE \"inkaart\".\"PurcharseOrder\" " +
                        "SET id_supplier = {0}, status = '{1}', creation_date = to_date('{2}','DD/MM/YYYY'), delivery_date = to_date('{3}','DD/MM/YYYY'), total = {4} " +
                        "WHERE id_order = {5}", proveedor, estado, creacion.ToString(), entrega.ToString(), total, id));

           /* for (int i = 0; i < table.Rows.Count; i++)
            {
                if (String.Compare(table.Rows[i]["idOrder"].ToString(), id) == 0)
                {
                    table.Rows[i]["idSupplier"] = proveedor;
                    table.Rows[i]["status"] = estado;
                    table.Rows[i]["creation_date"] = creacion;
                    table.Rows[i]["delivery_date"] = entrega;
                    table.Rows[i]["total"] = total;
                    break;
                }
            }*/
            purchaseOrder.updateData(data, adap, "PurcharseOrder");
        }
    }
}
