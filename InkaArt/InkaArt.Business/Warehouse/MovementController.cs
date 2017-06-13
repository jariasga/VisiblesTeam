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

        public DataTable GetMovements(bool filters = false, string str_id = "", string str_type = "", string str_reason = "", string str_warehouse = "", string str_date = null, string str_status = "")
        {
            if (filters)
            {
                int id = str_id == ""? -1 : int.Parse(str_id);
                int type = str_type == "" ? -1 : int.Parse(str_type);
                int reason = str_reason == "" ? -1 : int.Parse(str_reason);
                int warehouse = str_warehouse == "" ? -1 : int.Parse(str_warehouse);
                int status = str_status == "" ? -1 : int.Parse(str_status);

                return movement_data.GetMovements(id, type, reason, warehouse, str_date, status);
            }

            return movement_data.GetMovements();
        }

        public string getReasonDescription(string reason_id)
        {
            int id = reason_id == "" ? -1 : int.Parse(reason_id);
            DataRow reason = movement_data.getMovementReason(id);
            return reason == null? "" : reason["description"].ToString();
        }

        public string getTypeDescription(string type_id)
        {
            int id = type_id == "" ? -1 : int.Parse(type_id);
            DataRow type = movement_data.getMovementType(id);
            return type == null? "" : type["description"].ToString();
        }

        public string getWarehouseName(string warehouse_id)
        {
            int id = warehouse_id == "" ? -1 : int.Parse(warehouse_id);
            DataRow warehouse = movement_data.getWarehouse(id);
            return warehouse == null ? "" : warehouse["name"].ToString();
        }

        public string getItemName(int item_type, string item_id)
        {
            int id = item_id == "" ? -1 : int.Parse(item_id);
            DataRow item = item_type == 0 ? movement_data.getRawMaterial(id) : movement_data.getProduct(id);
            return item == null ? "" : item["name"].ToString();
        }

        public void deleteMovements(List<string> ids)
        {
            movement_data.deleteMovements(ids);
        }
    }
}
