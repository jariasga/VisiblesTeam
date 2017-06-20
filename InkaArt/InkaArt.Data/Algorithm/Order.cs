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

        public void AddLineItem(OrderLineItem line_item)
        {
            this.line_items.Add(line_item);
        }

        public bool UpdateLineItem(int id_recipe)
        {
            foreach (OrderLineItem line_item in line_items)
                if (line_item.Recipe == id_recipe)
                {
                    line_item.Produced++;
                    return true;
                }
            return false;
        }

        public bool Completed()
        {
            throw new NotImplementedException();

            /*foreach (OrderLineItem line_item in line_items)
                if (line_item.Produced < line_item.Quantity) return false;
            return true;*/
        }

        public OrderLineItem this[int index]
        {
            get { return this.line_items[index]; }
        }

        public int NumberOfLineItems
        {
            get { return this.line_items.Count; }
        }

    }
}
