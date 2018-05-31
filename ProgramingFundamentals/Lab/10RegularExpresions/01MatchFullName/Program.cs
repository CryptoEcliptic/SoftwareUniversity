using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            MatchCollection patternResult = Regex.Matches(input, pattern);

            foreach (Match result in patternResult)
            {
                Console.Write($"{result.Value} ");
            }
            Console.WriteLine();

        }
    }
}
