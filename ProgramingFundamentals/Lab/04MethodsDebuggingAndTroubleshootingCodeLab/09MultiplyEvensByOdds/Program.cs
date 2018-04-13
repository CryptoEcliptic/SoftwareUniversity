using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09MultiplyEvensByOdds
{
    class Program
    {
        //private static int GetMultipleEvensOrOdds(int n) //Method created according to SoftUni instructions. However, no need of it.
        //{
        //    int sumEvens = int.Parse(Console.ReadLine());
        //    int sumOdds = int.Parse(Console.ReadLine());
        //    return sumEvens * sumOdds;
        //}
        private static int GetSumOfOddDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 != 0)
                {
                    sum += lastDigit;
                }
                n = n / 10;
            }
            return sum;
        }
        private static int GetSumOfEvenDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }
                n = n / 10;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int n = Math.Abs(int.Parse(Console.ReadLine()));
            int sumOfEvens = GetSumOfEvenDigits(n);
            int sumOfods = GetSumOfOddDigits(n);
            int sumOdsBySumEvens = sumOfods * sumOfEvens;
            Console.WriteLine(sumOdsBySumEvens);
        }
    }
}
