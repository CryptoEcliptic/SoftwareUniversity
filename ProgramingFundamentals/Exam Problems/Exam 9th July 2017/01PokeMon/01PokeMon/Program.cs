using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            long powerN = long.Parse(Console.ReadLine());
            long targetDistanceM = long.Parse(Console.ReadLine());
            long exhaustionFactorY = long.Parse(Console.ReadLine());
            long counts = 0;
            double halfN = powerN / 2;

            while (powerN >= targetDistanceM)
            {
                powerN = powerN - targetDistanceM;
                if (powerN == halfN && exhaustionFactorY > 0) // if exhaustionFactorY = 0 program will have runtime error
                {
                    powerN = powerN / exhaustionFactorY;
                }

                counts++;
            }
            Console.WriteLine(powerN);
            Console.WriteLine(counts);
        }
    }
}
