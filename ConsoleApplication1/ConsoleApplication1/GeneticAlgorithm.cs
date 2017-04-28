using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApplication1
{
    
    class GeneticAlgorithm
    {
        public List<List<int>> FirstGen;
        Instance actualIns; 


        public GeneticAlgorithm(Instance inst) {
            FirstGen = new List<List<int>>();
            actualIns = inst;
        }
        public void CreateFirstGen() //Cargar la primera generacion
        { 

            using (var fs = File.OpenRead("vi.csv"))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    List<int> member = new List<int>(); //Individuo de la generacion
                    var line = reader.ReadLine();
                    Console.WriteLine(line);
                    var values = line.Split(',');
                    for (int i = 0; i < values.Count(); i++) {
                        member.Add(int.Parse(values[i]));
                    }
                 FirstGen.Add(member);
                }
            }
        }

        public void ParentsSelection(int parent1, int parent2, int cantidad) {
            Random rnd = new Random();
            parent1 = rnd.Next(0, cantidad);
            parent2 = rnd.Next(0, cantidad);
            while (parent1 == parent2)
                parent2 = rnd.Next(0, cantidad);
        }

        //DONE
        public void saveBestInGen(List<List<int>> Generation, List<int> bestInGen, int pos)
        {
            //primero limpiar bestingen y luego agregar
            while (bestInGen.Count()>0)
            {
                bestInGen.RemoveAt(0);
            }

            for (int i = 0; i < Generation[pos].Count(); i++)
            {
                bestInGen.Add(Generation[pos][i]);
            }

        }

        //REVISAR pesos creo que es menor en ve de mayor

        public double evaluateFitness(List<List<int>> NewGeneration, int bestPos)
        {
            double value = 1000;
            for (int i = 0; i < NewGeneration.Count(); i++)
            {
                int auxFit;
                auxFit = evaluateFitnessInChild(NewGeneration[i]);
                if (auxFit < value)
                {
                    value = auxFit;
                    bestPos = i;
                }
            }
            return value;
        }

        public void newGenToFirstGen(List<List<int>> FirstGen, List<List<int>> NewGeneration)
        {
            //limpiar first generation
            while (FirstGen.Count() > 0)
                FirstGen.RemoveAt(0);

            while (NewGeneration.Count() > 0)
            {
                FirstGen.Add(NewGeneration[0]);
                NewGeneration.RemoveAt(0);
            }
            
        }

        public void RunGenetic() //Inicio del programa Genetico
        {
            //DONE
            /*List<int> numWorkersInJob;     //numer de trabajadores necesitados por puesto
            numWorkersInJob = new List<int>();*/
            
            //0 carving 1 painting 2 kaking 3 molding

            int numWorkersPerMember = 50; //numero de trabajadores en una solucion (individuo)
            List<List<int>>  NewGeneration; //mejor solucion hasta ahora (deberia ser por generacion)
            List<int> bestSolution = new List<int>(); ;
            int bestSolutionCount = 0;  //contador de cuantas generacion la mejor solucion se ha mantenido sin cambiar
            List<int> generalJobs = new List<int>();
            generalJobs.Add(0); //carving
            generalJobs.Add(1); //molding
            generalJobs.Add(2); //painting
            generalJobs.Add(3); //baking

            List<int> assignedWorkersAux = new List<int>(); //lista auxiliar de trabajadores asignados a un puesto
            List<int> nonAssignWorkersAux = new List<int>(); //lista auxiliar de trabajadores no asignados

            int parent1 = 0, parent2 = 0;       //indices de los padres seleccionados

            Random rnd = new Random();

            NewGeneration = new List<List<int>>();

            double fitnessValue;
            int bestPos=0;

            //REVISAR ELIMINACION DE MEMORIA INUTIL
            //1. DONE contar los puestos en general (tallar, moldear, pintar, hornear) se podria usar instance 
            //cambiar por numWorkersInJob

            //WHILE TO DO poner tiempo en el while
            while (true)
            {
                //2. hallar fitness de la solucion
                fitnessValue = evaluateFitness(NewGeneration,bestPos);//bestPos-> el mejor de la solucion
                //2.1 REVISAR si bestSolution se ha mantenido mucho tiempo ->salir (bestSolutionCount)
                //2.2 DONE nueva generacion pasa a ser firstgen y se actualiza la mejor solucion con la mejor de la gen
                //2.3 DONE limpiar newgeneracion (vacia)
                newGenToFirstGen(FirstGen, NewGeneration); //tambien vacia la lista newGeneration
                saveBestInGen(FirstGen,bestSolution,bestPos);

                //WHILE REVISAR condicion del while
                //3.1 DONE si el numero de elementos en la generacion es 200 (ya esta llena la generacion) -> salir
                while (NewGeneration.Count() < actualIns.workers.Count())
                {
                    //3.2 DONE crear individuo contrabajadores sin asignar
                    List<int> child = new List<int>();
                    for (int i = 0; i < numWorkersPerMember; i++)
                        child.Add(0);
                    //3.3 DONE Ruleta para seleccion de padres
                    ParentsSelection(parent1, parent2,FirstGen.Count());

                    //WHILE DONE
                    while (generalJobs.Count() != 0)
                    {

                        //4. DONE elegir un puesto (podria ir aca la seleccion por prioridad de productos)
                        int puestoActual = generalJobs[0];
                        generalJobs.RemoveAt(0);
                        //4.1 DONE agregar a la lista correspondiente los trabajadores
                        addWorkersToCertainJob(parent1, parent2, puestoActual, assignedWorkersAux, nonAssignWorkersAux);
                        //4.1.1 DONE comparar con child para editar los ya asignados
                        checkWithChild(assignedWorkersAux, child);
                        //4.2 DONE random de 1 a 100 si sale 1 elegir al azar
                        //4.2.1 DONE si no, sacar a los  n mejores (ya estan revisados los que posiblemente ya estan asignados en child)
                        //para ocuparlos (podria ser ruleta)
                        //4.3 DONE actualizar a child con los nuevos puestos
                        //4.4 DONE agregar a los que quedaron en generaljobs a los no asignados (general job quedaria vacio para la nueva corrida)
                        chooseAndAddWorkersInChild(assignedWorkersAux, nonAssignWorkersAux, child, actualIns.processes_positions[puestoActual], puestoActual);
                    }
                    //4.5 DONE evaluar fitness del hijo (child) si no es mejor, no se agrega a la generacion
                    //limpiar child
                    int result = evaluateFitnessInChild(child);
                    if (result == 0)
                        NewGeneration.Add(child);
                    else
                        child = null; //"clear memory" garbage collection
                }

            }//siguiente juail
        }

        //TO DO
        public int evaluateFitnessInChild(List<int> child)
        {
            int value = 1;


            return value;
        }


        public void chooseAndAddWorkersInChild(List<int> assignedWorkersAux, List<int> nonAssignWorkersAux, List<int> child, int numWorkers, int job)
        {
            int mutation;
            List<double> bestRatioPerWorker;
            List<int> bestJobPerWorker;
            bestRatioPerWorker = new List<double>();
            bestJobPerWorker = new List<int>();
            //REVISAR que existen suficientes en assignedWorkersAux

            Random rnd = new Random();

            //MUTACION
            mutation = rnd.Next(0, 101);
            int workerIndex;
            if (mutation == 1)// Ocurre la mutacion, random
            {
                for (int i = 0; i < numWorkers; i++)
                {
                    workerIndex = rnd.Next(0, assignedWorkersAux.Count());
                    //random producto del proceso
                    int process = giveMeRandomProcess(job);
                    child[assignedWorkersAux[workerIndex]] = process;
                    assignedWorkersAux.RemoveAt(workerIndex);

                }
            }
            else //no existe mutacion
            {
                //DONE llena los arreglos
                fillBest(assignedWorkersAux, job, bestRatioPerWorker, bestJobPerWorker);
                //halla a los n mejores
                for (int i = 0; i < numWorkers; i++)
                {
                    int index = findBest(bestRatioPerWorker);
                    //actualizar child
                    child[assignedWorkersAux[index]] = bestJobPerWorker[index];
                    assignedWorkersAux.RemoveAt(index);
                    bestJobPerWorker.RemoveAt(index);
                    bestRatioPerWorker.RemoveAt(index);
                }
                //agregar a los que sobran a nonassignjob
                while (assignedWorkersAux.Count() > 0)
                {
                    nonAssignWorkersAux.Add(assignedWorkersAux[0]);
                    assignedWorkersAux.RemoveAt(0);

                }
            }
        }

        public void fillBest(List<int> assignedWorkers, int job, List<double> ratios, List<int> jobPerWork)
        {
            double best1=0, best2=0;
            int id1=0;
            int id2=-1;
            int bestId;
            double bestRatio;
            //busco en la clase workers y agrego el mejor ratio y puestoxtrabajo de cada uno de los posibles trabajadores para un puesto
            if (job == 0)//tallado 20 o 30
            {
                //PREGUNTAR los trabajadores siempre se mantienen en su misma posicion en el arreglo no?
                for (int i = 0; i < assignedWorkers.Count(); i++)
                {
                    //DONE con la posicion del worker voy a su posicion y saco los jobxproduct de ahi saco el mejor y pongo el valor y tipo
                    for (int j = 0; j < actualIns.ratios.Count(); i++) //busqueda para cada trabajador
                    {
                        if (job == 0)//tallado 20 o 30
                        {
                            if (int.Parse(actualIns.ratios[j].worker.id) == assignedWorkers[i])
                            {
                                if(actualIns.ratios[j].process_product_id == 20)
                                {
                                    id1 = 20;
                                    if(actualIns.breakage_weight>actualIns.time_weight)
                                    {
                                        best1 = actualIns.ratios[j].breakage;
                                    }
                                    else
                                    {
                                        best1 = actualIns.ratios[j].time;
                                    }
                                        
                                }
                                if (actualIns.ratios[j].process_product_id == 30)
                                {
                                    id1 = 30;
                                    if (actualIns.breakage_weight > actualIns.time_weight)
                                    {
                                        best2 = actualIns.ratios[j].breakage;
                                    }
                                    else
                                    {
                                        best2 = actualIns.ratios[j].time;
                                    }
                                }

                            }
                        }

                        if (job == 1)//moldeado 10
                        {
                            if (int.Parse(actualIns.ratios[j].worker.id) == assignedWorkers[i])
                            {
                                if (actualIns.ratios[j].process_product_id == 10)
                                {
                                    id1 = 10;
                                    if (actualIns.breakage_weight > actualIns.time_weight)
                                    {
                                        best1 = actualIns.ratios[j].breakage;
                                    }
                                    else
                                    {
                                        best1 = actualIns.ratios[j].time;
                                    }

                                }
   
                            }
                        }

                        if (job == 2)//pintado 11 o 31
                        {
                            if (int.Parse(actualIns.ratios[j].worker.id) == assignedWorkers[i])
                            {
                                if (actualIns.ratios[j].process_product_id == 11)
                                {
                                    id1 = 11;
                                    if (actualIns.breakage_weight > actualIns.time_weight)
                                    {
                                        best1 = actualIns.ratios[j].breakage;
                                    }
                                    else
                                    {
                                        best1 = actualIns.ratios[j].time;
                                    }

                                }
                                if (actualIns.ratios[j].process_product_id == 31)
                                {
                                    id1 = 31;
                                    if (actualIns.breakage_weight > actualIns.time_weight)
                                    {
                                        best2 = actualIns.ratios[j].breakage;
                                    }
                                    else
                                    {
                                        best2 = actualIns.ratios[j].time;
                                    }
                                }

                            }
                        }

                        if (job == 3)//horneado 12
                        {
                            if (int.Parse(actualIns.ratios[j].worker.id) == assignedWorkers[i])
                            {
                                if (actualIns.ratios[j].process_product_id == 12)
                                {
                                    id1 = 12;
                                    if (actualIns.breakage_weight > actualIns.time_weight)
                                    {
                                        best1 = actualIns.ratios[j].breakage;
                                    }
                                    else
                                    {
                                        best1 = actualIns.ratios[j].time;
                                    }

                                }

                            }
                        }



                        //Ver si es el mejor, si lo es, cambiar mejor de la solucion
                        if (best1 != 0 && best2 != 0)
                        {
                            if (best2 > best1)
                            {
                                best1 = best2;
                                id1 = id2;
                            }
                        }

                        ratios.Add(best1);
                        jobPerWork.Add(id1);

                    }
                }
            }
        }

        
        public int findBest(List<double> bestRatios)
        {
            int value = 0;
            double ratio = bestRatios[0];
            for (int i = 0; i < bestRatios.Count()-1; i++)
            {
                if (bestRatios[i + 1] > ratio)
                {
                    value = i + 1;
                    ratio = bestRatios[i + 1];
                }
            }
            return value;
        }

        public int giveMeRandomProcess(int job)
        {
            int returnValue=0;
            Random rnd = new Random();
            if (job == 0)
            {
                int value = rnd.Next(0, 2);
                if (value == 0)
                    returnValue = 20;
                if (value == 1)
                    returnValue = 30;
            }

            if (job == 1)
                returnValue = 10;
            if (job == 2)
            {
                int value = rnd.Next(0, 2);
                if (value == 0)
                    returnValue = 11;
                if (value == 1)
                    returnValue = 31;
            }

            if (job == 3)
                returnValue = 12;


            return returnValue;
            
        }


        public void checkWithChild(List<int> assignedWorkers, List<int> child)
        {
            int i = 0;
            while (i<assignedWorkers.Count())
            {
                if (child[assignedWorkers[i]] != 0)
                    assignedWorkers.RemoveAt(i);
                else
                {
                    i++;
                }
            }
        }


        public void addWorkersToCertainJob(int parent1, int parent2, int typejob, List<int>jobAux,List<int> nonJob) //jobaux lista con ids de numero de trabajador
        {
            int flagParent1=0; //0 no esta, 1 esta
            int flagParent2=0;
            if(typejob ==0)//tallado 20 0 30
            {
                for(int i = 0; i < FirstGen[parent1].Count(); i++)
                {
                    if (FirstGen[parent1][i] == 20 || FirstGen[parent1][i] == 30)
                    {
                        jobAux.Add(i);
                        flagParent1 = 1;
                    }
                    if (FirstGen[parent2][i] == 20 || FirstGen[parent2][i] == 30)
                    {
                        jobAux.Add(i);
                        flagParent2 = 1;
                    }
                    if(flagParent1==0 && flagParent2==0)
                    {
                        nonJob.Add(i);
                    }
                    flagParent1 = 0;
                    flagParent2 = 0;
                }
            }

            if (typejob == 1)//moldeado 10
            {
                for (int i = 0; i < FirstGen[parent1].Count(); i++)
                {
                    if (FirstGen[parent1][i] == 10)
                    {
                        jobAux.Add(i);
                        flagParent1 = 1;
                    }
                    if (FirstGen[parent2][i] == 10)
                    {
                        jobAux.Add(i);
                        flagParent2 = 1;
                    }
                    if (flagParent1 == 0 && flagParent2 == 0)
                    {
                        nonJob.Add(i);
                    }
                    flagParent1 = 0;
                    flagParent2 = 0;
                }
            }

            if (typejob == 0)//pintado 11 0 31
            {
                for (int i = 0; i < FirstGen[parent1].Count(); i++)
                {
                    if (FirstGen[parent1][i] == 11 || FirstGen[parent1][i] == 31)
                    {
                        jobAux.Add(i);
                        flagParent1 = 1;
                    }
                    if (FirstGen[parent2][i] == 11 || FirstGen[parent2][i] == 31)
                    {
                        jobAux.Add(i);
                        flagParent2 = 1;
                    }
                    if (flagParent1 == 0 && flagParent2 == 0)
                    {
                        nonJob.Add(i);
                    }
                    flagParent1 = 0;
                    flagParent2 = 0;
                }
            }

            if (typejob == 0)//horneado 12
            {
                for (int i = 0; i < FirstGen[parent1].Count(); i++)
                {
                    if (FirstGen[parent1][i] == 12)
                    {
                        jobAux.Add(i);
                        flagParent1 = 1;
                    }
                    if (FirstGen[parent2][i] == 12)
                    {
                        jobAux.Add(i);
                        flagParent2 = 1;
                    }
                    if (flagParent1 == 0 && flagParent2 == 0)
                    {
                        nonJob.Add(i);
                    }
                    flagParent1 = 0;
                    flagParent2 = 0;
                }
            }
            DeleteRepeated(jobAux);

        }

        public void DeleteRepeated(List<int> jobAux)
        {
            for (int i = 0; i < jobAux.Count(); i++)
            {
                int j = i+1;
                while (j<jobAux.Count())
                {
                    if (jobAux[i] == jobAux[j])
                        jobAux.RemoveAt(j);
                    else
                    {
                        j++;
                    }
                }
            }
        }


        public void Print() //imprime los resultados
        {
            for(int i = 0; i < FirstGen.Count(); i++)
            {
                for(int j= 0; j < FirstGen[i].Count(); j++)
                {
                    Console.Write(FirstGen[i][j] + ", ");
                }
                Console.WriteLine(i);
            }

        }



    }
}
