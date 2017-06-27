using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Algorithm;
using Npgsql;
using InkaArt.Classes;
using NpgsqlTypes;

namespace InkaArt.Business.Algorithm
{
    public class OrderController
    {

        private List<Order> orders;

        public OrderController()
        {
            orders = new List<Order>();
        }

        public OrderController(OrderController original_orders)
        {
            this.orders = new List<Order>(original_orders.orders);
            //Ordenar pedidos por día y luego por prioridad del cliente
            this.orders = this.orders.OrderBy(order => order.DeliveryDate).ThenBy(order => order.Client.Priority).ToList();
        }

        public void Load(RecipeController recipes)
        {
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            // buscamos ordenes activas que aun no hayan sido entregadas
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM inkaart.\"Order\" " +
                "INNER JOIN inkaart.\"Client\" ON(inkaart.\"Order\".\"idClient\" = inkaart.\"Client\".\"idClient\") " +
                "WHERE inkaart.\"Order\".\"bdStatus\" = 1 " +
                "AND inkaart.\"Order\".\"orderStatus\" <> 'facturado'" , connection);
                //"AND inkaart.\"Order\".\"deliveryDate\" < to_date("+ DateTime.Now.ToShortDateString() + ",'DD/MM/YYYY')";

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
            }
            reader.Close();

            // Leer cada detalle del pedido
            // cantidad faltante = solicitada - facturada
            foreach (Order order in orders)
            {                
                command = new NpgsqlCommand("SELECT \"idLineItem\", \"idRecipe\", quantity, \"quantityInvoiced\" FROM inkaart.\"LineItem\" " +
                    "WHERE \"idOrder\" = :idOrder " +
                    "AND \"quantity\" < \"quantityInvoiced\"", connection);
                command.Parameters.AddWithValue("idOrder", NpgsqlDbType.Integer, order.ID);

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id_line_item = int.Parse(reader["idLineItem"].ToString());
                    int id_recipe = int.Parse(reader["idRecipe"].ToString());
                    int quantity = int.Parse(reader["quantity"].ToString()) - int.Parse(reader["quantityInvoiced"].ToString());
                    order.AddLineItem(new OrderLineItem(id_line_item, recipes.GetByID(id_recipe), quantity));
                }
                reader.Close();
            }

            connection.Close();
        }

        public int NumberOfOrders
        {
            get { return orders.Count; }
        }

        public List<Order> Orders
        {
            get
            {
                return orders;
            }

            set
            {
                orders = value;
            }
        }

        public void Add(Order order)
        {
            this.orders.Add(order);
        }

        public void RemoveAt(int index)
        {
            this.orders.RemoveAt(index);
        }

        public void RemoveAll(Predicate<Order> match)
        {
            this.orders.RemoveAll(match);
        }

        public bool Contains(Order order)
        {
            return this.orders.Contains(order);
        }

        public Order this[int index]
        {
            get { return this.orders[index]; }
        }

        public List<Order> List()
        {
            return this.orders;
        }

        public Order GetByID(int order_id)
        {
            return orders.Where(o => o.ID.Equals(order_id)).ToList().First();
        }
    }
}
