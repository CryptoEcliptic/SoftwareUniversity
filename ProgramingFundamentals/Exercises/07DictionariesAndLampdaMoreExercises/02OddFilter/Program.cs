using System;
using System.Linq;

namespace _02OddFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] managedNums = inputNumbers
                .Where(x => x % 2 == 0)
                .ToArray();
            double average = managedNums.Average();

            for (int i = 0; i < managedNums.Length; i++)
            {
                if (managedNums[i] > average)
                {
                    managedNums[i] += 1;
                }
                else
                {
                    managedNums[i] -= 1;
                }
                Console.Write(managedNums[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
