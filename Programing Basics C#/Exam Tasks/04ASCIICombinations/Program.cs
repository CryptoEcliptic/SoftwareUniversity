using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04ASCIICombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string digits = null;
            string capitalLetters = null;
            string smallLetters = null;
            string otherSymbol = null;
            int sumNumbers = 0;
            int sumCapLetters = 0;
            int sumSmallLetters = 0;
            int sumOtherSymbols = 0;

            for (int i = 1; i <= n; i++)
            {
                char symbol = char.Parse(Console.ReadLine());

                if (symbol >= '0' && symbol <= '9')
                {
                    sumNumbers += symbol;
                    digits += symbol;
                }
                else if (symbol >= 'A' && symbol <= 'Z')
                {
                    sumCapLetters += symbol;
                    capitalLetters += symbol;
                }
                else if (symbol >= 'a' && symbol <= 'z')
                {
                    sumSmallLetters += symbol;
                    smallLetters += symbol;
                }
                else
                {
                    sumOtherSymbols += symbol;
                    otherSymbol += symbol;
                }
            }
            if (sumNumbers >= sumCapLetters && sumNumbers >= sumSmallLetters && sumNumbers >= sumOtherSymbols)
            {
                Console.WriteLine($"Biggest ASCII sum is:{sumNumbers}");
                Console.WriteLine($"Combination of characters is:{digits}");
            }
            else if (sumCapLetters >= sumSmallLetters && sumCapLetters >= sumOtherSymbols)
            {
                Console.WriteLine($"Biggest ASCII sum is:{sumCapLetters}");
                Console.WriteLine($"Combination of characters is:{capitalLetters}");
            }
            else if (sumSmallLetters >= sumOtherSymbols)
            {
                Console.WriteLine($"Biggest ASCII sum is:{sumSmallLetters}");
                Console.WriteLine($"Combination of characters is:{smallLetters}");
            }
            else
            {
                Console.WriteLine($"Biggest ASCII sum is:{sumOtherSymbols}");
                Console.WriteLine($"Combination of characters is:{otherSymbol}");
            }
        }
    }
}
