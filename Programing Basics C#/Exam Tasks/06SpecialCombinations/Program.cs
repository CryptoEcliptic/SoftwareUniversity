using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06SpecialCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int hundreds = int.Parse(Console.ReadLine());
            int decimals = int.Parse(Console.ReadLine());
            int units = int.Parse(Console.ReadLine());

            for (int i = 2; i <= hundreds; i++)
            {
                for (int j = 2; j <= decimals; j++)
                {
                    for (int k = 2; k <= units; k++)
                    {

                       bool isPrimeTrue = true;

                       for (int q = 2 ; q <= Math.Sqrt(j); q++)
                       {
                          if (j % q == 0)
                          {
                          isPrimeTrue = false;
                          }
                       }
                       if (i %2 == 0 && k % 2 == 0 && isPrimeTrue == true)
                       {
                            Console.WriteLine($"{i} {j} {k}");
                       }
                    }
                }
            }
        }
    }
}
