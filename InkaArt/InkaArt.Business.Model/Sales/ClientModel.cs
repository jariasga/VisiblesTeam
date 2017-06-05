using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Model.Sales
{
    public class ClientModel
    {
        public int IdClient { get; set; }
        public int PersonType { get; set; }
        public string Name { get; set; }
        public int Ruc { get; set; }
        public int Dni { get; set; }
        public int Priority { get; set; }
        public int Type { get; set; }
        public int State { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
    }
}
