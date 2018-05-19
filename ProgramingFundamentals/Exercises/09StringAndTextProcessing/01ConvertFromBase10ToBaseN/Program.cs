using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01ConvertFromBase10ToBaseN
{
    class Program
    {
  
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            int baseN = int.Parse(input[0]);
            BigInteger base10Number = new BigInteger();
            base10Number = BigInteger.Parse(input[1]);
            BigInteger reminder = new BigInteger();
            string result = string.Empty;

            while (base10Number > 0)
            {
                reminder = base10Number % baseN;
                base10Number = base10Number / baseN;
                result = reminder.ToString() + result;
            }
            Console.WriteLine(result);

        }
    }
}
