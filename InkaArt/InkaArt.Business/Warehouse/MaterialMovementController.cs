using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class MaterialMovementController
    {
        private MaterialMovementData materialMovementData;
        public MaterialMovementController()
        {
            materialMovementData = new MaterialMovementData();

        }

        public DataTable GetMaterialMovementList(string id = "", string name = "")
        {
            int intId = -1, intAux;

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            return materialMovementData.GetData(intId, name,"Activo");
        }
    }
}
