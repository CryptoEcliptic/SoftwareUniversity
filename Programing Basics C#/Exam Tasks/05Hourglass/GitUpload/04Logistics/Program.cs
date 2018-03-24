using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCargos = int.Parse(Console.ReadLine());
            double weightTo3Tons = 0;
            double weightFrom4to11Tons = 0;
            double weightGreaterThan12Tons = 0;
            double price = 0;

            for (int i = 1; i <= numberOfCargos; i++)
            {
                int weight = int.Parse(Console.ReadLine());

                if (weight <= 3)
                {
                    weightTo3Tons += weight;
                    price += 200 * weight;
                }
                else if (weight >= 4 && weight <= 11)
                {
                    weightFrom4to11Tons += weight;
                    price += 175 * weight;
                }
                else if (weight >= 12)
                {
                    weightGreaterThan12Tons += weight;
                    price += 120 * weight;
                }
            }
            double totalWeight = weightTo3Tons + weightFrom4to11Tons + weightGreaterThan12Tons;

            Console.WriteLine($"{price / totalWeight:f2}");
            Console.WriteLine($"{(weightTo3Tons / totalWeight) * 100:f2}%");
            Console.WriteLine($"{(weightFrom4to11Tons / totalWeight) * 100:f2}%");
            Console.WriteLine($"{(weightGreaterThan12Tons / totalWeight) * 100:f2}%");
        }
    }
}
