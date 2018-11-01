using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divisionNumber = int.Parse(Console.ReadLine());

            Func<int, bool> divisibleByNumber = x => (x % divisionNumber == 0);

            List<int> result = new List<int>();
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                int currentNumber = inputNumbers[i];
                if (!divisibleByNumber(currentNumber))
                {
                    result.Add(currentNumber);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
