using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using InkaArt.Classes;
using InkaArt.Data;
using InkaArt.Data.Warehouse;
using System.Windows.Forms;

namespace InkaArt.Business.Warehouse
{
    public class WarehouseCrud
    {
        private WarehouseData warehouseData;

        public WarehouseCrud()
        {
            warehouseData = new WarehouseData();
        }
        
        public int createWarehouse(string name, string description, string address, string state)
        {
            return warehouseData.InsertWarehouse(name, description, address, state);
        }

        public int updateWarehouse(string id, string name, string description, string address, string state)
        {
            return warehouseData.updateWarehouse(id, name, description, address, state);
        }

        public DataTable GetWarehouses(string id = "", string name = "", string description = "", string address = "", string state = "")
        {
            int intId = -1, intAux;
            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            return warehouseData.GetWarehouses(intId, name, description, address, state);
        }
        
        public void createMovement(int idNote, int idBill, int idMovementType, int idWarehouse, int idMovementReason, string dateIn)
        {
            WarehouseData conn = new WarehouseData();
            string insertQuery;

            insertQuery = "insert into inkaart.\"Movement\"(\"idNote\", \"idBill\", \"idMovementType\",\"idWarehouse\",\"idMovementReason\") values (" + idNote + ", " + idBill + ", " + idMovementType + "," + idWarehouse + ", " + idMovementReason + ");";
            conn.execute(insertQuery);
        }

        public string makeValidations(string name, string description, string address)
        {
            if (name.Equals("") || description.Equals("") || address.Equals(""))
                return "Por favor, complete todos los campos antes de continuar";
            return "OK";
        }

        /*
        public bool existeProducto(int idProduct,int idWarehouse)
        {
            WarehouseData conn = new WarehouseData();
            string selectQuery="";
            NpgsqlDataReader datos;

            selectQuery = selectQuery + "select count(*) from inkaart.\"Product-Warehouse\" where \"idProduct\" = " + idProduct + " and \"idWarehouse\" = " + idWarehouse + ";";
            datos = conn.warehouseAdapter(selectQuery);
            int cantidad = 0;

            while (datos.Read())
            {
                cantidad = Convert.ToInt32(datos[0]);                
            }

            if (cantidad > 0)
                return true;
            else
                return false;
        }

        public void insertProduct(int idProd,int idWarehouse)
        {
            string query="";

            if (existeProducto(idProd,idWarehouse))
            {
                WarehouseData conn2 = new WarehouseData();
                string selectQuery = "";
                NpgsqlDataReader datos2;

                selectQuery = selectQuery + "select \"currentStock\", \"virtualStock\" from inkaart.\"Product-Warehouse\" where \"idProduct\" = " + idProd + " and \"idWarehouse\" = " + idWarehouse + ";";
                datos2 = conn2.warehouseAdapter(selectQuery);
                int currentStock = 0, virtualStock = 0;

                while (datos2.Read())
                {
                    currentStock = Convert.ToInt32(datos2[0]) + 1;
                    virtualStock = Convert.ToInt32(datos2[1]) + 1;
                }
                query = "update inkaart.\"Product-Warehouse\" set \"currentStock\" = " + currentStock + ", \"virtualStock\" = " + virtualStock + " where \"idProduct\" = " + idProd + " and \"idWarehouse\" = " + idWarehouse + ";";

            }
            else
            {
                query = "insert into inkaart.\"Product-Warehouse\"(\"idProduct\", \"idWarehouse\", \"currentStock\",\"virtualStock\",\"state\") values (" + idProd + ", " + idWarehouse + ", 0, 0, 'Activo');";
            }

            WarehouseData conn = new WarehouseData();
            conn.execute(query);
            
        }*/

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

        /*
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
//            conn.closeConnection();
            return datos;
        }*/

        /*
        public void massiveUpload(string filename)
        {
            using (var fs = File.OpenRead(filename))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    // creamos usuario
                    int idNote, idBill, idMovementType, idWarehouse, idMovementReason,idProd;
                    string dateIn="";
                    idNote = int.Parse(values[2]);
                    idBill = int.Parse(values[7]);
                    idProd = int.Parse(values[4]);
                    idMovementType = int.Parse(values[8]);
                    idWarehouse = int.Parse(values[0]);
                    idMovementReason = int.Parse(values[3]);
                    dateIn = values[6];
                    createMovement(idNote, idBill, idMovementType, idWarehouse, idMovementReason, dateIn);
                    insertProduct(idProd, idWarehouse);
                    // agregamos el producto a la tabla producto por almacen                    
                }
                MessageBox.Show("Carga de movimientos con éxito", "Cargar Datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }*/
    }
}
