using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> numbersCount = new SortedDictionary<double, int>();

            foreach (var number in inputNumbers)
            {
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount[number] = 0;
                }

                    numbersCount[number]++;  
            }
            foreach (var kvp in numbersCount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
