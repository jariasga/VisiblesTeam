using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Model.Security
{
    public class UserModel
    {
        public int IdUser { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
