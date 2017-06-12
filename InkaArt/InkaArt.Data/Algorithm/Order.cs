using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Order
    {
        private int id_order;
        private DateTime delivery_date;
        private Client client;
        private List<OrderProduct> products;
        //private double sale_amount;
        //private double igv;
        //private double total_amount;
        //private string order_status;
        //private int db_status;
        //private string type;
        //private string reason;
        //private double total_dev;

        public DateTime DeliveryDate
        {
            get
            {
                return delivery_date;
            }

            set
            {
                delivery_date = value;
            }
        }

        public int IdOrder
        {
            get
            {
                return id_order;
            }

            set
            {
                id_order = value;
            }
        }

        public Client Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        public string Description
        {
            // para la lista de pedidos en la configuracion de simulacion
            get
            {
                return client.Name + " " + client.Document + ": " + delivery_date.ToShortDateString();
            }            
        }

        internal List<OrderProduct> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
            }
        }

        // nos interesa el cliente, los productos, fecha de entrega

        public Order(int id, Client client, DateTime delivery_date)
        {
            this.id_order = id;
            this.client = client;
            this.delivery_date = delivery_date;
        }

        public void AddProduct(OrderProduct product)
        {
            this.products.Add(product);
        }

    }
}
