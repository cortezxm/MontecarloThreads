using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontecarloThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MontecarloPiCalculator pi = new MontecarloPiCalculator();

            DateTime begins = DateTime.Now;
            pi.calculatePi();
            DateTime ends = DateTime.Now;

            TimeSpan time = ends - begins;
            Console.WriteLine("Tiempo transcurrido: " + time.Milliseconds);
            Console.ReadKey();
        }
    }
}
