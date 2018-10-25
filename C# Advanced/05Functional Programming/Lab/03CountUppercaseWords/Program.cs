using System;
using System.Linq;

namespace _03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sentance = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => Char.IsUpper(x[0]))
                .ToArray();

            foreach (var word in sentance)
            {
                Console.WriteLine(word);
            }
        }
    }
}
