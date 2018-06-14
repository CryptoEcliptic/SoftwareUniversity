using System;
using System.Collections.Generic;
using System.Linq;

namespace _04SupermarketDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputProducts = Console.ReadLine().Split(' ').ToArray();
            Dictionary<string, Dictionary<double, int>> stock = new Dictionary<string, Dictionary<double, int>>();

            while (inputProducts[0] != "stocked")
            {
                string product = inputProducts[0];
                double price = double.Parse(inputProducts[1]);
                int quantity = int.Parse(inputProducts[2]);
                if (!stock.ContainsKey(product))
                {
                    Dictionary<double, int> current = new Dictionary<double, int>();
                    current.Add(price, quantity);
                    stock.Add(product, current);
                }
                else
                {
                    if (stock.ContainsKey(product))
                    {
                        stock[product].Add(price, quantity);
                    }
                }

                inputProducts = Console.ReadLine().Split(' ').ToArray();
            }
            double totalValue = 0;
            foreach (var products in stock)
            {
                double prices = products.Value.Keys.Last();
                int quantities = products.Value.Values.Sum();
                double productValue = prices * quantities;
                Console.WriteLine($"{products.Key}: ${prices:f2} * {quantities} = ${productValue:f2}");

                totalValue += productValue;
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${totalValue:f2}");
        }
    }
}
