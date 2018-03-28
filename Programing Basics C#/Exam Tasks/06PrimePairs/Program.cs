using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int startFirstPair = int.Parse(Console.ReadLine());
            int startSecondPair = int.Parse(Console.ReadLine());
            int differenceFirstPair = int.Parse(Console.ReadLine());
            int differenceSecondPair = int.Parse(Console.ReadLine());
            int endOfFirstPair = startFirstPair + differenceFirstPair;
            int endOfSecondPair = startSecondPair + differenceSecondPair;

            for (int i = startFirstPair; i <= endOfFirstPair; i++)
            {
                for (int j = startSecondPair; j <= endOfSecondPair; j++)
                {
                    bool isFirstPairPrime = true;
                    bool isSecondPairPrime = true;

                    for (int k = 2; k <= Math.Sqrt(i); k++)
                    {
                        if (i % k == 0)
                        {
                            isFirstPairPrime = false;
                        }
                    }
                    for (int l = 2; l <= Math.Sqrt(j); l++)
                    {
                        if (j % l == 0)
                        {
                            isSecondPairPrime = false;
                        }
                    }
                    if (isFirstPairPrime == true && isSecondPairPrime == true)
                    {
                        Console.WriteLine($"{i}{j}");
                    }
                }
            }
        }
    }
}
