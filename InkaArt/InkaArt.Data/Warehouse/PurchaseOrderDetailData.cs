using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Warehouse
{
    public class PurchaseOrderDetailData:BD_Connector
    {
        public NpgsqlDataAdapter purchaseOrderDetailAdapter()
        {
            NpgsqlDataAdapter purchaseOrderDetailAdapter = new NpgsqlDataAdapter();
            purchaseOrderDetailAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"PurchaseOrderDetail\";", Connection);
            return purchaseOrderDetailAdapter;
        }
    }
}
