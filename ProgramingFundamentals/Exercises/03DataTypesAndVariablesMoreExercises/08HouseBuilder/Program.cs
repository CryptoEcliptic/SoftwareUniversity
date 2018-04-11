using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08HouseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            long intPrice = 0;
            int sbytePrice = 0;

            try
            {
                long firstInt = long.Parse(firstNumber);
                sbyte secondSbyte = sbyte.Parse(secondNumber);
                intPrice = firstInt * 10;
                sbytePrice = secondSbyte * 4;
            }
            catch (Exception)
            {
                try
                {
                    sbyte firstSbyte = sbyte.Parse(firstNumber);
                    long secondInt = long.Parse(secondNumber);
                    intPrice = secondInt * 10;
                    sbytePrice = firstSbyte * 4;
                }
                catch (Exception)
                {
                }
            }
            long totalPrice = intPrice + sbytePrice;
            Console.WriteLine(totalPrice);
        }
    }
}
