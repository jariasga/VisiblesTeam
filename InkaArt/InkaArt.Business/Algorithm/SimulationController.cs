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

        public string Insert(Simulation simulation, string name, string days, string breakage, string time, string huaco, string huamanga, string retable, List<Worker> workers)
        {
            string message = Simulation.Validate(name, days, breakage, time, huaco, huamanga, retable, workers);

            if (message.Equals("OK"))
            {
                simulation = new Simulation(name, days, breakage, time, huaco, huamanga, retable, workers);
                this.simulations.Add(simulation);                
            }

            return message;
        }

        public string Update(Simulation simulation, string name, string days, string breakage, string time, string huaco, string huamanga, string retable, List<Worker> workers)
        {
            string message = Simulation.Validate(name, days, breakage, time, huaco, huamanga, retable, workers);

            if (message.Equals("OK"))
                simulation.Update(name, days, breakage, time, huaco, huamanga, retable, workers);

            return message;
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
