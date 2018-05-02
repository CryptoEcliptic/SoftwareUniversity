using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            inputNumbers = inputNumbers.OrderByDescending(x => x).Take(3).ToList();
            foreach (var number in inputNumbers)
            {
                double result = number;
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
