using System;
using System.Linq;

namespace _07InventoryMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            long[] quantity = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            decimal[] price = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(decimal.Parse)
                 .ToArray();
            string input = Console.ReadLine();
            while (input != "done")
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (input == products[i])
                    {
                        Console.WriteLine($"{products[i]} costs: {price[i]}; Available quantity: {quantity[i]}");
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
