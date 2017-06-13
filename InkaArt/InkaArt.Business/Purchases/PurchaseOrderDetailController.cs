using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Purchases;

namespace InkaArt.Business.Purchases
{
    public class PurchaseOrderDetailController
    {
        private PurchaseOrderDetailData purchaseOrderDetail;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;
        public DataTable getData()
        {
            purchaseOrderDetail = new PurchaseOrderDetailData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();

            adap = purchaseOrderDetail.purchaseOrderDetailAdapter();

            data.Reset();
            data = purchaseOrderDetail.getData(adap, "PurchaseOrderDetail");

            table = new DataTable();
            table = data.Tables[0];
            return table;
        }
        public void insertData(int id_order, int id_raw_material, int id_suppliers,int quantity,double amount,int factura,string status)
        {

            table = data.Tables["PurchaseOrderDetail"];
            row = table.NewRow();

            row["id_order"] = id_order;
            row["id_raw_material"] = id_raw_material;
            row["id_suppliers"] = id_suppliers;
            row["quantity"] = quantity;
            row["amount"] = amount;
            row["id_factura"] = factura;
            row["status"]=status;
            table.Rows.Add(row);

            int rowsAffected = purchaseOrderDetail.insertData(data, adap, "PurchaseOrderDetail");

        }
        public void updateData(int id_detail,int quantity,double amount,int factura,string estado)
        {
            table = data.Tables["PurchaseOrderDetail"];
            purchaseOrderDetail.execute(string.Format("UPDATE \"inkaart\".\"PurchaseOrderDetail\" " +
                        "SET quantity = {0}, amount = {1}, id_factura = {2}, status='{3}'" +
                        "WHERE id_detail = {4}", quantity, amount, factura,estado, id_detail));

           purchaseOrderDetail.updateData(data, adap, "PurchaseOrderDetail");
        }
    }
}
