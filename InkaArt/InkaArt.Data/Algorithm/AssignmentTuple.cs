using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Data.Algorithm
{
    public class AssignmentTuple
    {
        private Job job;
        private AssignmentLine assignment_line;

        public Job Job
        {
            get { return job; }
        }
        public AssignmentLine AssignmentLine
        {
            get { return assignment_line; }
            set { assignment_line = value; }
        }

        public AssignmentTuple(Job job, AssignmentLine assignment_line)
        {
            this.job = job;
            this.assignment_line = assignment_line;
        }
    }
}
