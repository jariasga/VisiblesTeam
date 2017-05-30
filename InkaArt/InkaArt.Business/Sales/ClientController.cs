using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Sales;
using System.Data;

namespace InkaArt.Business.Sales
{
    public class ClientController
    {
        private ClientData clientData;
        public ClientController()
        {
            clientData = new ClientData();

        }
        public int AddClient(string personType, string name, string ruc, string dni, string priority, string type, string state, string address, string phone, string contact, string email)
        {
            int personTypeInt = int.Parse(personType);
            int rucInt = int.Parse(ruc);
            int dniInt = int.Parse(dni);
            int stateInt = int.Parse(state);
            int typeInt = int.Parse(type);
            int priorityInt = int.Parse(priority);
            int phoneInt = int.Parse(phone);
            return clientData.InsertClient(personTypeInt, name, rucInt, dniInt, priorityInt, typeInt, stateInt, address, phoneInt, contact, email);
        }
        public DataTable GetClients()
        {
            return clientData.GetClients();
        }
        public DataTable GetClients(int id)
        {
            return clientData.GetClients(id);
        }
        public DataTable GetClients(int id = -1, int ruc = -1, int dni = -1, string name = "", int state = -1, int priority = -1)
        {
            return clientData.GetClients(id, ruc, dni, name, state, priority);
        }
        public int UpdateClient(string id, string personType, string name, string ruc, string dni, string priority, string type, string state, string address, string phone, string contact, string email)
        {
            int personTypeInt = int.Parse(personType);
            int rucInt = int.Parse(ruc);
            int dniInt = int.Parse(dni);
            int stateInt = int.Parse(state);
            int typeInt = int.Parse(type);
            int priorityInt = int.Parse(priority);
            int phoneInt = int.Parse(phone);
            return clientData.UpdateClient(id,personTypeInt, name, rucInt, dniInt, priorityInt, typeInt, stateInt, address, phoneInt, contact, email);
        }
    }
}
