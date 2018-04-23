using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> inputNumbers = Console.ReadLine().Split().Select(decimal.Parse).ToList();

            for (int i = 1; i < inputNumbers.Count; i++)
            {
                if (inputNumbers[i] == inputNumbers[i - 1])
                {
                    inputNumbers[i] = inputNumbers[i] + inputNumbers[i - 1]; //i(1 position) == i(1 position) + i-1(0 position)
                    inputNumbers.Remove(inputNumbers[i - 1]); //Position i(1) becomes i-1 e.g. 0;
                    i = 0;
                }
            }

            Console.WriteLine(string.Join(" ", inputNumbers));
        }
    }
}
