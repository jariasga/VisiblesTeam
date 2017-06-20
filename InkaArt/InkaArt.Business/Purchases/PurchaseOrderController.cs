using InkaArt.Data.Purchases;
using Npgsql;
using System;
using System.Data;

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

           
            purchaseOrder.updateData(data, adap, "PurcharseOrder");
        }

        public void updateOrdenEntregada(int id_order)
        {
            table = data.Tables["PurcharseOrder"];
            purchaseOrder.execute(string.Format("UPDATE \"inkaart\".\"PurcharseOrder\" " +
                "SET status = 'Entregado' " +
                "WHERE id_order = {0}", id_order));
        }
    }
}
