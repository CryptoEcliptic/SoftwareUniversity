using System;
using System.Linq;

namespace _03CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .ToArray();
            Func<double[], double> defineMinimalNumber = FindMinimalNumber;
            var minimalNumber = defineMinimalNumber(numbers);

            Console.WriteLine(minimalNumber);
        }

        private static double FindMinimalNumber(double[] numbers)
        {
            double minNumber = double.MaxValue;
            foreach (var number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }
            return minNumber;
        }
    }
}
