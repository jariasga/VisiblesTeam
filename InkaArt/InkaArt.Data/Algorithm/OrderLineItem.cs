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
        private Recipe recipe;
        private DateTime date;
        private int quantity;
        private int produced;

        public int ID
        {
            get { return id_line_item; }
        }
        public Recipe Recipe
        {
            get { return recipe; }
            //set { recipe = value; }
        }
        public DateTime Date
        {
            get { return date; }
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

        public OrderLineItem(int id_line_item, DateTime date, Recipe recipe, int quantity, int produced)
        {
            this.id_line_item = id_line_item;
            this.date = date;
            this.recipe = recipe;
            this.quantity = quantity;
            this.produced = produced;
        }

        public override string ToString()
        {
            string recipe = (this.recipe == null) ? "null" : this.recipe.Description + " " + this.recipe.Version;
            return string.Format("ID={0}, Receta={1}, Cant.solicitada={2}, Cant.producida={3}", this.id_line_item, recipe, this.quantity, this.produced);
        }
    }
}
