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

            purchaseOrder.connect();
            adap = purchaseOrder.purchaseOrderAdapter();

            data.Reset();
            data = purchaseOrder.getData(adap, "PurcharseOrder");

            DataTable purchaseOrderList = new DataTable();
            purchaseOrderList = data.Tables[0];
            purchaseOrder.closeConnection();
            return purchaseOrderList;
        }
        public void inserData(int proveedor,string estado,DateTime creacion, DateTime entrega,double total)
        {
            purchaseOrder.connect();

            table = data.Tables["PurcharseOrder"];
            row = table.NewRow();

            row["idSupplier"] = proveedor;
            row["status"] = estado;
            row["creationDate"] = creacion;
            row["deliveryDate"] = entrega;
            row["total"] = total;
            table.Rows.Add(row);

            int rowsAffected = purchaseOrder.insertData(data, adap, "PurcharseOrder");

            purchaseOrder.closeConnection();
        }
    }
}
