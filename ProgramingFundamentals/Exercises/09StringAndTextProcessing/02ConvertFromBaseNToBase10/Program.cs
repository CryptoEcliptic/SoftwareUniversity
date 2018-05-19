using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02ConvertFromBaseNToBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split();
            int baseN = int.Parse(input[0]);
            char[] base10Number = input[1].ToCharArray();

            BigInteger result = new BigInteger();

            for (int i = 0; i < base10Number.Length; i++)
            {
                int currentNum = (int)Char.GetNumericValue(base10Number[i]);
                result += currentNum * BigInteger.Pow(baseN, base10Number.Length - i - 1);
            }

            Console.WriteLine(result);
        }
    }
}
