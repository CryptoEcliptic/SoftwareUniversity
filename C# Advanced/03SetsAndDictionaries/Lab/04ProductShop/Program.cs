using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, double>> shopData = new Dictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                string[] shops = input.Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string store = shops[0];
                string product = shops[1];
                double price = double.Parse(shops[2]);

                if (!shopData.ContainsKey(store))
                {
                    Dictionary<string, double> products = new Dictionary<string, double>();
                    products.Add(product, price);
                    shopData.Add(store, products);
                }
                else
                {
                    if (shopData.ContainsKey(store))
                    {
                        shopData[store].Add(product, price);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var shop in shopData.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
