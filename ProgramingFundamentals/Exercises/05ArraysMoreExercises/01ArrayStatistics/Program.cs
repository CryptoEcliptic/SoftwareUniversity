using System;
using System.Linq;

namespace _01ArrayStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            Console.WriteLine($"Min = {inputNumbers.Min()}");
            Console.WriteLine($"Max = {inputNumbers.Max()}");
            Console.WriteLine($"Sum = {inputNumbers.Sum()}");
            Console.WriteLine($"Average = {inputNumbers.Average()}");
        }
    }
}
