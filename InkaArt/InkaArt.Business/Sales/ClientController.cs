using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Sales;
using InkaArt.Business.Model.Sales;
using Npgsql;
using System.Data;

namespace InkaArt.Business.Sales
{
    public class ClientController
    {
        ClientData clientData = new ClientData();
        public string AddClient(string personType, string name, string ruc, string dni, string priority, string type, string state, string address, string phone, string contact, string email)
        {
            int personTypeInt = Int32.Parse(personType);
            int rucInt = Int32.Parse(ruc);
            int dniInt = Int32.Parse(dni);
            int stateInt = Int32.Parse(state);
            int typeInt = Int32.Parse(type);
            int priorityInt = Int32.Parse(priority);
            int phoneInt = Int32.Parse(phone);
            int response = clientData.InsertClient(personTypeInt, name, rucInt, dniInt, priorityInt, typeInt, stateInt, address, phoneInt, contact, email);
            if (response == 0)
            {
                return "El cliente ha sido agregado con éxito.";
            }else
            {
                return "Hubo un error al agregar un cliente.";
            }
        }
    }
}
