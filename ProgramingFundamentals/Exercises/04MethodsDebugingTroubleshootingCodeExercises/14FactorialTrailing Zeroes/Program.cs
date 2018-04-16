using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace _14FactorialTrailing_Zeroes
{
    class Program
    {
        private static BigInteger CalculatingFactorial(BigInteger number)
        {
            BigInteger factorial = number;
            for (int i = 1; i < number; i++)
            {
                factorial *= i;

            }
            return factorial;
        }
        static BigInteger TailingZeroes(BigInteger num)
        {
            BigInteger tailingZeroes = 0;
            while (num % 10 == 0)
            {
                num = num / 10;
                tailingZeroes++;
            }
            return tailingZeroes;
        }
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger factorial = CalculatingFactorial(input);
            BigInteger tailingZeros = TailingZeroes(factorial);
            Console.WriteLine(tailingZeros);
        }
    }
}
