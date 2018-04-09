using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15FastPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberLimit = int.Parse(Console.ReadLine());
            for (int number = 2; number <= numberLimit; number++)
            {
                bool isNumberPrime = true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isNumberPrime = false;
                    }
                }
                Console.WriteLine($"{number} -> {isNumberPrime}");
            }
        }
    }
}
