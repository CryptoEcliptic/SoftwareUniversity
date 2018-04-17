using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split(' ').ToArray();
            inputStrings = inputStrings.Reverse().ToArray();

            foreach (var inputString in inputStrings)
            {
                Console.Write(inputString + " ");
            }
        }
    }
}
