using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Custom_Comparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Predicate<int> even = x => { return x % 2 == 0; };
            Predicate<int> odd = x => { return x % 2 != 0; };

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            AddingEvenNumbers(numbers, even, evenNumbers);
            AddingOddNumbers(numbers, odd, oddNumbers);

            evenNumbers.Sort();
            oddNumbers.Sort();

            Console.Write(string.Join(" ", evenNumbers) + " ");
            Console.WriteLine(string.Join(" ", oddNumbers));
        }

        private static void AddingOddNumbers(int[] numbers, Predicate<int> odd, List<int> sortedNumbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (odd(currentNumber))
                {
                    sortedNumbers.Add(currentNumber);
                }
            }
        }

        private static void AddingEvenNumbers(int[] numbers, Predicate<int> even, List<int> sortedNumbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (even(currentNumber))
                {
                    sortedNumbers.Add(currentNumber);
                }
            }
        }
    }
}
