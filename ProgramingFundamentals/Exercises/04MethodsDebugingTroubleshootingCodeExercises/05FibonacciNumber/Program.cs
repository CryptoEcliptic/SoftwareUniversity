using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05FibonacciNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            long inputNumber = long.Parse(Console.ReadLine());
            long fibonacciNumber = Fibonacci(inputNumber);
            if (inputNumber == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(fibonacciNumber);
            }
        }
        private static long Fibonacci(long n)
        {
            long num1 = 0;
            long num2 = 1;
            long fiboNumber = 0;
            for (int i = 1; i <= n; i++)
            {
                fiboNumber = num1 + num2;
                num1 = num2;
                num2 = fiboNumber;
            }
            return fiboNumber;
        }
    }
}
