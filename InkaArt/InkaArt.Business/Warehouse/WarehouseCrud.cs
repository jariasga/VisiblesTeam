using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using InkaArt.Classes;
using InkaArt.Data;
using InkaArt.Data.Warehouse;
using System.Data;

namespace InkaArt.Business.Warehouse
{
    public class WarehouseCrud
    {
        public void createWarehouse(string name,string description, string address, string state)
        {
            WarehouseData conn = new WarehouseData();
            string insertQuery;

            insertQuery = "insert into inkaart.\"Warehouse\"  (name, description, address,state) values ('" + name + "', '" + description + "', '" + address + "','" + state + "');";
            conn.execute(insertQuery);
        }

        public void updateWareHouse(int id,string name, string description, string address, string state)
        {
            WarehouseData conn = new WarehouseData();
            string updateQuery;
            int filtros = 0;

            updateQuery = "update inkaart.\"Warehouse\" set ";
            if (name != "")
            {
                updateQuery = updateQuery + " name = '" + name + "'";
                filtros++;
            }
            if (description != "")
            {
                if (filtros > 0)
                {
                    updateQuery = updateQuery + ", description = '" + description + "'";
                }
                else
                {
                    updateQuery = updateQuery + " description = '" + description + "'";
                    filtros++;
                }
            }
                
            if (address != "")
            {
                if (filtros > 0)
                {
                    updateQuery = updateQuery + ", address = '" + address + "'";
                }
                else
                {
                    updateQuery = updateQuery + " address = '" + address + "'";
                    filtros++;
                }
            }
            if (state != "")
            {
                if (filtros > 0)
                {
                    updateQuery = updateQuery + ", state = '" + state + "'";
                }
                else
                {
                    updateQuery = updateQuery + " state = '" + state + "'";
                    filtros++;
                }
            }
            updateQuery = updateQuery + " where \"idWarehouse\"="+id+";";
            conn.execute(updateQuery);
        }

        public void deleteWarehouse(int [] id, int tam)
        {
            WarehouseData conn = new WarehouseData();
            string updateQuery="";
            int itemsBorrar = 0;

            for(itemsBorrar=0; itemsBorrar<tam; itemsBorrar++)
            {
                if (itemsBorrar == 0)
                {
                    updateQuery = "Update inkaart.\"Warehouse\" set state = 'Inactivo' where \"idWarehouse\"=" + id[itemsBorrar];
                    itemsBorrar++;
                }
                else
                {
                    updateQuery = updateQuery + " or \"idWarehouse\"=" + id[itemsBorrar];
                }
            }
            updateQuery = updateQuery + ";";
            conn.execute(updateQuery);
        }

        public NpgsqlDataReader readWarehouse(int id, string name, string address, string state)
        {
            WarehouseData conn = new WarehouseData();
            NpgsqlDataReader datos;
            string selectQuery;
            int numFiltros = 0;

            selectQuery = "Select * from inkaart.\"Warehouse\"";
            if (!(id == 0 && name == "" && address == "" && state == ""))//Esto garantiza que existe al menos 1 filtro
            {
                if (id != 0)
                {
                    numFiltros++;
                    selectQuery = selectQuery + " where \"idWarehouse\" = " + id;
                }

                if (name != "")
                {
                    if (numFiltros > 0)
                    {
                        selectQuery = selectQuery + " and name = '" + name + "'";
                    }
                    else
                    {
                        numFiltros++;
                        selectQuery = selectQuery + " where name = '" + name + "'";
                    }
                }

                if (address != "")
                {
                    if (numFiltros > 0)
                    {
                        selectQuery = selectQuery + " and address = '" + address + "'";
                    }
                    else
                    {
                        numFiltros++;
                        selectQuery = selectQuery + " where address = '" + address + "'";
                    }
                }

                if (state != "")
                {
                    if (numFiltros > 0)
                    {
                        selectQuery = selectQuery + " and state = '" + state + "'";
                    }
                    else
                    {
                        numFiltros++;
                        selectQuery = selectQuery + " where state = '" + state + "'";
                    }
                }
            }
            //Si no existió filtro se traerá toda la tabla
            selectQuery = selectQuery + " order by 1;"; 
            datos = conn.warehouseAdapter(selectQuery);

            return datos;
        }
    }
}
