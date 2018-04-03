using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("It is a number.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }   
        }
    }
}

