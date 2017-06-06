using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using InkaArt.Data.Purchases;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class RawMaterialWarehouseController
    {
        private RawMaterialData rmData;
        private RMWarehouseData rmWarehouseData;

        public DataTable GetRM(string id = "")
        {
            int intId = -1, intAux;
            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            return rmData.GetRM(intId);
        }

        public int AddRawMaterialToWarehouse(string idWarehouse, string id, string name, string description)
        {
            return rmWarehouseData.InsertRMWarehouse(idWarehouse, id, name, description);
        }
    }
}
