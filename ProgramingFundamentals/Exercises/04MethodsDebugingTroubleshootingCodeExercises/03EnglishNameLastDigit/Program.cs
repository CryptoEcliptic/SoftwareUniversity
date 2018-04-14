using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03EnglishNameLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            long lastNum = LastDigit(number);
            string[] tonine = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            Console.WriteLine(tonine[lastNum]);
        }
        static long LastDigit(long n)
        {
            long lastNum = Math.Abs(n % 10);
            return lastNum;
        }
    }
}
