using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Data.Algorithm;

namespace InkaArt.Business.Algorithm
{
    public class GraspProduct
    {
        private Recipe current_recipe;
        private List<AssignmentTuple> temporal_assignments;

        public Recipe CurrentRecipe
        {
            get { return current_recipe; }
        }
        public int NumberOfJobs
        {
            get { return temporal_assignments.Count; }
        }
        public AssignmentLine this[int index]
        {
            get { return temporal_assignments[index].AssignmentLine; }
        }

        public GraspProduct(Recipe current_recipe, JobController jobs)
        {
            this.current_recipe = current_recipe;
            this.temporal_assignments = new List<AssignmentTuple>();

            List<Job> product_jobs = jobs.GetJobsByProduct(current_recipe.Product);
            product_jobs.OrderBy(job => job.Order);
            for (int i = 0; i < product_jobs.Count; i++)
                temporal_assignments.Add(new AssignmentTuple(product_jobs[i], null));
        }

        public bool IsFull()
        {
            for (int i = 0; i < temporal_assignments.Count; i++)
                if (temporal_assignments[i].AssignmentLine == null) return false;
            return true;
        }

        public bool SetAssignmentLine(AssignmentLine assignment_line, Job job)
        {
            for (int i = 0; i < temporal_assignments.Count; i++)
            {
                if (temporal_assignments[i].Job.ID != job.ID) continue;
                temporal_assignments[i].AssignmentLine = assignment_line;
                return true;
            }
            return false;
        }
        
        public bool ContainsJob(Job job)
        {
            for (int i = 0; i < temporal_assignments.Count; i++)
                if (temporal_assignments[i].Job.ID == job.ID) return true;
            return false;
        }

        public int NextMiniturn(Worker worker, int current_next_miniturn)
        {
            for (int i = 0; i < temporal_assignments.Count; i++)
            {
                AssignmentLine assignment_line = temporal_assignments[i].AssignmentLine;
                if (assignment_line == null || assignment_line.Worker == null) continue;

                int line_next_miniturn = assignment_line.MiniturnStart + assignment_line.TotalMiniturnsUsed;
                if (assignment_line.Worker.ID == worker.ID && line_next_miniturn > current_next_miniturn) current_next_miniturn = line_next_miniturn;
            }
            return current_next_miniturn;
        }

        public int GetLowestQuantity(int quantity_needed)
        {
            for (int i = 0; i < temporal_assignments.Count; i++)
            {
                AssignmentLine assignment_line = temporal_assignments[i].AssignmentLine;
                if (assignment_line == null) throw new Exception("Se supone que tenemos completado el producto pero hay casilleros vacios...");
                if (assignment_line.Produced < quantity_needed) quantity_needed = assignment_line.Produced;
            }
            return quantity_needed;
        }
    }
}
