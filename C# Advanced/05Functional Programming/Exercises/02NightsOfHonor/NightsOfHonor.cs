using System;
using System.Linq;

namespace _02NightsOfHonor
{
    class NightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> prlong = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(prlong);
        }
    }
}
