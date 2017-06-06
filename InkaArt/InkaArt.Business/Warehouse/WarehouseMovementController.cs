using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InkaArt.Data.Warehouse;

namespace InkaArt.Business.Warehouse
{
    public class WarehouseMovementController
    {
        private WarehouseMovementData warehouseMovementData;

        public WarehouseMovementController()
        {
            warehouseMovementData = new WarehouseMovementData();

        }

        public DataTable GetWarehouseMovementList(string id = "", string name = "", string address = "")
        {
            int intId = -1, intAux;

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            return warehouseMovementData.GetData(intId, name, "Activo", address);
        }

    }
}
