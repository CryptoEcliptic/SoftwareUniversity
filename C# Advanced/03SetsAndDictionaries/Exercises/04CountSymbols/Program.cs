using System;
using System.Collections.Generic;

namespace _05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                if (!symbols.ContainsKey(currentSymbol))
                {
                    symbols.Add(currentSymbol, 1);
                }
                else
                {
                    symbols[currentSymbol]++;
                }
            }

            foreach (var letter in symbols)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
