using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Client
    {
        private int id_client;
        //private int client_type;
        private string name;
        private long ruc;
        private long dni;
        private int priority;

        //private int type;   
        //private int status; // eliminado o no

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public long Ruc
        {
            get
            {
                return ruc;
            }

            set
            {
                ruc = value;
            }
        }

        public long Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }

        public long Document
        {
            get
            {
                if (dni>0)
                    return dni;
                return ruc;
            }

            //set
            //{
            //    dni = value;
            //}
        }

        public int Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }

        public Client(int id, string name, long ruc, long dni, int priority) 
        {
            this.id_client = id;
            this.name = name;
            this.ruc = ruc;
            this.dni = dni;
            this.priority = priority;
        }
    }
}
