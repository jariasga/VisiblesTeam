using Npgsql;
using System.Data;
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
        public PurchaseOrderDetailController()
        {
            purchaseOrderDetail = new PurchaseOrderDetailData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
        }
        public DataTable getData()
        {
            adap = purchaseOrderDetail.purchaseOrderDetailAdapter();
            data = purchaseOrderDetail.getData(adap, "PurchaseOrderDetail");
            
            table = data.Tables["PurchaseOrderDetail"];
            return table;
        }
        public void insertData(int id_order, int id_raw_material, int id_suppliers,int quantity,double amount,double igv,int factura,string status)
        {

            table = data.Tables["PurchaseOrderDetail"];
            row = table.NewRow();

            row["id_order"] = id_order;
            row["id_raw_material"] = id_raw_material;
            row["id_suppliers"] = id_suppliers;
            row["quantity"] = quantity;
            row["amount"] = amount;
            row["igv"] = igv;
            if (factura!=0) row["id_factura"] = factura;
            row["status"]=status;
            table.Rows.Add(row);

            int rowsAffected = purchaseOrderDetail.insertData(data, adap, "PurchaseOrderDetail");

        }
        public void updateData(int id_detail,int quantity,double amount,double igv,string estado)
        {
            table = data.Tables["PurchaseOrderDetail"];
            purchaseOrderDetail.execute(string.Format("UPDATE \"inkaart\".\"PurchaseOrderDetail\" " +
                        "SET quantity = {0}, amount = {1}, igv = {2}, status='{3}'" +
                        "WHERE id_detail = {4}", quantity, amount, igv,estado, id_detail));
        }

        public void updateLineaEntregada(int id_detail, int id_factura)
        {
            table = data.Tables["PurchaseOrderDetail"];
            purchaseOrderDetail.execute(string.Format("UPDATE \"inkaart\".\"PurchaseOrderDetail\" " +
                "SET status = 'Entregado', id_factura = {0} " +
                "WHERE id_detail = {1}", id_factura,id_detail));
        }
    }
}
