using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Salaty
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseSalary = double.Parse(Console.ReadLine());
            int wotkTime = int.Parse(Console.ReadLine());
            string syndicate = Console.ReadLine().ToLower();
            double currentSalary = baseSalary;

            for (int i = 1; i <= 1000; i++)
            {
                currentSalary = currentSalary * 1.06;
                if (i % 10 == 5)
                {
                    currentSalary += 100;
                }
                else if (i % 10 == 0)
                {
                    currentSalary += 200;
                }
                if (syndicate == "yes")
                {
                    currentSalary *= 0.99;
                }
                if (currentSalary <= 5000 && i == wotkTime)
                {
                    Console.WriteLine($"Current salary: {currentSalary:f2}");
                }
                else if (currentSalary >= 5000 && i <= wotkTime)
                {
                    Console.WriteLine("Current salary: 5000.00");
                    Console.WriteLine("0 more years to max salary.");
                    break;
                }
                if (currentSalary >= 5000)
                {
                    Console.WriteLine("{0} more years to max salary.", i - 1 - wotkTime);
                    break;
                }
            }
        }
    }
}
