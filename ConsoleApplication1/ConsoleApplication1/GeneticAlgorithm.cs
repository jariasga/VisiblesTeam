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
        int maxGenerations;
        double acceptablePercentaje;
        double totalFitness;
        List<double> fitnessList = new List<double>();
        List<double> fitnessSortedList = new List<double>();
        List<double> invFitnessList = new List<double>();
        List<double> invFitnessSortedList = new List<double>();
        private int generationCount = 0;
        Random rnd;

        public GeneticAlgorithm(Instance inst)
        {
            FirstGen = new List<List<int>>();
            actualIns = inst;

            maxGenerations = 100;
            acceptablePercentaje = 10;
            rnd = new Random();
        }

        public void CreateFirstGen(List<int[]>grasp) //Cargar la primera generacion
        {
            
            List<int> auxOneSol;
            for(int i = 0; i < grasp.Count(); i++)
            {
                auxOneSol = new List<int>();
                for (int j = 0; j < grasp[i].Count(); j++)
                    auxOneSol.Add(grasp[i][j]);
                FirstGen.Add(auxOneSol);
            }
            return;
        }

        public void ParentsSelection(ref int parent1, ref int parent2, int cantidad) {
            Random rnd = new Random();
            double father1, father2;
            
            createRoulette();
            father1 = rnd.NextDouble(0, totalFitness);
            father2 = rnd.NextDouble(0, totalFitness);

            parent1 = closestChoice(father1);
            parent2 = closestChoice(father2);

            while (parent1 == parent2)
            {
                parent2 = rnd.Next(0, cantidad);
            }
        }

        private int closestChoice(double value)
        {
            int i = 0, indexInvSor;
            double aux = 0, sum = 0, fitnessValue;

            while (sum < value)
            {
                aux = invFitnessSortedList[i];
                sum += aux;
                i++;
            }
            indexInvSor = invFitnessSortedList.IndexOf(aux);
            fitnessValue = fitnessSortedList[indexInvSor];
            return fitnessList.IndexOf(fitnessValue);
        }

        public int createRoulette()
        {
            Random rnd = new Random();
            totalFitness = 0;
            double fitnessActual;

            fitnessList.Clear();
            fitnessSortedList.Clear();
            invFitnessList.Clear();
            invFitnessSortedList.Clear();

            for (int i = 0; i < FirstGen.Count(); i++)
            {
                fitnessActual = actualIns.getFitness(FirstGen[i]);

                totalFitness += 1 / fitnessActual;

                fitnessList.Add(fitnessActual);
                fitnessSortedList.Add(fitnessActual);
                invFitnessList.Add(1 / fitnessActual);
                invFitnessSortedList.Add(1 / fitnessActual);
            }
            invFitnessSortedList.Reverse();
            fitnessSortedList.Sort();

            return 0;
        }
        
        public int randomRoulette(int parent)
        {

            int value = 0;
            List<int> auxList = new List<int>();
            for (int i = 0; i < FirstGen.Count(); i++)
            {
                int fit = (int)actualIns.getFitness(FirstGen[i]);
                for (int j = 0; j < fit; j++)
                    auxList.Add(i);
            }
            value = rnd.Next(0, auxList.Count());
            return value;
        }
        
        public void saveBestInGen(List<List<int>> Generation, ref List<int> bestInGen,ref int pos,ref  List<int> bestSolGenetic)
        {
            //primero limpiar bestingen y luego agregar
            while (bestInGen.Count() > 0)
            {
                bestInGen.RemoveAt(0);
            }

            for (int i = 0; i < Generation[pos].Count(); i++)
            {
                bestInGen.Add(Generation[pos][i]);
            }
            Console.Write("Generacion: " + generationCount + "\t-- fitness parcial: " + Math.Round(actualIns.getFitness(bestInGen),3));

            if ((actualIns.getFitness(bestInGen) < actualIns.getFitness(bestSolGenetic)) && (bestSolGenetic.Count() > 0))
            {
                bestSolGenetic.Clear();
                for (int i = 0; i < bestInGen.Count(); i++)
                    bestSolGenetic.Add(bestInGen[i]);
            }
            else
            {
                if (bestSolGenetic.Count() == 0)
                {
                    for (int i = 0; i < bestInGen.Count(); i++)
                        bestSolGenetic.Add(bestInGen[i]);
                }
            }
            Console.WriteLine("\t//Best: " + Math.Round(actualIns.getFitness(bestSolGenetic),3));
        }

        public double evaluateFitness(List<List<int>> NewGeneration, ref int bestPos)
        {
            double value = 1000;
            for (int i = 0; i < NewGeneration.Count(); i++)
            {
                double auxFit;
                auxFit = evaluateFitnessInChild(NewGeneration[i]);
                if (auxFit < value)
                {
                    value = auxFit;
                    bestPos = i;
                }
            }
            return value;
        }

        public void newGenToFirstGen(ref List<List<int>> FirstGen, ref List<List<int>> NewGeneration)
        {
            //limpiar first generation
            FirstGen.Clear();

            for (int i = 0; i < NewGeneration.Count(); i++)
                FirstGen.Add(NewGeneration[i]);

            //limpiar new generation
            NewGeneration.Clear();

        }

        public void PrintWorkerAndPosition(List<int> fitnessList)
        {
            for(int i = 0; i < fitnessList.Count(); i++)
                Console.WriteLine("El trabajador: " + i + " es asignado al puesto: " + PrintPosition(fitnessList[i]));
            
        }

        public string PrintPosition(int i)
        {
            
            if (i == 0)
                return "sin asignar";
            if (i == 10)
                return "modelado de huacos";
            if (i == 11)
                return "pintado de huacos";
            if (i == 12)
                return "horneado de huacos";
            if (i == 20)
                return "tallado de piedra";
            if (i == 30)
                return "tallado de retablo";
            if (i == 31)
                return "pintado de retablo";
            return "";
        }

        public List<int> RunGenetic() //Inicio del programa Genetico
        {
            //DONE
            /*List<int> numWorkersInJob;     //numer de trabajadores necesitados por puesto
            numWorkersInJob = new List<int>();*/
            //tiempo de ejecucion
            var watch = System.Diagnostics.Stopwatch.StartNew();            

            //0 carving 1 painting 2 kaking 3 molding
            int start_time = Environment.TickCount;

            int numWorkersPerMember = FirstGen[0].Count(); //numero de trabajadores en una solucion (individuo)
            List<List<int>> NewGeneration; //mejor solucion hasta ahora (deberia ser por generacion)
            List<int> bestSolution = new List<int>(); ;
            List<int> bestSolGenetic = new List<int>(); ;
            List<int> generalJobs = new List<int>();


            List<int> assignedWorkersAux = new List<int>(); //lista auxiliar de trabajadores asignados a un puesto
            List<int> nonAssignWorkersAux = new List<int>(); //lista auxiliar de trabajadores no asignados

            int parent1 = 0, parent2 = 0;       //indices de los padres seleccionados


            NewGeneration = new List<List<int>>();

            double fitnessValue;
            int bestPos = 0;

            fitnessValue = evaluateFitness(FirstGen, ref bestPos);
            Console.WriteLine("Gen 1 fitness: " + fitnessValue);

            //impresion de salida trabajador-> puesto
            //PrintWorkerAndPosition(FirstGen[bestPos]);

            fitnessValue = evaluateFitness(FirstGen, ref bestPos);

            //1. DONE contar los puestos en general (tallar, moldear, pintar, hornear) se podria usar instance 
            //cambiar por numWorkersInJob

            //WHILE general del algoritmo
            while (/*Environment.TickCount - start_time < limit_time && */generationCount < maxGenerations)
            {

                generationCount++;
                //2. hallar fitness de la solucion, >0 se usa como flag para la primera generacion
                if (NewGeneration.Count() > 0)
                {
                    //bestPos-> el mejor de la solucion
                    fitnessValue = evaluateFitness(NewGeneration, ref bestPos);

                    //2.2 DONE nueva generacion pasa a ser firstgen y se actualiza la mejor solucion con la mejor de la gen
                    //2.3 DONE limpiar newgeneracion (vacia)
                    newGenToFirstGen(ref FirstGen, ref NewGeneration);  //tambien vacia la lista newGeneration
                    saveBestInGen(FirstGen, ref bestSolution,ref bestPos, ref bestSolGenetic);
                }

                //limpiar nonassigned
                nonAssignWorkersAux.Clear();

                //WHILE para la creacion de una generacion
                //3.1 DONE si el numero de elementos en la generacion es 200 (ya esta llena la generacion) -> salir
                while (NewGeneration.Count() < maxGenerations)
                {
                    generalJobs.Add(0); //carving
                    generalJobs.Add(1); //molding
                    generalJobs.Add(3); //painting
                    generalJobs.Add(2); //baking
                    //3.2 DONE crear individuo contrabajadores sin asignar
                    List<int> child = new List<int>();
                    for (int i = 0; i < numWorkersPerMember; i++)
                        child.Add(0);
                    //3.3 DONE Ruleta para seleccion de padres
                    ParentsSelection(ref parent1, ref parent2, FirstGen.Count());

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
                        checkWithChild(nonAssignWorkersAux, child);
                        //4.2 DONE random de 1 a 100 si sale 1 elegir al azar
                        //4.2.1 DONE si no, sacar a los  n mejores (ya estan revisados los que posiblemente ya estan asignados en child)
                        //para ocuparlos
                        //4.3 DONE actualizar a child con los nuevos puestos
                        //4.4 DONE agregar a los que quedaron en generaljobs a los no asignados (general job quedaria vacio para la nueva corrida)
                        chooseAndAddWorkersInChild(assignedWorkersAux, nonAssignWorkersAux, child, actualIns.processes_positions[puestoActual], puestoActual);
                    }
                    //4.5 DONE evaluar fitness del hijo (child) si no es mejor, no se agrega a la generacion
                    //limpiar child
                    //REVISAR el if
                    double result = evaluateFitnessInChild(child);

                    if (evaluateFitnessInChild(child) < fitnessValue * (1 + acceptablePercentaje))
                        //if(true)
                        NewGeneration.Add(child);
                    else
                        child = null; //"clear memory" garbage collection
                }

                //tambien deshechar las generaciones
                int aux = 0;
                double testNewGen = evaluateFitness(NewGeneration, ref aux);
                if (testNewGen > 10000)
                {
                    NewGeneration.Clear();
                    generationCount--;
                }
            }
            Console.WriteLine("Acabó Genetico");
            watch.Stop();
            TimeSpan ts = watch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("Runtime " + elapsedTime);
            return bestSolGenetic;
        }

        //DONE
        public double evaluateFitnessInChild(List<int> child)
        {
            double value = actualIns.getFitness(child);
            return value;

        }

        public void chooseAndAddWorkersInChild(List<int> assignedWorkersAux, List<int> nonAssignWorkersAux, List<int> child, int numWorkers, int job)
        {
            int mutation;
            List<double> bestRatioPerWorker;
            List<int> bestJobPerWorker;
            bestRatioPerWorker = new List<double>();
            bestJobPerWorker = new List<int>();
            //DONE que existen suficientes en assignedWorkersAux
            if (assignedWorkersAux.Count() < numWorkers)
            {
                for (int i = 0; i < nonAssignWorkersAux.Count(); i++)
                    assignedWorkersAux.Add(nonAssignWorkersAux[i]);
                nonAssignWorkersAux.Clear();
                DeleteRepeated(assignedWorkersAux);
                checkWithChild(assignedWorkersAux, child);
            }


            //MUTACION
            mutation = rnd.Next(1, 101);
            int mutationFlag = 0;
            if (mutation == 1)// Ocurre la mutacion, random
            {
                for (int i = 0; i < nonAssignWorkersAux.Count(); i++)
                    assignedWorkersAux.Add(nonAssignWorkersAux[i]);
                nonAssignWorkersAux.Clear();
                mutationFlag = 1;
            }
            //else //no existe mutacion
            //{
            //DONE llena los arreglos
            fillBest2(assignedWorkersAux, job, bestRatioPerWorker, bestJobPerWorker);

            for (int i = 0; i < numWorkers; i++)
            {
                int index;
                if (mutationFlag == 1)
                {
                    index = rnd.Next(0, assignedWorkersAux.Count());
                }
                else
                    index = findBest(bestRatioPerWorker);
                //actualizar child
                child[assignedWorkersAux[index]] = bestJobPerWorker[index];
                assignedWorkersAux.RemoveAt(index);
                bestJobPerWorker.RemoveAt(index);
                bestRatioPerWorker.RemoveAt(index);
            }
            //agregar a los que sobran a nonassignjob
            for (int i = 0; i < assignedWorkersAux.Count(); i++)
                nonAssignWorkersAux.Add(assignedWorkersAux[i]);
            assignedWorkersAux.Clear();
            DeleteRepeated(nonAssignWorkersAux);
            checkWithChild(nonAssignWorkersAux, child);
            //}
        }

        public void fillBest2(List<int> assignedWorkers, int job, List<double> ratios, List<int> jobPerWork)
        {
            double best1 = 0, best2 = 0;
            int id1 = -1;
            int id2 = -1;

            //todos los posibles trabajadores
            for (int i = 0; i < assignedWorkers.Count(); i++)
            {
                //reviso todos los procesos por cada trabjador para hallar sus ratios
                for (int j = 0; j < actualIns.ratios.Count(); j++)
                {
                    if (job == 0)//tallado 20 0 30
                    {
                        if (actualIns.ratios[j].worker.id - 1 == assignedWorkers[i])//si es el trabajador
                        {
                            if (actualIns.ratios[j].process_product_id == 20)
                            {
                                id1 = 20;

                                if (actualIns.breakage_weight > actualIns.time_weight)
                                    best1 = actualIns.ratios[j].breakage;
                                else
                                    best1 = actualIns.ratios[j].time;

                            }

                            if (actualIns.ratios[j].process_product_id == 30)
                            {
                                id1 = 30;

                                if (actualIns.breakage_weight > actualIns.time_weight)
                                    best2 = actualIns.ratios[j].breakage;
                                else
                                    best2 = actualIns.ratios[j].time;

                            }

                        }
                    }

                    if (job == 1)//moldeado 10
                    {
                        if (actualIns.ratios[j].worker.id - 1 == assignedWorkers[i])//si es el trabajador
                        {
                            if (actualIns.ratios[j].process_product_id == 10)
                            {
                                id1 = 10;

                                if (actualIns.breakage_weight > actualIns.time_weight)
                                    best1 = actualIns.ratios[j].breakage;
                                else
                                    best1 = actualIns.ratios[j].time;

                            }

                        }
                    }

                    if (job == 3)//pintado 11 0 31
                    {
                        if (actualIns.ratios[j].worker.id - 1 == assignedWorkers[i])//si es el trabajador
                        {
                            if (actualIns.ratios[j].process_product_id == 11)
                            {
                                id1 = 11;

                                if (actualIns.breakage_weight > actualIns.time_weight)
                                    best1 = actualIns.ratios[j].breakage;
                                else
                                    best1 = actualIns.ratios[j].time;

                            }

                            if (actualIns.ratios[j].process_product_id == 31)
                            {
                                id1 = 31;

                                if (actualIns.breakage_weight > actualIns.time_weight)
                                    best2 = actualIns.ratios[j].breakage;
                                else
                                    best2 = actualIns.ratios[j].time;

                            }

                        }
                    }

                    if (job == 2)//horneado 12
                    {
                        if (actualIns.ratios[j].worker.id - 1 == assignedWorkers[i])//si es el trabajador
                        {
                            if (actualIns.ratios[j].process_product_id == 12)
                            {
                                id1 = 12;

                                if (actualIns.breakage_weight > actualIns.time_weight)
                                    best1 = actualIns.ratios[j].breakage;
                                else
                                    best1 = actualIns.ratios[j].time;

                            }

                        }
                    }
                }
                //agrego a ratios y jobperwork
                if (id1 != -1 && id2 != -1)//caso que tenga dos ratios
                {
                    if (best1 > best2)
                    {
                        best1 = best2;
                        id1 = id2;
                    }

                }
                ratios.Add(best1);
                jobPerWork.Add(id1);

                best1 = 0; best2 = 0;
                id1 = -1;
                id2 = -1;
            }
        }




        public void fillBest(List<int> assignedWorkers, int job, List<double> ratios, List<int> jobPerWork)
        {

            double best1 = 0, best2 = 0;
            int id1 = 0;
            int id2 = -1;

            //busco en la clase workers y agrego el mejor ratio y puestoxtrabajo de cada uno de los posibles trabajadores para un puesto
            //if (job == 0)//tallado 20 o 30
            //{
            for (int i = 0; i < assignedWorkers.Count(); i++)
            {
                //DONE con la posicion del worker voy a su posicion y saco los jobxproduct de ahi saco el mejor y pongo el valor y tipo
                for (int j = 0; j < actualIns.ratios.Count(); j++) //busqueda para cada trabajador
                {
                    if (job == 0)//tallado 20 o 30
                    {
                        if (actualIns.ratios[j].worker.id - 1 == assignedWorkers[i])
                        {
                            if (actualIns.ratios[j].process_product_id == 20)
                            {
                                id1 = 20;
                                if (actualIns.breakage_weight > actualIns.time_weight)
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
                                id2 = 30;
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
                        if (actualIns.ratios[j].worker.id - 1 == assignedWorkers[i])
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
                        if (actualIns.ratios[j].worker.id - 1 == assignedWorkers[i])
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
                                id2 = 31;
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
                        if (actualIns.ratios[j].worker.id - 1 == assignedWorkers[i])
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


                }
                //Ver si es el mejor, si lo es, cambiar mejor de la solucion
                if (best1 != 0 && best2 != -1)
                {
                    if (best2 > best1)
                    {
                        best1 = best2;
                        id1 = id2;
                    }
                    ratios.Add(best1);
                    jobPerWork.Add(id1);
                }
                else
                {
                    if (best1 != 0)
                    {
                        ratios.Add(best1);
                        jobPerWork.Add(id1);
                    }
                }
                best1 = 0;
                best2 = 0;//-1
                id1 = 0;
                id2 = -1;
            }
            //}
        }


        public int findBest(List<double> bestRatios)
        {
            //mutacion
            int mutationValue = rnd.Next(1, 101);
            if (mutationValue == 1)
                return rnd.Next(0, bestRatios.Count());

            int value = 0;
            double ratio = bestRatios[0];
            for (int i = 0; i < bestRatios.Count() - 1; i++)
            {
                if (bestRatios[i + 1] < ratio)
                {
                    value = i + 1;
                    ratio = bestRatios[i + 1];
                }
            }
            return value;
        }

        public int giveMeRandomProcess(int job)
        {
            int returnValue = 0;
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
            if (job == 3)
            {
                int value = rnd.Next(0, 2);
                if (value == 0)
                    returnValue = 11;
                if (value == 1)
                    returnValue = 31;
            }

            if (job == 2)
                returnValue = 12;

            return returnValue;
        }


        public void checkWithChild(List<int> assignedWorkers, List<int> child)
        {
            int i = 0;
            while (i < assignedWorkers.Count())
            {
                if (child[assignedWorkers[i]] != 0)
                    assignedWorkers.RemoveAt(i);
                else
                {
                    i++;
                }
            }
        }


        public void addWorkersToCertainJob(int parent1, int parent2, int typejob, List<int> jobAux, List<int> nonJob) //jobaux lista con ids de numero de trabajador
        {
            int flagParent1 = 0; //0 no esta, 1 esta
            int flagParent2 = 0;
            if (typejob == 0)//tallado 20 0 30

            {
                for (int i = 0; i < FirstGen[parent1].Count(); i++)
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
                    if (flagParent1 == 0 && flagParent2 == 0)
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

            if (typejob == 3)//pintado 11 0 31
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

            if (typejob == 2)//horneado 12
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
            DeleteRepeated(nonJob);
        }

        public void DeleteRepeated(List<int> jobAux)
        {
            int count = 0;
            for (int i = 0; i < jobAux.Count(); i++)
            {
                count = 0;
                int j = 0;
                while (j < jobAux.Count())
                {
                    if (jobAux[i] == jobAux[j])
                    {
                        if (count > 0)
                            jobAux.RemoveAt(j);
                        else { count++; j++; }
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }

        public void Print() //imprime los resultados
        {
            for (int i = 0; i < FirstGen.Count(); i++)
            {
                for (int j = 0; j < FirstGen[i].Count(); j++)
                {
                    Console.Write(FirstGen[i][j] + ", ");
                }
                Console.WriteLine(i);
            }
        }        
    }
}