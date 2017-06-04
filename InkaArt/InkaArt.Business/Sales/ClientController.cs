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
            long rucInt = long.Parse(ruc);
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
        
        public string makeValidations(string personType, string name, string ruc, string dni, string priority, string type, string state, string address, string phone, string contact, string email)
        {
            int aux;
            if (personType.Equals("") || name.Equals("") || ruc.Equals("") ||  dni.Equals("") || priority.Equals("") || type.Equals("") || state.Equals("") || address.Equals("") || phone.Equals("") ||  contact.Equals("") ||  email.Equals(""))            
                return "Por favor, complete todos los campos antes de continuar";            
            if (personType.Equals("0"))
            {
                switch (notValid(ruc))
                {
                    case 0:
                        return "Ingrese un RUC válido";
                    case 1:
                        return "El RUC debe ser numérico";
                    case 2:
                        return "El RUC debe ser de 10 cifras";
                }
            }else if (personType.Equals("1"))
            {
                if (!int.TryParse(dni, out aux))
                    return "El DNI debe ser numérico";
            }else
            {
                return "Seleccione un tipo de persona";
            }
            if (!int.TryParse(priority, out aux))
                return "La prioridad debe ser un número";
            if (!int.TryParse(phone, out aux))
                return "Ingrese un número de celular válido";
            if (!(email.Contains("@") && email.Contains(".")))
                return "Ingrese un correo electrónico válido";
            if (type.Equals("-1"))
                return "Seleccione un tipo de cliente";
            if (state.Equals("-1"))
                return "Seleccione un estado";
            return "OK";
        }
        public bool validateTrackBar(string value)
        {
            int aux;
            if (int.TryParse(value, out aux))
                return true;
            else return false;
        }
        private int notValid(string ruc)
        {
            long aux;
            char[] digits;
            int[] factors = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            if (Int64.TryParse(ruc, out aux))
            {
                if (ruc.Length != 11) return 2;
                digits = ruc.ToCharArray();
                int sum = 0, result;
                for(int i = 0; i < digits.Length - 1; i++)
                {
                    sum += factors[i]* (digits[i] - '0');
                }
                result = 11 - (sum % 11);
                switch (result)
                {
                    case 10:
                        result = 0;
                        break;
                    case 11:
                        result = 1;
                        break;
                }
                if (result > 11)
                {
                    string auxRes = result.ToString();
                    result = int.Parse(auxRes.Substring(auxRes.Length - 1, 1));
                }
                if (result == (digits[10] - '0'))
                {
                    return -1;
                }else
                {
                    return 0;
                }
            }else
            {
                return 1;
            }
        }
    }
}
