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
            role.connect();

            adap = role.roleAdapter();

            data = role.getData(adap, "Role");

            table = data.Tables["Role"];
            return table;
        }

        public int insertData(string description)
        {
            role.connect();

            table = data.Tables["Role"];

            row = table.NewRow();

            row["description"] = description;

            table.Rows.Add(row);

            int rowsAffected = role.insertData(data, adap, "Role");
            return rowsAffected;
        }

        public int updateData(int roleID, string description)
        {
            role.connect();

            table = data.Tables["Role"];

            row = getRoleRowbyID(roleID);
            
            row["description"] = description;

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

        public void filterData()
        {

        }
    }
}
