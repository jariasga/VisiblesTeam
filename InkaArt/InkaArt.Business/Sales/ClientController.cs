using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InkaArt.Data.Sales;
using Npgsql;
using System.Data;

namespace InkaArt.Business.Sales
{
    public class ClientController
    {
        public string AddClient(int personType, string name, int ruc, int dni, int priority, int type, int state, string address, int phone, string contact, string email)
        {
            ClientData clientData = new ClientData();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter();
            DataSet data = new DataSet();

            clientData.connect();
            adap.InsertCommand.Parameters[0].NpgsqlValue = personType;
            adap.InsertCommand.Parameters[1].NpgsqlValue = name;
            adap.InsertCommand.Parameters[2].NpgsqlValue = ruc;
            adap.InsertCommand.Parameters[3].NpgsqlValue = dni;
            adap.InsertCommand.Parameters[4].NpgsqlValue = priority;
            adap.InsertCommand.Parameters[5].NpgsqlValue = type;
            adap.InsertCommand.Parameters[6].NpgsqlValue = state;
            adap.InsertCommand.Parameters[7].NpgsqlValue = address;
            adap.InsertCommand.Parameters[8].NpgsqlValue = phone;
            adap.InsertCommand.Parameters[9].NpgsqlValue = contact;
            adap.InsertCommand.Parameters[10].NpgsqlValue = email;


            data = clientData.getData(adap);
            return "asd";
        }
    }
}
