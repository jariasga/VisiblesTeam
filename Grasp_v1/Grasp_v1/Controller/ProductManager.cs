using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Model;

namespace InkaArt.Controller
{
    class ProductManager
    {
        private List<Product> products;

        public ProductManager()
        {
            products = new List<Product>();
            //Cargar datos en duro
            products.Add(new Product(1, "Huacos Precolombinos", 10));
            products.Add(new Product(2, "Tallados en Piedras de Huamanga", 10));
            products.Add(new Product(3, "Retablos", 10));
        }

        public Product GetByID(int id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].id == id) return products[i];
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

        public void Print()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write("Producto {0}: ", i + 1);
                products[i].Print();
            }
        }
    }
}
