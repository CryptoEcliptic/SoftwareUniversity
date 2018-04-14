using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04NumbersInReversedOrderSolution2
{
    class Program
    {
        private static decimal ReversedOrder(decimal number)
        {
            decimal temporaryNumber = number;
            string stringReversedNumber = new string(temporaryNumber.ToString().Reverse().ToArray());
            decimal reversedDecimal;
            if (decimal.TryParse(stringReversedNumber, out reversedDecimal))
            {
                return reversedDecimal;
            }
            else
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            decimal inputNumber = decimal.Parse(Console.ReadLine());
            decimal reversedOutput = ReversedOrder(inputNumber);

            Console.WriteLine(reversedOutput);
        }
    }
}
