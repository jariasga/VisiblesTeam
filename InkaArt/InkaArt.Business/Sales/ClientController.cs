using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Sales;
using System.Data;
using System.IO;

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
            long dniInt = long.Parse(dni);
            int stateInt = int.Parse(state);
            int typeInt = int.Parse(type);
            int priorityInt = int.Parse(priority);
            long phoneInt = long.Parse(phone);
            return clientData.InsertClient(personTypeInt, name, rucInt, dniInt, priorityInt, typeInt, stateInt, address, phoneInt, contact, email);
        }

        public DataTable GetClients(string id = "", string ruc = "", string dni = "", string name = "", int state = -1, int priority = -1)
        {
            int intId = -1, intAux; long intRuc = -1, intDni = -1, longAux;
            if (!id.Equals("")) if (int.TryParse(id, out intAux)) intId = int.Parse(id);
            if (!ruc.Equals("")) if (long.TryParse(ruc, out longAux)) intRuc = long.Parse(ruc);
            if (!dni.Equals("")) if (long.TryParse(dni, out longAux)) intDni = long.Parse(dni);
            if (priority != -1) priority++;
            return clientData.GetClients(intId, intRuc, intDni, name, state, priority);
        }

        public int UpdateClient(string id, string personType, string name, string ruc, string dni, string priority, string type, string state, string address, string phone, string contact, string email)
        {
            int personTypeInt = int.Parse(personType);
            long rucInt = long.Parse(ruc);
            long dniInt = long.Parse(dni);
            int stateInt = int.Parse(state);
            int typeInt = int.Parse(type);
            int priorityInt = int.Parse(priority);
            long phoneInt = long.Parse(phone);
            return clientData.UpdateClient(id, personTypeInt, name, rucInt, dniInt, priorityInt, typeInt, stateInt, address, phoneInt, contact, email);
        }

        public string makeValidations(string personType, string name, string ruc, string dni, string priority, string type, string state, string address, string phone, string contact, string email)
        {
            int aux; long laux;
            if (personType.Equals("") || name.Equals("") || ruc.Equals("") || dni.Equals("") || priority.Equals("") || type.Equals("") || state.Equals("") || address.Equals("") || phone.Equals("") || contact.Equals("") || email.Equals(""))
                return "Por favor, complete todos los campos antes de continuar";
            if (personType.Equals("0"))
            {
                if (!(long.TryParse(dni, out laux) && ruc.Length == 11))
                {
                    return "Ingrese un RUC válido";
                }
            }
            else if (personType.Equals("1"))
            {
                if (!(int.TryParse(dni, out aux) && dni.Length == 8))
                    return "Ingrese un DNI válido";
            }
            else
            {
                return "Seleccione un tipo de persona";
            }
            if (!int.TryParse(priority, out aux))
                return "La prioridad debe ser un número";
            if (long.TryParse(phone, out laux))
            {
                if (type.Equals("0"))
                {
                    if (phone.Length != 9)
                        return "Ingrese un número de celular válido";
                }
                else
                {
                    if (phone.Length != 11)
                        return "Ingrese un número de celular válido";
                }
            }else return "Ingrese un número de celular válido";
            if (!(email.Contains("@") && email.Contains(".") && email.Length > 5))
                return "Ingrese un correo electrónico válido";
            if (type.Equals("-1"))
                return "Seleccione un tipo de cliente";
            if (state.Equals("-1"))
                return "Seleccione un estado";
            return "OK";
        }

        public string massiveUpload(string fileName, bool validate = false)
        {
            int index = 1;
            using (var fs = File.OpenRead(fileName))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    string response = makeValidations(values[0].ToString(), values[2].ToString(), values[1].ToString(), values[1].ToString(), values[4].ToString(), values[3].ToString(), values[5].ToString(), values[6].ToString(), values[7].ToString(), values[8].ToString(), values[9].ToString());
                    if (response.Equals("OK"))
                    {
                        if (!validate) clientData.InsertClient(int.Parse(values[0].ToString()), values[2].ToString(), long.Parse(values[1].ToString()), long.Parse(values[1].ToString()), int.Parse(values[4].ToString()), int.Parse(values[3].ToString()), int.Parse(values[5].ToString()), values[6].ToString(), long.Parse(values[7].ToString()), values[8].ToString(), values[9].ToString());                        
                    }else
                    {
                        return "Error línea " + index.ToString() + ": " + response;
                    }
                    index++;
                }
                return "OK";
            }
        }

        public void deleteClients(List<string> selectedClients)
        {
            clientData.deleteClients(selectedClients);
        }

        public bool validateTrackBar(string value)
        {
            int aux;
            if (int.TryParse(value, out aux))
                return true;
            else return false;
        }
    }
}
