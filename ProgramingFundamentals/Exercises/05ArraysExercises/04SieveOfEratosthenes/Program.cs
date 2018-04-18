using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            bool[] primeNumbers = new bool[inputNumber + 1];

            for (int i = 2; i < primeNumbers.Length; i++)
            {
                primeNumbers[i] = true;
            }
            for (int i = 2; i < Math.Sqrt(inputNumber); i++)
            {
                if (primeNumbers[i] == true)
                {
                    for (int j = i * i; j <= inputNumber; j += i)
                    {
                        primeNumbers[j] = false;
                    }
                }
            }
            List<int> result = new List<int>();

            for (int i = 0; i < primeNumbers.Length; i++)
            {
                if (primeNumbers[i] == true)
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
