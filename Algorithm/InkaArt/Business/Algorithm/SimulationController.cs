using InkaArt.Data.Algorithm;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    class SimulationController
    {
        private List<Simulation> simulations;

        public SimulationController()
        {
            simulations = new List<Simulation>();
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

    }
}
