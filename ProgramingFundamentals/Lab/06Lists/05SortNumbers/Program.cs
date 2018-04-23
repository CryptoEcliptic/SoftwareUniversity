using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> inputNumbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            inputNumbers.Sort();
            
            Console.WriteLine(string.Join(" <= ", inputNumbers));
        }
    }
}
