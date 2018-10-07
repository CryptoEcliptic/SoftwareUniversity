using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _03CountSameValuesIn_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double[] numbersStrings = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            var dict = new Dictionary<double, int>();

            for (int i = 0; i < numbersStrings.Length; i++)
            {
                double currentNumber = numbersStrings[i];
                if (!dict.ContainsKey(currentNumber))
                {
                    dict.Add(currentNumber, 1);
                }
                else
                {
                    dict[currentNumber]++;
                }
            }

            foreach (var num in dict)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
