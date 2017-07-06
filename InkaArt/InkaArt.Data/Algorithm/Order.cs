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
        private List<OrderLineItem> line_items;
        
        public int ID
        {
            get { return id_order; }
            //set { id_order = value; }
        }
        public DateTime DeliveryDate
        {
            get { return delivery_date; }
            set { delivery_date = value; }
        }
        public Client Client
        {
            get { return client; }
            //set { client = value; }
        }
        public string Description
        {
            // para la lista de pedidos en la configuracion de simulacion
            get { return client.Name + " " + client.Document + ": " + delivery_date.ToShortDateString(); }            
        }
        
        // nos interesa el cliente, los productos, fecha de entrega
        public Order(int id, Client client, DateTime delivery_date)
        {
            this.id_order = id;
            this.client = client;
            this.delivery_date = delivery_date;
            this.line_items = new List<OrderLineItem>();
        }

        //Este constructor debe crear una copia profunda del objeto, para evitar referencias
        public Order(Order copy)
        {
            this.id_order = copy.id_order;
            this.client = copy.client;
            this.delivery_date = copy.delivery_date;
            this.line_items = new List<OrderLineItem>();
            for (int i = 0; i < copy.NumberOfLineItems; i++) this.line_items.Add(new OrderLineItem(copy.line_items[i]));
        }

        public List<OrderLineItem> OrderLineItems
        {
            get { return line_items; }
        }

        public OrderLineItem this[int index]
        {
            get { return this.line_items[index]; }
        }

        public int NumberOfLineItems
        {
            get { return this.line_items.Count; }
        }

        public bool IsCompleted()
        {
            if (line_items == null || line_items.Count <= 0) return false;
            for (int i = 0; i < line_items.Count; i++)
                if (line_items[i].Produced < line_items[i].Quantity) return false;
            return true;
        }

        public bool RemoveLineItem(int order_line_index)
        {
            this.line_items.RemoveAt(order_line_index);
            return (this.line_items.Count <= 0);
        }
    }
}
