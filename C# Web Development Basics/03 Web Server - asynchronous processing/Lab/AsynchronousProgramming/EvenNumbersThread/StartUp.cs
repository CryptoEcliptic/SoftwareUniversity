using System;
using System.Linq;
using System.Threading;

namespace EvenNumbersThread
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = parameters[0];
            int end = parameters[1];

            Thread evenNumbers = new Thread(() => PrintEvenNumbers(start, end));
            evenNumbers.Start();

            evenNumbers.Join();
            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }             
            }
        }
    }
}
