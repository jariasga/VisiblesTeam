using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Production
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony
    class Worker
    {
        private int idWorker;
        private string name;
        private string last_name;

        public int ID
        {
            get { return idWorker; }
        }
        public string Name
        {
            get { return name; }
        }
        public string LastName
        {
            get { return last_name; }
        }

        public Worker(int idWorker, string name, string last_name)
        {
            this.idWorker = idWorker;
            this.name = name;
            this.last_name = last_name;
        }

        public string FullName()
        {
            return name + " " + last_name;
        }
    }
}
