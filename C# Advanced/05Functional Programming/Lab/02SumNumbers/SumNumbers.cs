using System;
using System.Linq;

namespace _02SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
