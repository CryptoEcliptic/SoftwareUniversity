using System;
using System.Linq;

namespace _05AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        for (long i = 0; i < inputNumbers.Length; i++)
                        {
                            Func<double, double> adding = x => x + 1;
                            inputNumbers[i] = adding(inputNumbers[i]);
                        }
                        break;

                    case "multiply":
                        for (long i = 0; i < inputNumbers.Length; i++)
                        {
                            Func<double, double> multyplier = x => x * 2;
                            inputNumbers[i] = multyplier(inputNumbers[i]);
                        }
                        break;

                    case "subtract":
                        for (long i = 0; i < inputNumbers.Length; i++)
                        {
                            Func<double, double> subtraction = x => x - 1;
                            inputNumbers[i] = subtraction(inputNumbers[i]);
                        }
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", inputNumbers));
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
