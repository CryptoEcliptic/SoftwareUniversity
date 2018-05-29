using System;
using System.Linq;

namespace _08UpgradedMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ');
            long[] quantityInput = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            long[] quantity = new long[products.Length];
            for (int i = 0; i < quantityInput.Length; i++)
            {
                quantity[i] = quantityInput[i];
            }
            while (true)
            {
                string[] element = Console.ReadLine().Split(' ');
                if (element[0] == "done")
                {
                    break;
                }
                long neededQuantity = long.Parse(element[1]);
                int indexElement = Array.IndexOf(products, element[0]);
                if (neededQuantity <= quantity[indexElement])
                {
                    decimal totalPrice = neededQuantity * prices[indexElement];
                    Console.WriteLine($"{products[indexElement]} x {neededQuantity} costs {totalPrice:f2}");
                    quantity[indexElement] = quantity[indexElement] - neededQuantity;
                }
                else
                {
                    Console.WriteLine($"We do not have enough {products[indexElement]}");
                }
            }
        }
    }
}
