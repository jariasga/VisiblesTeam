using InkaArt.Classes;
using InkaArt.Data.Algorithm;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkaArt.Business.Algorithm
{
    public class SimulationController
    {
        private BindingList<Simulation> simulations;

        public SimulationController()
        {
            simulations = new BindingList<Simulation>();
        }        
        
        public Simulation this[int index]
        {
            get { return simulations[index]; }
        }

        public int Count()
        {
            return simulations.Count;
        }

        public void Add(Simulation simulation)
        {
            simulations.Add(simulation);
        }
        
        public void Delete(Simulation simulation)
        {
            simulations.Remove(simulation);
        }

        public void Load()
        {
            //OBTENER DATOS DE BASE DE DATOS
            NpgsqlConnection connection = new NpgsqlConnection(BD_Connector.ConnectionString.ConnectionString);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand("", connection);

            connection.Close();
        }

        public string Insert(string name, DateTime date_start, DateTime date_end, decimal breakage_weight, decimal time_weight,
            decimal huaco_weight, decimal huamanga_weight, decimal altarpiece_weight, WorkerController selected_workers,
            OrderController selected_orders)
        {
            string message = "OK";
            Simulation simulation = null;

            try
            {
                simulation = this.Validate(name, date_start, date_end, breakage_weight, time_weight, huaco_weight,
                    huamanga_weight, altarpiece_weight, selected_workers, selected_orders);
                simulations.Add(simulation);
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return message;
        }

        private Simulation Validate(string name, DateTime date_start, DateTime date_end, decimal breakage, decimal time,
            decimal huaco, decimal huamanga, decimal altarpiece, WorkerController selected_workers,
            OrderController selected_orders)
        {
            //Comprobar los campos obligatorios
            if (name == null || name == "")
                throw new Exception("Por favor, ingrese un nombre válido.");
            if (selected_workers == null || selected_workers.Count() <= 0)
                throw new Exception("Por favor, considere como mínimo un empleado.");
            if (selected_orders == null || selected_orders.Count() <= 0)
                throw new Exception("Por favor, considere como mínimo un pedido.");

            //Fechas de inicio y final
            date_start = date_start.Date;
            date_end = date_end.Date;
            if (date_start > date_end)
                throw new Exception("La fecha de inicio debe ser menor o igual a la fecha final.");
            int days;
            try
            {
                days = Convert.ToInt32(Math.Ceiling((date_end - date_start).TotalDays)) + 1;
            }
            catch (Exception)
            {
                throw new Exception("No se pudo obtener el número de días a partir de las fechas de inicio y fin. "
                    + "Por favor, revise que haya ingresado las fechas correctamente.");
            }
            if (days <= 0) throw new Exception("La fecha de inicio debe ser menor o igual a la fecha final.");

            //Campos numéricos
            if (breakage < 0 || breakage > 100) throw new Exception("El peso de rotura debe estar entre 0% y 100%.");
            double breakage_weight = Convert.ToDouble(breakage) / 100;

            if (time < 0 || time > 100) throw new Exception("El peso del tiempo debe estar entre 0% y 100%.");
            double time_weight = Convert.ToDouble(time) / 100;

            if (huaco < 0 || huaco > 100)
                throw new Exception("El peso para los huacos precolombinos debe estar entre 0% y 100%.");
            double huaco_weight = Convert.ToDouble(huaco) / 100;

            if (huamanga < 0 || huamanga > 100)
                throw new Exception("El peso para las piedras de Huamanga debe estar entre 0% y 100%.");
            double huamanga_weight = Convert.ToDouble(huamanga) / 100;

            if (altarpiece < 0 || altarpiece > 100)
                throw new Exception("El peso para los retablos debe estar entre 0% y 100%.");
            double altarpiece_weight = Convert.ToDouble(altarpiece) / 100;
            
            return new Simulation(name, date_start.Date, date_end.Date, days, breakage_weight, time_weight, huaco_weight,
                    huamanga_weight, altarpiece_weight, selected_workers, selected_orders);
        }

        //public List<Simulation> List()
        //{
        //    return simulations;
        //}

        public BindingList<Simulation> BindingList()
        {
            return new BindingList<Simulation>(simulations);
        }

    }
}
