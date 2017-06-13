using InkaArt.Data.Warehouse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Warehouse
{
    public class MovementTypeController
    {
        private MovementTypeData type_data;

        public MovementTypeController()
        {
            type_data = new MovementTypeData();
        }

        public DataTable GetMovementTypes()
        {
            return type_data.GetMovementTypes();
        }
    }
}
