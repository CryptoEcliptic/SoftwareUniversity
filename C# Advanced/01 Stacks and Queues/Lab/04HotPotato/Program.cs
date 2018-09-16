using System;
using System.Collections.Generic;
using System.Linq;

namespace _05HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine()
                .Split(' ')
                .ToArray();

            int toss = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(children); //Adding the input in the Queue instead of
            //for loop
            while (names.Count != 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    names.Enqueue(names.Dequeue());
                }
                Console.WriteLine($"Removed {names.Dequeue()}");
            }
            Console.WriteLine($"Last is {names.Dequeue()}");

        }
    }
}
