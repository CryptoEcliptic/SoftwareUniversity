using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensOrOdds
{
    class EvensOrOdds
    {
        static void Main(string[] args)
        {
            long[] range = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(long.Parse)
                 .ToArray();
            long start = range[0];
            long end = range[1];

            string condition = Console.ReadLine();

            List<long> numbers = new List<long>();
            FillList(start, end, numbers);

            Predicate<long> even = x => { return x % 2 == 0; };
            Predicate<long> odd = x => { return x % 2 != 0; };

            if (condition == "even")
            {
                numbers = numbers.FindAll(even);
            }
            else
            {
                numbers = numbers.FindAll(odd);
            }
            Console.WriteLine(string.Join(" ", numbers));

        }

        private static void FillList(long start, long end, List<long> numbers)
        {
            for (long i = start; i <= end; i++)
            {
                numbers.Add(i);
            }
        }
    }
}
