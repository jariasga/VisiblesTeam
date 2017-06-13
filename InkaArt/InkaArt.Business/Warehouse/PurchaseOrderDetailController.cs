using InkaArt.Data.Purchases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;
using InkaArt.Data.Warehouse;

namespace InkaArt.Business.Warehouse
{
    public class PurchaseOrderDetailControllr
    {
        private Data.Warehouse.PurchaseOrderDetailData purchaseOrderDetail;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public PurchaseOrderDetailControllr()
        {
            purchaseOrderDetail = new Data.Warehouse.PurchaseOrderDetailData();
            data = new DataSet();
        }


        public DataTable getData()
        {
            
            adap = new NpgsqlDataAdapter();
            

            adap = purchaseOrderDetail.purchaseOrderDetailAdapter();

            data.Reset();
            data = purchaseOrderDetail.getData(adap, "PurchaseOrderDetail");

            DataTable purchaseOrderDetailList = new DataTable();
            purchaseOrderDetailList = data.Tables[0];
            return purchaseOrderDetailList;
        }
    }
}
