using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Process
    {
        private int id_process;
        private string description;
        private int position_count;

        public int ID
        {
            get { return id_process; }
        }
        public string Description
        {
            get { return description; }
        }
        public int PositionCount
        {
            get { return position_count; }
        }

        public Process(int id_process, string description, int position_count)
        {
            this.id_process = id_process;
            this.description = description;
            this.position_count = position_count;
        }
    }
}
