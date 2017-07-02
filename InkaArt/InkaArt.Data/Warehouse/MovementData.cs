using InkaArt.Classes;
using InkaArt.Data.Production;
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
        private string table_name;
        private DataSet data;
        private DataTable table;
        private NpgsqlDataAdapter adap;

        public MovementData()
        {
            data = new DataSet();
            table_name = "Movement";
        }

        public NpgsqlDataReader executeQueryData(string query)
        {
            connect();
            NpgsqlCommand command = new NpgsqlCommand(query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            //closeConnection();
            return dr;
        }

        public NpgsqlDataAdapter movementAdapter()
        {
            NpgsqlDataAdapter orderAdapter = new NpgsqlDataAdapter();
            orderAdapter.SelectCommand = new NpgsqlCommand("SELECT * FROM inkaart.\"" + table_name + "\"", Connection);
            return orderAdapter;
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
            data = getData(adap, table_name);
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
            if (type == -1) return;

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
            if (reason == -1) return;

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
            if (warehouse == -1) return;

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
            if (date == null) return;

            int numParams = adap.SelectCommand.Parameters.Count();
            if (numParams == 0) adap.SelectCommand.CommandText += " WHERE ";
            else adap.SelectCommand.CommandText += " AND ";

            adap.SelectCommand.CommandText += "\"dateIn\" = to_date(:dateIn,'DD/MM/YYYY')";
            adap.SelectCommand.Parameters.Add(new NpgsqlParameter("dateIn", DbType.String));
            adap.SelectCommand.Parameters[numParams].Direction = ParameterDirection.Input;
            adap.SelectCommand.Parameters[numParams].SourceColumn = "dateIn";
            adap.SelectCommand.Parameters[numParams].NpgsqlValue = date;
        }

        private void byStatus(NpgsqlDataAdapter adap, int status)
        {
            if (status == -1) return;

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

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (movements.Contains(table.Rows[i]["idMovement"].ToString()))//string.Compare(table.Rows[i]["idMovement"].ToString(), id) == 0)
                {
                    table.Rows[i]["status"] = 0;
                }
            }

            updateData(data, adap, "Movement");
        }
                
        public DataRow getWarehouse(int warehouse_id)
        {
            WarehouseData warehouse_data = new WarehouseData();
            DataSet warehouse_dataset = new DataSet();
            NpgsqlDataAdapter warehouse_adap = warehouse_data.warehouseAdapter();
            warehouse_data.byId(warehouse_adap, warehouse_id);
            warehouse_adap.SelectCommand.CommandText += ";";
            warehouse_dataset.Clear();
            warehouse_dataset = warehouse_data.getData(warehouse_adap, "Warehouse");
            
            return warehouse_dataset.Tables[0].Rows[0];
        }

        public DataRow getMovementType(int type_id)
        {
            MovementTypeData type_data = new MovementTypeData();
            DataSet type_dataset = new DataSet();
            NpgsqlDataAdapter type_adap = type_data.movementTypeAdapter();
            type_data.byId(type_adap, type_id);
            type_dataset.Clear();
            type_dataset = type_data.getData(type_adap);

            return type_dataset.Tables[0].Rows[0];
        }

        public DataRow getMovementReason(int reason_id)
        {
            MovementReasonData reason_data = new MovementReasonData();
            DataSet reason_dataset = new DataSet();
            NpgsqlDataAdapter reason_adap = reason_data.movementReasonAdapter();
            reason_data.byId(reason_adap, reason_id);
            reason_dataset.Clear();
            reason_dataset = reason_data.getData(reason_adap);

            return reason_dataset.Tables[0].Rows[0];
        }

        public DataRow getProduct(int product_id)
        {
            FinalProductData product_data = new FinalProductData();
            DataTable product_datatable = new DataTable();
            product_datatable = product_data.GetProducts(product_id);

            return product_datatable.Rows[0];
        }

        public DataRow getRawMaterial(int raw_id)
        {
            RawMaterialData raw_data = new RawMaterialData();
            DataTable raw_datatable = new DataTable();
            raw_datatable = raw_data.GetRawMaterial(raw_id);

            return raw_datatable.Rows[0];
        }

        public void updateData(string queryUpdate)
        {
            connect();
            execute(queryUpdate);
        }

    }
}
