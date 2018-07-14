using System;
using System.Text.RegularExpressions;

namespace _03Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pokewordPattern = @"([A-Za-z]+)\-([A-Za-z]+)";
            string didimonPattern = @"([^A-Za-z\-\s]+)";

            while (true)
            {

                Match didiMatch = Regex.Match(input, didimonPattern);
                if (didiMatch.Success)
                {
                    Console.WriteLine(didiMatch);
                }
                else
                {
                       return;
                }
                int firstSymbolDidi = didiMatch.Index;
                input = input.Substring(firstSymbolDidi + didiMatch.Length);

                Match pokeMatch = Regex.Match(input, pokewordPattern);
                if (pokeMatch.Success)
                {
                    Console.WriteLine(pokeMatch);
                }
                else
                {
                    return;
                }
                int firstSymbolBojo = pokeMatch.Index;
                input = input.Substring(firstSymbolBojo + pokeMatch.Length);

            }
        }
    }
}

