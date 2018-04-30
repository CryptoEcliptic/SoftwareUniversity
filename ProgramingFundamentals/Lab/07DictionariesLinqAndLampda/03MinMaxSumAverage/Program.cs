using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03MinMaxSumAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List <int> inputNumbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                inputNumbers.Add(int.Parse(Console.ReadLine()));
            }

            int sum = inputNumbers.Sum();
            int min = inputNumbers.Min();
            int max = inputNumbers.Max();
            double average = inputNumbers.Average();

            Console.WriteLine($"Sum = {sum}\nMin = {min}\nMax = {max}\nAverage = {average}");
        }
    }
}
