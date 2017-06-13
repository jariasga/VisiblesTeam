using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Data.Warehouse;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class MovementController
    {

        private MovementData movement_data;

        public MovementController()
        {
            movement_data = new MovementData();
        }

        public DataTable GetMovements(string str_id = null, string str_type = null, string str_reason = null, string str_warehouse = null, string str_date = null, string str_status = null)
        {
            if (str_id != null)
            {
                int id = str_id == ""? -1 : int.Parse(str_id);
                int type = int.Parse(str_type);
                int reason = int.Parse(str_reason);
                int warehouse = int.Parse(str_warehouse);
                int status = int.Parse(str_status);

                return movement_data.GetMovements(id, type, reason, warehouse, str_date, status);
            }

            return movement_data.GetMovements();
        }

        public string getReasonDescription(string reason_id)
        {
            int id = int.Parse(reason_id);
            DataRow reason = movement_data.getMovementReason(id);
            return reason == null? "" : reason["description"].ToString();
        }

        public string getTypeDescription(string type_id)
        {
            int id = int.Parse(type_id);
            DataRow type = movement_data.getMovementType(id);
            return type == null? "" : type["description"].ToString();
        }

        public string getWarehouseName(string warehouse_id)
        {
            int id = int.Parse(warehouse_id);
            DataRow warehouse = movement_data.getWarehouse(id);
            return warehouse == null ? "" : warehouse["name"].ToString();
        }

        public void deleteMovements(List<string> ids)
        {
            movement_data.deleteMovements(ids);
        }
    }
}
