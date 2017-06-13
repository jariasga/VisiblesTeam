using InkaArt.Classes;
using Npgsql;

namespace InkaArt.Data.Purchases
{
    public class PurchaseOrderDetailData : BD_Connector
    {
        public NpgsqlDataAdapter purchaseOrderDetailAdapter()
        {
            NpgsqlDataAdapter purchaseOrderDetailAdapter = new NpgsqlDataAdapter();
            purchaseOrderDetailAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"PurchaseOrderDetail\";", Connection);

            return purchaseOrderDetailAdapter;
        }
    }
}
