using System;
using System.Collections.Generic;
using System.Linq;

namespace _09ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .Distinct()
                 .ToArray();

            List<int> divisibleNumbers = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                int currentNumber = i;
                if (FindDivisibleNumbers(dividers, currentNumber))
                {
                    divisibleNumbers.Add(currentNumber);
                }
            }
            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }
        private static bool FindDivisibleNumbers(int[] dividers, int currentNum)
        {
            bool isDivisible = true;

            foreach (var div in dividers)
            {
                if (currentNum % div != 0)
                {
                    isDivisible = false;
                }
            }
            return isDivisible;
        }
    }
}
