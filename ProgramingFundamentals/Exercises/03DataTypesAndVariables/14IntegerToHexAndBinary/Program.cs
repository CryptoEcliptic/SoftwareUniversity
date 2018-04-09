using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14IntegerToHexAndBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string toHexa = Convert.ToString(n, 16).ToUpper();
            string toBinary = Convert.ToString(n, 2).ToUpper();
            Console.WriteLine(toHexa);
            Console.WriteLine(toBinary);
        }
    }
}
