using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputNumbers = Console.ReadLine() // Digits are read as string
                .Split(' ')
                .ToList();

            int result = 0;
            for (int i = 0; i < inputNumbers.Count; i++)
            {
                string currentNumber = inputNumbers[i]; // Current number is string
                string reversed = "";
                for (int j = currentNumber.Length - 1 ; j >= 0; j--) // Loop for reversing the digits
                {
                    reversed += currentNumber[j]; 
                }
                result += int.Parse(reversed); // Parsing the reversed string as integer
            }

            Console.WriteLine(result);
        }
    }
}
