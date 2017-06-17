using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class Turn
    {
        private int id_turn;
        private TimeSpan start_time;
        private TimeSpan end_time;
        private string description;

        public int TotalMinutes
        {
            get { return Convert.ToInt32((end_time - start_time).TotalMinutes); }
        }

        public Turn(int id_turn, TimeSpan start_time, TimeSpan end_time, string description)
        {
            this.id_turn = id_turn;
            this.start_time = start_time;
            this.end_time = end_time;
            this.description = description;
        }
    }
}
