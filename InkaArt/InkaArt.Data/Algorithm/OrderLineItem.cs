using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class OrderLineItem
    {
        private int id_line_item;
        private int id_recipe;
        private int quantity;
        private int produced;

        public int ID
        {
            get { return id_line_item; }
        }
        public int Recipe
        {
            get { return id_recipe; }
            //set { recipe = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            //set { quantity = value; }
        }
        public int Produced
        {
            get { return produced; }
            set { produced = value; }
        }

        public OrderLineItem(int id_line_item, int id_recipe, int quantity)
        {
            this.id_line_item = id_line_item;
            this.id_recipe = id_recipe;
            this.quantity = quantity;
            this.produced = 0;
        }

        public OrderLineItem(int id_line_item, int id_recipe, int quantity, int produced)
        {
            this.id_line_item = id_line_item;
            this.id_recipe = id_recipe;
            this.quantity = quantity;
            this.produced = produced;
        }
    }
}
