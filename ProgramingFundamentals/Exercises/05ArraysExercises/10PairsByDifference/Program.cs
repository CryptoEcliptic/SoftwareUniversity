using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());

            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                for (int j = i; j < numbers.Length; j++)
                {

                    if (Math.Abs(currentNumber - numbers[j]) == difference)
                    {
                        result++;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
