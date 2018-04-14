using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            long inputNubber = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(inputNubber));

        }
        private static bool IsPrime(long number)
        {
            long num = (long)Math.Sqrt(number);

            if (number <= 1)
            {
                return false;
            }
            else if (number > 2)
            {
                for (int i = 2; i <= num; i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
            }
                return true;
        }
    }
}
