using System;
using System.Collections.Generic;

namespace _06TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPassings = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            Queue<string> waitingCars = new Queue<string>();
            int counter = 0;
            while (input != "end")
            {
                if (input != "green")
                {
                    waitingCars.Enqueue(input);
                }
                else if (input == "green")
                {
                    int carsCanPass = Math.Min(numberPassings, waitingCars.Count);

                    for (int i = 1; i <= carsCanPass ; i++)
                    {
                        counter++;
                        Console.WriteLine($"{waitingCars.Dequeue()} passed!");
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");

        }
    }
}
