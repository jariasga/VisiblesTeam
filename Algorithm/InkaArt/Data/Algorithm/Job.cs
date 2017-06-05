using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Production
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony
    class Job
    {
        private int id_job;
        private string name;
        private int id_process;
        private int idProduct;

        public int ID
        {
            get { return id_job; }
        }
        public string Name
        {
            get { return name; }
        }
        public int Process
        {
            get { return id_process; }
        }
        public int Product
        {
            get { return idProduct; }
        }

        public Job(int id_job, string name, int id_process, int idProduct)
        {
            this.id_job = id_job;
            this.name = name;
            this.id_process = id_process;
            this.idProduct = idProduct;
        }

    }
}
