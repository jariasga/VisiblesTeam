using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class RawMaterialWarehouseController
    {
        private RMWarehouseData rmWarehouseData;

        public DataTable GetRMWarehouses(string id = "")
        {
            int intId = -1, intAux;
            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            return rmWarehouseData.GetRMWarehouses(intId);
        }
    }
}
