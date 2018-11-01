using System;
using System.Linq;

namespace _07PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            long lengthName = long.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length <= lengthName)
                .ToArray();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
