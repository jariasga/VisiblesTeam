using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InkaArt.Data.Algorithm;
using InkaArt.Classes;

namespace InkaArt.Business.Algorithm
{
    public class GraspProduct
    {
        private Recipe current_recipe;
        private List<AssignmentTuple> temporal_assignments;
        private double objective_function_addition;

        public Recipe CurrentRecipe
        {
            get { return current_recipe; }
        }
        public int NumberOfTuples
        {
            get { return temporal_assignments.Count; }
        }
        public AssignmentLine this[int index]
        {
            get { return temporal_assignments[index].AssignmentLine; }
        }
        public double ObjectiveFunction
        {
            get { return objective_function_addition; }
        }
        
        /// <summary>
        /// Crea una nueva receta de producto con diferentes trabajadores asignados para cada proceso involucrado en dicho producto.
        /// </summary>
        public GraspProduct(Recipe current_recipe, JobController jobs)
        {
            this.current_recipe = current_recipe;
            this.temporal_assignments = new List<AssignmentTuple>();
            this.objective_function_addition = 0;

            List<Job> product_jobs = jobs.GetJobsByProduct(current_recipe.Product).OrderBy(job => job.Order).ToList();
            for (int i = 0; i < product_jobs.Count; i++)
                temporal_assignments.Add(new AssignmentTuple(product_jobs[i], null));
        }

        public int NumberOfFullTuples()
        {
            int count = 0;
            for (int i = 0; i < temporal_assignments.Count; i++)
                if (temporal_assignments[i].AssignmentLine != null) count++;
            return count;
        }

        public bool IsFullyAssigned()
        {
            for (int i = 0; i < temporal_assignments.Count; i++)
                if (temporal_assignments[i].AssignmentLine == null) return false;
            return true;
        }

        /// <summary>
        /// Agrega una línea de asignacion a la estructura del producto actual.
        /// </summary>
        public bool SetAssignmentLine(AssignmentLine assignment_line, double cost_value)
        {
            for (int i = 0; i < temporal_assignments.Count; i++)
            {
                if (temporal_assignments[i].Job.ID != assignment_line.Job.ID) continue;
                //Agregar la línea de asignación a la lista de tuplas, y actualizar la adición a la F.O.
                this.temporal_assignments[i].AssignmentLine = assignment_line;
                this.objective_function_addition += cost_value;
                return true;
            }
            //Devolver "falso" cuando no se ha encontrado el puesto de trabajo de la asignación.
            return false;
        }
        
        public bool IsCandidateForRCL(Index index)
        {
            //El índice debe ser de la receta que se está elaborando actualmente y debe haber coherencia entre receta y puesto de trabajo
            if (index.Recipe.ID != this.current_recipe.ID || index.Recipe.Product != index.Job.Product) return false;

            //Además, el puesto de trabajo debe estar vacío para usar
            for (int i = 0; i < temporal_assignments.Count; i++)
                if (temporal_assignments[i].Job.ID == index.Job.ID && temporal_assignments[i].AssignmentLine == null) return true;
            return false;
        }

        public int GetLowestQuantity(int quantity_needed, int total_miniturns)
        {
            //Determinar primero el inicio ordenado de cada línea
            for (int i = 1; i < temporal_assignments.Count; i++)
            {
                AssignmentLine current_line = temporal_assignments[i].AssignmentLine;
                int temp_start = temporal_assignments[i - 1].AssignmentLine.MiniturnStart;
                temp_start += AssignmentLine.ProducedToMiniturns(1, current_line.AverageTime, Simulation.MiniturnLength);
                if (temp_start > current_line.MiniturnStart)
                {
                    current_line.MiniturnStart = temp_start;
                    current_line.MiniturnsUsed = total_miniturns - temp_start;
                    current_line.Produced = AssignmentLine.MiniturnsToProduced(current_line.MiniturnsUsed, current_line.AverageTime,
                        Simulation.MiniturnLength);
                }
                if (current_line.Produced < quantity_needed) quantity_needed = current_line.Produced;
            }
            //Actualizar la cantidad de miniturnos y la cantidad producida
            for (int i = 0; i < temporal_assignments.Count; i++)
            {
                AssignmentLine current_line = temporal_assignments[i].AssignmentLine;
                current_line.Produced = quantity_needed;
                current_line.MiniturnsUsed = AssignmentLine.ProducedToMiniturns(quantity_needed, current_line.AverageTime, Simulation.MiniturnLength);
                //Ver si nos pasamos de los miniturnos :(
                if (current_line.MiniturnStart + current_line.MiniturnsUsed > total_miniturns)
                    throw new Exception("Nos pasamos de la cantidad de miniturnos :(");
            }
            return quantity_needed;
        }
    }
}
