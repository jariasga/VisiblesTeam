using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class OrderProduct
    {
        private Recipe recipe;
        private int quantity;

        public Recipe Recipe
        {
            get
            {
                return recipe;
            }

            set
            {
                recipe = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public OrderProduct(Recipe recipe, int quantity)
        {
            this.recipe = recipe;
            this.quantity = quantity;
        }
    }
}
