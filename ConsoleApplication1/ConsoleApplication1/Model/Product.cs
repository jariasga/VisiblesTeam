using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Model
{
    class Product
    {
        //Atributos
        public int id { get; }
        public string name { get; }
        public double price { get; }

        //Constructor
        public Product(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        //Métodos
        public void Print()
        {
            Console.WriteLine("Producto #{0}: {1} (precio = {2})", this.id, this.name,
                this.price);
        }

        public new string ToString()
        {
            return name + " (id " + id + ")";
        }
    }
}
