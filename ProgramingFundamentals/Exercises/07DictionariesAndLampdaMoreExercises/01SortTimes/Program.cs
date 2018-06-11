using System;
using System.Linq;

namespace _01SortTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] time = Console.ReadLine().Split(' ').ToArray();

            var timeSorted = time.OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(", ", timeSorted));
        }
    }
}
