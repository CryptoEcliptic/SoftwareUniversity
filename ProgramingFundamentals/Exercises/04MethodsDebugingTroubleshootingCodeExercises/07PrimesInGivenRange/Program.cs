using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07PrimesnGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            string numbers = String.Join(", ", GetPrimeNumbers(startNumber, endNumber).ToArray());
            Console.WriteLine(numbers);
        }
        private static List<int> GetPrimeNumbers(int start, int stop)
        {
            var result = new List<int>();
            for (int i = start; i <= stop; i++)
            {
                bool isPrime = true;
                if (i < 2) isPrime = false;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime == true)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
