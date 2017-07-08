using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using InkaArt.Classes;

namespace InkaArt.Data.Reports
{
    public class ReportsData : BD_Connector
    {
        private DataSet data;

        public ReportsData()
        {
            data = new DataSet();            
        }

        public DataTable getDataSales(string fechaIni, string fechaFin, string producto)
        {
           
            string command_query = "WITH queryid as (   select \"idProduct\", \"localPrice\", \"exportPrice\" "+
                                                        "from inkaart.\"Product\" "+ 
                                                        "where name = '" + producto + "'), ";
            command_query += "querylineitem as (    select \"quantity\", \"idOrder\", \"localPrice\", \"exportPrice\" "+
                                                    "from inkaart.\"LineItem\" l, queryid q "+
                                                    "where l.\"idProduct\" = q.\"idProduct\"), ";
            command_query += "queryorder as (   select \"deliveryDate\", \"idClient\", \"quantity\", \"localPrice\", \"exportPrice\" "+
                                                "from inkaart.\"Order\" o, querylineitem ql "+
                                                "where o.\"idOrder\" = ql.\"idOrder\" "+
                                                "AND o.\"deliveryDate\" >= '" + fechaIni + "' "+
                                                "AND o.\"deliveryDate\" <= '" + fechaFin + "' ) ";
            command_query += "select    \"deliveryDate\", \"name\" as clientName, "+
                                        "case when \"type\" = 0 then 'Nacional' "+
                                                                "else 'Internacional' end as clientType,"+
                                        "\"quantity\", "+
                                        "case when \"clientType\" = 0   then \"localPrice\"*\"quantity\" "+
                                                                        "else \"exportPrice\"*\"quantity\" end as totalAmount "+
                                        "from inkaart.\"Client\" c, queryorder o "+
                                        "where c.\"idClient\" = o.\"idClient\";";

            Connection = new NpgsqlConnection(ConnectionString.ConnectionString);
            Connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(command_query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            DataTable salesTable = new DataTable();
            salesTable.Columns.Add("FechaEntrega", typeof(DateTime));
            salesTable.Columns.Add("Cliente", typeof(string));
            salesTable.Columns.Add("TipoCliente", typeof(string));
            salesTable.Columns.Add("Cantidad", typeof(int));
            salesTable.Columns.Add("MontoTotal", typeof(string));

            while (dr.Read())
            {
                salesTable.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
            }
            Connection.Close();

            return salesTable;
        }

        public DataTable getDataStocks(int flag)
        {
            string command_query = "WITH "; 
            if (flag == 0)  //productos
            {
                command_query += "products as (select \"idProduct\", \"name\", 'unidad'::text as unit " +
                                                   "from inkaart.\"Product\"), ";
                command_query += "warehouseR as (   select \"idWarehouse\", p.\"idProduct\" as idItem, \"currentStock\", \"virtualStock\", \"name\", \"unit\", 'Producto'::text as typeItem " +
                                                    "from inkaart.\"Product-Warehouse\" pw, products p " +
                                                    "where pw.\"idProduct\" = p.\"idProduct\") ";

            } else if (flag == 1) //materias primas
            {
                command_query += "rawmaterials as ( select \"id_raw_material\", rm.\"name\", u.\"name\" as unit " +
                                                    "from inkaart.\"RawMaterial\" rm, inkaart.\"UnitOfMeasurement\" u " +
                                                    "where rm.\"unit\"::int = u.\"id_unit\"), ";
                command_query += "warehouseR as (   select \"idWarehouse\", r.\"id_raw_material\" as idItem, \"currentStock\", \"virtualStock\", \"name\", \"unit\", 'Materia Prima'::text as typeItem " +
                                                    "from inkaart.\"RawMaterial-Warehouse\" rw, rawmaterials r " +
                                                    "where rw.\"idRawMaterial\" = r.\"id_raw_material\") ";

            } else //ambos
            {
                command_query += "products as (select \"idProduct\", \"name\", 'unidad'::text as unit " +
                                                   "from inkaart.\"Product\"), ";
                command_query += "rawmaterials as ( select \"id_raw_material\", rm.\"name\", u.\"name\" as unit " +
                                                    "from inkaart.\"RawMaterial\" rm, inkaart.\"UnitOfMeasurement\" u "+
                                                    "where rm.\"unit\"::int = u.\"id_unit\"), ";
                command_query += "warehouseR as (   select \"idWarehouse\", p.\"idProduct\" as idItem, \"currentStock\", \"virtualStock\", \"name\", \"unit\", 'Producto'::text as typeItem " +
                                                    "from inkaart.\"Product-Warehouse\" pw, products p " +
                                                    "where pw.\"idProduct\" = p.\"idProduct\" " +
                                                    "UNION " +
                                                    "select \"idWarehouse\", r.\"id_raw_material\" as idItem, \"currentStock\", \"virtualStock\", \"name\", \"unit\", 'Materia Prima'::text as typeItem " +
                                                    "from inkaart.\"RawMaterial-Warehouse\" rw, rawmaterials r " +
                                                    "where rw.\"idRawMaterial\" = r.\"id_raw_material\") ";
            }

            command_query += "  select typeItem, " +
                                    "idItem, " +
                                    "wr.\"name\" as nameItem, " +
                                    "w.\"name\" as nameWarehouse, " +
                                    "\"currentStock\", " +
                                    "\"virtualStock\", " +
                                    "unit " +
                                    "from inkaart.\"Warehouse\" w, warehouseR wr " +
                                    "where w.\"idWarehouse\" = wr.\"idWarehouse\"; ";

            Connection = new NpgsqlConnection(ConnectionString.ConnectionString);
            Connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(command_query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            DataTable stocksTable = new DataTable();
            stocksTable.Columns.Add("Tipo", typeof(string));
            stocksTable.Columns.Add("IdItem", typeof(int));
            stocksTable.Columns.Add("NameItem", typeof(string));
            stocksTable.Columns.Add("NameWarehouse", typeof(string));
            stocksTable.Columns.Add("CurrentStock", typeof(int));
            stocksTable.Columns.Add("VirtualStock", typeof(int));
            stocksTable.Columns.Add("Unit", typeof(string));

            while (dr.Read())
            {
                stocksTable.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
            }
            Connection.Close();
            

            return stocksTable;
        }
        
        public DataTable getDataSimulation(string name)
        {
            string command_query = "select  a.\"date\", "+
                                            "a.\"tabu_iterations\", "+
                                            "a.\"huacos_produced\", "+
                                            "a.\"huamanga_produced\", "+
                                            "a.\"altarpiece_produced\", "+
                                            "a.\"assigned_workers\" "+
                                    "from   inkaart.\"Assignment\" a, inkaart.\"Simulation\" s "+
                                    "where  a.\"id_simulation\" = s.\"id_simulation\" "+
                                            "and s.\"name\" = '" + name + "'; ";

            Connection = new NpgsqlConnection(ConnectionString.ConnectionString);
            Connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(command_query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            DataTable simulationTable = new DataTable();
            simulationTable.Columns.Add("Fecha", typeof(DateTime));
            simulationTable.Columns.Add("Iteraciones", typeof(int));
            simulationTable.Columns.Add("Huacos", typeof(string));
            simulationTable.Columns.Add("Piedras", typeof(string));
            simulationTable.Columns.Add("Retablos", typeof(string));
            simulationTable.Columns.Add("Trabajadores", typeof(int));

            while (dr.Read())
            {
                simulationTable.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }

            return simulationTable;
        }

        public DataTable getDataMovements(string fechaIni, string fechaFin, List<string> items, List<string> warehouses)
        {
            string command_query =  "WITH tablaKardex as ";
            command_query +=        "(select 	m.\"dateIn\", "+
                                                "m.\"idMovement\", "+
                                                "mt.\"description\" as movType, "+
                                                "mn.\"description\" as movName, "+
                                                "a.\"name\" as warehouseName, "+
                                                "r.\"name\" as itemName, "+   
                                                "m.\"quantity\" "+
                                    "from       inkaart.\"Movement\" m, inkaart.\"Warehouse\" a, inkaart.\"RawMaterial\" r, "+
                                                "inkaart.\"MovementName\" mn, inkaart.\"MovementType\" mt "+
                                    "where      m.\"idWarehouse\" = a.\"idWarehouse\" "+
                                    "and        m.\"idItem\" = r.\"id_raw_material\" "+
                                    "and        m.\"idMovementType\" = mt.\"idMovementType\" "+
                                    "and        m.\"idMovementReason\" = mn.\"idMovName\" "+
                                    "UNION "+
                                    "select     m.\"dateIn\", "+
                                                "m.\"idMovement\", "+
                                                "mt.\"description\" as movType, " +
                                                "mn.\"description\" as movName, " +
                                                "a.\"name\" as warehouseName, " +
                                                "p.\"name\" as itemName, " +
                                                "m.\"quantity\" " +
                                    "from        inkaart.\"Movement\" m, inkaart.\"Warehouse\" a, inkaart.\"Product\" p, "+
                                                "inkaart.\"MovementName\" mn, inkaart.\"MovementType\" mt "+
                                    "where       m.\"idWarehouse\" = a.\"idWarehouse\" "+
                                    "and         m.\"idItem\" = p.\"idProduct\"  " +
                                    "and         m.\"idMovementType\" = mt.\"idMovementType\"  " +
                                    "and         m.\"idMovementReason\" = mn.\"idMovName\") "+
                                    "select * 	from tablaKardex "+
                                    "where		\"dateIn\" >= '" + fechaIni + "' "+
                                    "and         \"dateIn\" <= '" + fechaFin + "' ";

            if (items.Count > 0)
            {
                command_query +=    "and	    itemName in ('"+String.Join("' , '",items)+"')";
            }
            if (warehouses.Count > 0)
            {
                command_query += "and        warehouseName in ('" + String.Join("' , '", warehouses) + "')";
            }
            command_query += ";";

            Connection = new NpgsqlConnection(ConnectionString.ConnectionString);
            Connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(command_query, Connection);
            NpgsqlDataReader dr = command.ExecuteReader();

            DataTable movementsTable = new DataTable();
            movementsTable.Columns.Add("Fecha", typeof(DateTime));
            movementsTable.Columns.Add("IdMovimiento", typeof(int));
            movementsTable.Columns.Add("TipoMovimiento", typeof(string));
            movementsTable.Columns.Add("Razon", typeof(string));
            movementsTable.Columns.Add("Almacen", typeof(string));
            movementsTable.Columns.Add("Item", typeof(string));
            movementsTable.Columns.Add("Cantidad", typeof(int));

            while (dr.Read())
            {
                movementsTable.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
            }

            return movementsTable;
        }

    }
}
