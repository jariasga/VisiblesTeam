using InkaArt.Data.Security;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Security
{
    public class RoleController
    {
        public RoleController()
        {
            role = new RoleData();
            adap = new NpgsqlDataAdapter();
            data = new DataSet();
        }

        private RoleData role;
        private NpgsqlDataAdapter adap;
        private DataSet data;
        private DataTable table;
        private DataRow row;
        public DataTable showData()
        {

            adap = role.roleAdapter();

            data = role.getData(adap, "Role");

            table = data.Tables["Role"];
            return table;
        }

        public int insertData(string description, bool generalParameters, bool userList, bool roles,
            bool suppliers, bool rawMaterials, bool unitOfmeasure, bool purcharseOrder, 
            bool finalProduct, bool productionProcess, bool productionTurn, bool workerAssignment, bool turnReport, bool productivityReport,
            bool clients, bool orders, bool generateReport,
            bool warehouse, bool movements, bool stockReport, bool kardexReport)
        {
            table = data.Tables["Role"];

            row = table.NewRow();

            row["description"] = description;
            //  Security
            row["security_general_parameters"] = generalParameters;
            row["security_user_list"] = userList;
            row["security_roles"] = roles;
            //  Purchases
            row["purchases_suppliers"] = suppliers;
            row["purchases_raw_materials"] = rawMaterials;
            row["purchases_unit_of_measure"] = unitOfmeasure;
            row["purchases_purchase_order"] = purcharseOrder;
            //  Production
            row["production_final_product"] = finalProduct;
            row["production_production_process"] = productionProcess;
            row["production_production_turn"] = productionTurn;
            row["production_worker_assignment"] = workerAssignment;
            row["production_turn_report"] = turnReport;
            row["production_productivity_report"] = productivityReport;
            //  Sales
            row["sales_clients"] = clients;
            row["sales_orders"] = orders;
            row["sales_generate_report"] = generateReport;
            //  Warehouse
            row["warehouse_warehouses"] = warehouse;
            row["warehouse_movements"] = movements;
            row["warehouse_stock_reports"] = stockReport;
            row["warehouse_kardex_reports"] = kardexReport;

            table.Rows.Add(row);

            int rowsAffected = role.insertData(data, adap, "Role");
            return rowsAffected;
        }

        public int updateData(int roleID, string description, bool generalParameters, bool userList, bool roles,
            bool suppliers, bool rawMaterials, bool unitOfmeasure, bool purcharseOrder,
            bool finalProduct, bool productionProcess, bool productionTurn, bool workerAssignment, bool turnReport, bool productivityReport,
            bool clients, bool orders, bool generateReport,
            bool warehouse, bool movements, bool stockReport, bool kardexReport)
        {
            table = data.Tables["Role"];

            row = getRoleRowbyID(roleID);
            
            row["description"] = description;
            //  Security
            row["security_general_parameters"] = generalParameters;
            row["security_user_list"] = userList;
            row["security_roles"] = roles;
            //  Purchases
            row["purchases_suppliers"] = suppliers;
            row["purchases_raw_materials"] = rawMaterials;
            row["purchases_unit_of_measure"] = unitOfmeasure;
            row["purchases_purchase_order"] = purcharseOrder;
            //  Production
            row["production_final_product"] = finalProduct;
            row["production_production_process"] = productionProcess;
            row["production_production_turn"] = productionTurn;
            row["production_worker_assignment"] = workerAssignment;
            row["production_turn_report"] = turnReport;
            row["production_productivity_report"] = productivityReport;
            //  Sales
            row["sales_clients"] = clients;
            row["sales_orders"] = orders;
            row["sales_generate_report"] = generateReport;
            //  Warehouse
            row["warehouse_warehouses"] = warehouse;
            row["warehouse_movements"] = movements;
            row["warehouse_stock_reports"] = stockReport;
            row["warehouse_kardex_reports"] = kardexReport;

            int rowsAffected = role.updateData(data, adap, "Role");
            return rowsAffected;
        }

        public DataRow getRoleRowbyID(int id)
        {
            table = showData();
            DataRow[] rows;
            rows = table.Select("id_role = " + id);
            row = rows[0];

            return row;
        }
    }
}
