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
        //private DataTable salesTable;

        public ReportsData()
        {
            data = new DataSet();            
        }

        public DataTable getDataSales(string fechaIni, string fechaFin, string producto)
        {
            string dateIni = fechaIni.Replace(".", string.Empty);
            string dateFin = fechaFin.Replace(".", string.Empty);

            string command_query = "WITH queryid as (select \"idProduct\", \"localPrice\", \"exportPrice\" from inkaart.\"Product\" where name = '" + producto + "'), ";
            command_query += "querylineitem as (select \"quantity\", \"idOrder\", \"localPrice\", \"exportPrice\" from inkaart.\"LineItem\" l, queryid q where l.\"idProduct\" = q.\"idProduct\"), ";
            command_query += "queryorder as (select \"deliveryDate\", \"idClient\", \"quantity\", \"localPrice\", \"exportPrice\" from inkaart.\"Order\" o, querylineitem ql where o.\"idOrder\" = ql.\"idOrder\" AND o.\"deliveryDate\" >= '" + dateIni + "' AND o.\"deliveryDate\" <= '" + dateFin + "' ) ";
            command_query += "select \"deliveryDate\", \"name\" as clientName, case when \"type\" = 0 then 'Nacional' else 'Internacional' end as clientType, \"quantity\", case when \"clientType\" = 0 then \"localPrice\"*\"quantity\" else \"exportPrice\"*\"quantity\" end as totalAmount ";
            command_query += "from inkaart.\"Client\" c, queryorder o where c.\"idClient\" = o.\"idClient\";";

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


    }
}
