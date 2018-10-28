using System;
using System.Linq;

namespace _01ActionPolong
{
    class ActionPolong
    {
        static void Main(string[] args)
        {
            Action<string> prlong = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(prlong);
        }
    }
}
