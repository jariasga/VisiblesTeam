using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class ProductionMovementMovementController
    {
        private ProductionMovementMovementData productionMovementMovementData;
        public ProductionMovementMovementController()
        {
            productionMovementMovementData = new ProductionMovementMovementData();

        }

        public DataTable GetProductionMovementMovementList()
        {
            return productionMovementMovementData.GetData();
        }
    }
}
