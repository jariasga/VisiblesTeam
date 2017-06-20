using InkaArt.Data.Warehouse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Warehouse
{
    public class MovementReasonController
    {
        private MovementReasonData type_data;

        public MovementReasonController()
        {
            type_data = new MovementReasonData();
        }

        public DataTable GetMovementReasons()
        {
            return type_data.GetMovementReasons();
        }
    }
}
