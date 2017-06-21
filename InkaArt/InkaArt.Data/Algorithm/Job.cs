using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Classes;

namespace InkaArt.Data.Algorithm
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony

    public class Job
    {
        //Job (Puesto de trabajo) = Proceso x Producto

        private int id_job;
        private string name;
        private int id_process;
        private int id_product;
        private int order;

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
            get { return id_product; }
        }
        public int Order
        {
            get { return order; }
        }

        public Job(int id_job, string name, int id_process, int id_product, int order)
        {
            this.id_job = id_job;
            this.name = name;
            this.id_process = id_process;
            this.id_product = id_product;
            this.order = order;
        }

    }
}
