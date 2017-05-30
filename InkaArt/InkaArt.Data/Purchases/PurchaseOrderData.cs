using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using System.Data;

namespace InkaArt.Data.Purchases
{
    public class PurchaseOrderData : BD_Connector
    {
        public NpgsqlDataAdapter purchaseOrderAdapter()
        {
            NpgsqlDataAdapter purchaseOrderAdapter = new NpgsqlDataAdapter();
            purchaseOrderAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"PurcharseOrder\";", Connection);
            return purchaseOrderAdapter;
        }
    }
}
