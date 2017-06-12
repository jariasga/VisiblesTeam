using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Algorithm;
using Npgsql;
using InkaArt.Classes;

namespace InkaArt.Business.Algorithm
{
    public class OrderController
    {
        private List<Order> orders;

        public OrderController()
        {
            orders = new List<Order>();
        }
        
        public void Load()
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = BD_Connector.ConnectionString.ConnectionString;
            connection.Open();

            // buscamos ordenes activas que aun no hayan sido entregadas
            string select = "SELECT * FROM inkaart.\"Order\" ";
            select += "INNER JOIN inkaart.\"Client\" ON(inkaart.\"Order\".\"idClient\" = inkaart.\"Client\".\"idClient\") ";
            select += "WHERE inkaart.\"Order\".\"bdStatus\" = 1 AND inkaart.\"Order\".\"orderStatus\" <> 'entregado'";
            NpgsqlCommand command = new NpgsqlCommand(select, connection);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // client
                int client_id = int.Parse(reader["idClient"].ToString());
                string name = reader["name"].ToString();
                long ruc = long.Parse(reader["ruc"].ToString());
                long dni = long.Parse(reader["dni"].ToString());
                int priority = int.Parse(reader["priority"].ToString());
                Client client = new Client(client_id, name, ruc, dni, priority);

                // order
                int id = int.Parse(reader["idOrder"].ToString()); ;
                DateTime delivery_date = DateTime.Parse(reader["deliveryDate"].ToString());
                orders.Add(new Order(id, client, delivery_date));

                // products
                // no se si para grasp es mejor tener una lista de todas las lineas de pedidos o en un pedido tener una lista de productos
            }

            connection.Close();
        }
        
        public int Count()
        {
            return orders.Count();
        }

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public Order this[int index]
        {
            get { return orders[index]; }
        }

        public List<Order> List()
        {
            return orders;
        }
    }

}
