using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07SalesReport
{
    class Program
    {

        static void Main(string[] args)
        {
            int numberLines = int.Parse(Console.ReadLine());

            var sales = new SortedDictionary<string, List <Sales>>();

            for (int i = 0; i < numberLines; i++)
            {
                var currentSale = ReadSale();
                if (!sales.ContainsKey(currentSale.Town))
                {
                    sales[currentSale.Town] = new List<Sales>();
                }
                sales[currentSale.Town].Add(currentSale);

            }
            foreach (var townSales in sales)
            {
                var town = townSales.Key;
                var sumOfSales = townSales.Value.Sum(s => s.Price * (decimal)s.Quantity);
                Console.WriteLine($"{town} -> {sumOfSales:f2}");
            }
        }
        static Sales ReadSale()
        {
            var saleInput = Console.ReadLine().Split(' ');
            return new Sales
            {
                Town = saleInput[0],
                Product = saleInput[1],
                Price = decimal.Parse(saleInput[2]),
                Quantity = double.Parse(saleInput[3])
            };

        }
    }
}
