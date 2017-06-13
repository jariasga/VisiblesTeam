using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using Npgsql;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class ProductMovementController
    {
        private ProductMovementData productMovementData;
        public ProductMovementController()
        {
            productMovementData = new ProductMovementData();

        }

        public DataTable GetProductMovementList(string id = "", string name = "")
        {
            int intId=-1, intAux;

            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            return productMovementData.GetData(intId, name,1);
        }
        
        
    }
}
