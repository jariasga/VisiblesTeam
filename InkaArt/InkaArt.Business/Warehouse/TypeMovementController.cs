using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class TypeMovementController
    {
        private TypeMovementData typeMovementData;
        public TypeMovementController()
        {
            typeMovementData = new TypeMovementData();

        }

        public DataTable GetTypeMovementList()
        {
            return typeMovementData.GetData();
        }
    }
}
