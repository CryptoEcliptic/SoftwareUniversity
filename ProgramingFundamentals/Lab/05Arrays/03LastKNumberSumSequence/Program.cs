using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03LastKNumberSumSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numElements = int.Parse(Console.ReadLine());
            int kStep = int.Parse(Console.ReadLine());

            long[] numbers = new long[numElements];
            numbers[0] = 1;
            
            for (int i = 1; i < numbers.Length; i++)
            {
                long sum = 0;
                for (int j = i - kStep; j <= i - 1; j++)
                {
                    if (j >= 0)
                    {
                        sum += numbers[j];
                    }
                    numbers[i] = sum;
                }
            }
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
