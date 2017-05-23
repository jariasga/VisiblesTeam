using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGRASP.Controller
{
    class ProductManager
    {
        private List<Product> products;

        public ProductManager()
        {
            products = new List<Product>();
            //Colocar por mientras en duro los datos
            products.Add(new Product(1, "Huacos Precolombinos"));
            products.Add(new Product(2, "Tallados en Piedras de Huamanga"));
            products.Add(new Product(3, "Retablos"));
        }

        public Product GetProduct(int id)
        {
            for (int i = 0; i < products.Count; i++) {
                if (products[i].ID == id) return products[i];
            }
            return null;
        }

        public int NumberOfProducts()
        {
            return products.Count;
        }

        public Product this[int index]
        {
            get { return products[index]; }
        }
    }
}
