using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using InkaArt.Data.Purchases;
using System.Data;
using Npgsql;

namespace InkaArt.Business.Warehouse
{
    public class RawMaterialWarehouseController
    {
        private RMWarehouseData rmWarehouse;
        private NpgsqlDataAdapter adapt;
        private DataSet data;
        private DataTable table;
        private DataRow row;

        public RawMaterialWarehouseController()
        {
            rmWarehouse = new RMWarehouseData();
            data = new DataSet();
        }

        public DataTable getData()
        {
            //adapt = new NpgsqlDataAdapter();

            adapt = rmWarehouse.rmWarehouseAdapter();

            data.Reset();
            data = rmWarehouse.getData(adapt, "RawMaterial-Warehouse");

            DataTable rmWarehouseList = new DataTable();
            rmWarehouseList = data.Tables[0];

            return rmWarehouseList;
        }
    }
}
