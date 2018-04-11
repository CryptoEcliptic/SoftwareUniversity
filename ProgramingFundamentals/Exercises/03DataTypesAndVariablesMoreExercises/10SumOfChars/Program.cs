using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            short numberOfSymbols = short.Parse(Console.ReadLine());
            int sumOfSymbols = 0;

            for (int i = 0; i < numberOfSymbols; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                sumOfSymbols += symbol;
            }
            Console.WriteLine($"The sum equals: {sumOfSymbols}");
        }
    }
}
