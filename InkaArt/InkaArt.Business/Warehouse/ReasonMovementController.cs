using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Warehouse;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class ReasonMovementController
    {
        private ReasonMovementData reasonMovementData;
        public ReasonMovementController()
        {
            reasonMovementData = new ReasonMovementData();

        }

        public DataTable GetReasonMovementList()
        {
            return reasonMovementData.GetData();
        }
    }
}
