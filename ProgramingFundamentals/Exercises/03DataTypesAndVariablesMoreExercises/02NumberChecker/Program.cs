using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02NumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberString = Console.ReadLine();
            bool integer = false;
            bool floating = false;
            try
            {
                long intNum = long.Parse(numberString);
                integer = true;
            }
            catch (Exception)
            {
            }
            try
            {
                double doubleNum = double.Parse(numberString);
                floating = true;
            }
            catch (Exception)
            {
            }
            if (integer == true)
            {
                Console.WriteLine("integer");
            }
            else if (floating == true)
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}
