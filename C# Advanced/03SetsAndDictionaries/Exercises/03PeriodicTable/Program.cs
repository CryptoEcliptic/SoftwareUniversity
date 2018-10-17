using System;
using System.Collections.Generic;

namespace _03PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            SortedSet<string> table = new SortedSet<string>();
            for (int i = 0; i < inputNumber; i++)
            {
                string[] element = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < element.Length; j++)
                {
                    if (!table.Contains(element[j]))
                    {
                        table.Add(element[j]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", table));
        }
    }
}
