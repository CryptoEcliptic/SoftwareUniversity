using System;
using System.Collections.Generic;
using System.Linq;

namespace _06TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());
            Queue<long[]> data = new Queue<long[]>();

            for (int pumpNumber = 0; pumpNumber < turns; pumpNumber++)
            {
                long[] petrolPumps = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();
                data.Enqueue(petrolPumps);
            }
            
            for (int currentStart = 0; currentStart < turns - 1; currentStart++)
            {
                long fuel = 0;
                bool isTrue = true;
                for (int j = 0; j < turns; j++)
                {
                    long[] currnetPump = data.Dequeue();
                    long currentFuel = currnetPump[0];
                    long distance = currnetPump[1];
                    data.Enqueue(currnetPump);

                    fuel += currentFuel - distance;
                    if (fuel < 0)
                    {
                        currentStart += j;
                        isTrue = false;
                        break;
                    }
                }
                if (isTrue)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
                
            }
            
        }
    }
}
