using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                int currentNumber = inputNumbers[i];
                var square = Math.Sqrt(currentNumber);
                if (square == (int)square)
                {
                    result.Add((int)currentNumber);
                }
            }
            result.Sort();
            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
