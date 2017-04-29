using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class GraspOutput
    {
        private List<Assignment> list_of_assignments;
        private double objective_function_value;

        public GraspOutput(List<Assignment> list_of_assignments, double objective_function_value)
        {
            this.list_of_assignments = list_of_assignments;
            this.objective_function_value = objective_function_value;
        }

        public static int[] ToArray(GraspOutput assignment, int workers)
        {
            int[] solution = new int[workers];
            for (int i = 0; i < workers; i++)
            {
                solution[i] = Assignment.GetProcessProductByWorker
                    (assignment.list_of_assignments, i + 1);
            }
            return solution;
        }
    }
}
