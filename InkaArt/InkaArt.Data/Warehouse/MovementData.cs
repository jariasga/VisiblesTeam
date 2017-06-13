using InkaArt.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Warehouse
{
    public class MovementData : BD_Connector
    {
        private DataSet data;
        private DataTable table;
        private DataRow row;
        private NpgsqlDataAdapter adap;

        public MovementData()
        {
            data = new DataSet();
        }

        public DataTable GetMovements(int id = -1, int type = -1, int reason = -1, int warehouse = -1, string date = null, int status = -1)
        {
             
            adap = movementAdapter();

            byId(adap, id);
            byType(adap, type);
            byReason(adap, reason);
            byWarehouse(adap, warehouse);
            byDate(adap, date);
            status = status < 0 ? status * (-1) : status; // si no se ingresan campos (carga inicial) solo mostramos los activos
            byStatus(adap, status);
            adap.SelectCommand.CommandText += ";";

            data.Clear();
            data = getData(adap, "Orders");
            DataTable movement_list = new DataTable();
            movement_list = data.Tables[0];
            return movement_list;
        }

        private void byId(NpgsqlDataAdapter adap, int id)
        {
            if (id == -1) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";

            adap.SelectCommand.CommandText += "\"idMovement\" = :idMovement";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idMovement", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idMovement";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = id;
        }
        
        private void byType(NpgsqlDataAdapter adap, int type)
        {
            if (type == 0) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";

            adap.SelectCommand.CommandText += "\"idMovementType\" = :idMovementType";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idMovementType", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idMovementType";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = type;
        }

        private void byReason(NpgsqlDataAdapter adap, int reason)
        {
            if (reason == 0) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";

            adap.SelectCommand.CommandText += "\"idMovementReason\" = :idMovementReason";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idMovementReason", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idMovementReason";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = reason;
        }

        private void byWarehouse(NpgsqlDataAdapter adap, int warehouse)
        {
            if (warehouse == 0) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE (";
            else adap.SelectCommand.CommandText += " AND (";

            adap.SelectCommand.CommandText += "\"idWarehouse\" = :idWarehouse";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idWarehouse", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idWarehouse";
            adap.SelectCommand.Parameters[numParams++].NpgsqlValue = warehouse;

            adap.SelectCommand.CommandText += " OR ";
            adap.SelectCommand.CommandText += "\"idWarehouseDestiny\" = :idWarehouseDestiny )";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idWarehouseDestiny", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "idWarehouseDestiny";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = warehouse;
        }

        private void byDate(NpgsqlDataAdapter adap, string date)
        {
            //if (reason == 0) return;

            //int numParams = adap.SelectCommand.Parameters.Count();
            //if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            //else adap.SelectCommand.CommandText += " AND ";

            //adap.SelectCommand.CommandText += "\"idMovementReason\" = :idMovementReason";
            //adap.SelectCommand.Parameters.Add(new NpgsqlParameter("idMovementReason", DbType.Int32));
            //adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            //adap.SelectCommand.Parameters[numParams].SourceColumn = "idMovementReason";
            //adap.SelectCommand.Parameters[numParams].NpgsqlValue = reason;
        }

        private void byStatus(NpgsqlDataAdapter adap, int status)
        {
            if (status == 0) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";

            adap.SelectCommand.CommandText += "\"status\" = :status";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("status", DbType.Int32));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "status";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = status;
        }
        
        public void deleteMovements(List<string> movements)
        {
            adap = movementAdapter();
            data.Clear();
            data = getData(adap, "Movement");
            table = data.Tables["Movement"];

            foreach (string id in movements)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (string.Compare(table.Rows[i]["idMovement"].ToString(), id) == 0)
                    {
                        table.Rows[i]["status"] = 0;
                        break;
                    }
                }
            }
            updateData(data, adap, "Movement");
        }

        public NpgsqlDataAdapter movementAdapter()
        {
            NpgsqlDataAdapter orderAdapter = new NpgsqlDataAdapter();
            orderAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"Movement\"", Connection);
            return orderAdapter;
        }
        
        public DataRow getWarehouse(int warehouse_id)
        {
            WarehouseData warehouse_data = new WarehouseData();
            DataSet warehouse_dataset = new DataSet();
            NpgsqlDataAdapter warehouse_adap = warehouse_data.warehouseAdapter();
            warehouse_data.byId(warehouse_adap, warehouse_id);
            warehouse_adap.SelectCommand.CommandText += ";";
            warehouse_dataset.Clear();
            warehouse_dataset = warehouse_data.getData(adap, "Warehouse");
            
            return warehouse_dataset.Tables[0].Rows[0];
        }

        public DataRow getMovementType(int type_id)
        {
            MovementReasonData type_data = new MovementReasonData();
            DataSet type_dataset = new DataSet();
            NpgsqlDataAdapter type_adap = type_data.movementReasonAdapter();
            type_data.byId(type_adap, type_id);
            type_dataset.Clear();
            type_dataset = type_data.getData(adap);

            return type_dataset.Tables[0].Rows[0];
        }

        public DataRow getMovementReason(int reason_id)
        {
            MovementTypeData reason_data = new MovementTypeData();
            DataSet reason_dataset = new DataSet();
            NpgsqlDataAdapter reason_adap = reason_data.movementTypeAdapter();
            reason_data.byId(reason_adap, reason_id);
            reason_dataset.Clear();
            reason_dataset = reason_data.getData(adap, "Warehouse");

            return reason_dataset.Tables[0].Rows[0];
        }
        
    }
}
