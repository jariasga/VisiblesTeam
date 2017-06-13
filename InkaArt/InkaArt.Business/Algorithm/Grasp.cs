using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Business.Algorithm
{
    class Grasp
    {
        private WorkerController workers;
        private OrderController orders;
        private JobController jobs;
        private RecipeController recipes;
        private IndexController indexes;

        public Grasp()
        {
            this.workers = new WorkerController();
            this.workers.Load();
            this.orders = new OrderController();
            this.orders.Load();

            this.jobs = new JobController();
            this.jobs.Load();
            this.recipes = new RecipeController();
            this.recipes.Load();
            this.indexes = new IndexController();
            this.indexes.Load();
            this.indexes.CalculateIndexes(jobs, recipes);
        }

        public void GraspAlgorithm()
        {

        }
    }
}
