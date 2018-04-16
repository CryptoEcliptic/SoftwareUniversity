using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace _13Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger inputNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            for (int i = 1; i <= inputNumber; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial); //Example for factorial 1 * 2 * 3 * 4 * 5 = 120
        }
    }
}
