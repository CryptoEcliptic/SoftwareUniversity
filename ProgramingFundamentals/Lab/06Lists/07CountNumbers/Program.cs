using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] countNumber = new int[1001];
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                countNumber[currentNumber]++;
            }

            for (int i = 0; i < countNumber.Length; i++)
            {
                if (countNumber[i] > 0)
                {
                    Console.WriteLine($"{i} -> {countNumber[i]}");
                }
            }
        }
    }
}
