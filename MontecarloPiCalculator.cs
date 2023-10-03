using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MontecarloThreads
{
    internal class MontecarloPiCalculator
    {
        int points = 999999999; //Puntos a generar
        int pointsInside = 0; //Puntos que caen dentro
        int numThreads = Environment.ProcessorCount; //Calcula cuantos procesadores tiene el equipo, y esos seran el numero de hilos a crear
        private int[] threadInsideCounts; //Arreglo para almacenar cuantos puntos caen por hilo

        public void calculatePi()
        {
            Thread[] threads = new Thread[numThreads]; //Arreglo de hilos
            threadInsideCounts = new int[numThreads];

            for (int i = 0; i < numThreads; i++) //Ciclo que declara e inicia los hilos
            {
                threads[i] = new Thread(calculateMontecarlo);
                threads[i].Start(i);
            }

            foreach (var thread in threads) //Ciclo que espera que todos los hilos 
            {
                thread.Join();
            }

            for (int i = 0; i < numThreads; i++) //Ciclo que suma cuantos puntos cayeron por hilo, se suman en pointsInside
            {
                pointsInside += threadInsideCounts[i];
            }

            double aproxPi = 4.0 * pointsInside / points;
            Console.WriteLine("Estimación de Pi: " + aproxPi);
        }

        private void calculateMontecarlo(object threadIndex) //Se le pasa el indice del hilo
        {
            Random random = new Random();
            int index = (int)threadIndex; //Se hace el cast 

            int insideCount = 0;

            for (int i = 0; i < points/numThreads; i++)
            {
                double x = random.NextDouble(); 
                double y = random.NextDouble();
                if (x * x + y * y <= 1)
                {
                    insideCount++;
                }
            }
            threadInsideCounts[index] = insideCount; //Se guarda el numero de puntos que cayeron adentro, en el arreglo
        }
    }
}
