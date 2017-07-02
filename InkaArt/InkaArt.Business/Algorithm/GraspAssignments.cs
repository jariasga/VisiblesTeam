using InkaArt.Data.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    public class GraspAssignments
    {
        private Assignment[] assignments;
        private List<Order>[] orders;
        private int count;
        private int best_index;

        public GraspAssignments()
        {
            this.assignments = new Assignment[Grasp.NumberOfIterations];
            this.orders = new List<Order>[Grasp.NumberOfIterations];
            this.count = 0;
            this.best_index = -1;
        }

        public int AddAssignment(Assignment assignment, List<Order> orders)
        {
            this.assignments[count] = assignment;
            this.orders[count] = orders;
            //Si la nueva asignación es mejor que la mejor de la lista de asignaciones, actualizar el índice de la mejor asignación
            if (best_index < 0 || assignment.ObjectiveFunction < this.assignments[best_index].ObjectiveFunction) best_index = count;
            this.count++;
            return best_index;
        }

        public Assignment GetBestAssignment(ref List<Order> orders)
        {
            if (best_index < 0) return null;
            orders = this.orders[best_index];
            return assignments[best_index];
        }
    }
}
