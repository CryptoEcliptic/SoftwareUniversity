using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberOfEntries = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = numberOfEntries[0];
            int m = numberOfEntries[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);

            }

            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }
            List<int> equals = new List<int>();
            foreach (var n1 in firstSet)
            {
                foreach (var n2 in secondSet)
                {
                    if (n1 == n2)
                    {
                        equals.Add(n1);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", equals));
        }
    }
}
