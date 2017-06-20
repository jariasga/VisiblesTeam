using InkaArt.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    //ESTA CLASE SE USA SOLO PARA LA ASIGNACIÓN DE TRABAJADORES Y PARA EL REGISTRO DE INFORMES DE TURNO
    //- Anthony
    public class Worker
    {
        private int id_worker;
        private string name;
        private string last_name;
        private Turn turn;

        public int ID
        {
            get { return id_worker; }
        }
        public string Name
        {
            get { return name; }
        }
        public string LastName
        {
            get { return last_name; }
        }
        public Turn Turn
        {
            get { return turn; }
        }

        public Worker(int id_worker, string name, string last_name, Turn turn)
        {
            this.id_worker = id_worker;
            this.name = name;
            this.last_name = last_name;
            this.turn = turn;
        }

        public string FullName
        {
            get { return name + " " + last_name; }
        }
    }
}
