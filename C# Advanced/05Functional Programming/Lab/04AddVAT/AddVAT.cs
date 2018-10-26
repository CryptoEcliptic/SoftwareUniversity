using System;
using System.Linq;

namespace _04AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(x => double.Parse(x, System.Globalization.CultureInfo.InvariantCulture))
               .Select(x => x * 1.2)
               .ToArray();

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
