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

        public GeneticAlgorithm() {
            FirstGen = new List<List<int>>();
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

        public void RunGenetic() //Inicio del programa Genetico
        {



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
