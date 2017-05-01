using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ProcessProduct
    {
        public int id;
        public Process process;
        public int product;

        public ProcessProduct(int id, Process process, int product)
        {
            this.id = id;
            this.process = process;
            this.product = product;
        }

        public static ProcessProduct GetByID(List<ProcessProduct> list, int id)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].id == id) return list[i];
            return null;
        }
    }
}
