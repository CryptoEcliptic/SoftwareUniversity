using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseSalary = double.Parse(Console.ReadLine());
            int timeService = int.Parse(Console.ReadLine());
            string syndicate = Console.ReadLine();

            double currentSalary = baseSalary;
            int year;
            for (year = 1; year <= timeService; year++)
            {
                currentSalary = currentSalary * 1.06;
                if (year % 10 == 5)
                {
                    currentSalary += 100;
                }
                else if (year % 10 == 0)
                {
                    currentSalary += 200;
                }
                if (syndicate == "Yes" && (year % 10 !=5 || year %10 != 0))
                {
                    currentSalary = currentSalary * 0.99;
                }
            }
            if (currentSalary >= 5000)
            {
                Console.WriteLine("Current salary: 5000.00");
                Console.WriteLine("0 more years to max salary.");
            }
            else if (currentSalary < 5000)
            {
                double toMaxSalary = currentSalary;
                while (toMaxSalary < 5000)
                {
                    toMaxSalary = toMaxSalary * 1.06;
                    if (year % 10 == 5)
                    {
                        toMaxSalary += 100;
                    }
                    else if (year % 10 == 0)
                    {
                        toMaxSalary += 200;
                    }
                    if (syndicate == "Yes" && (year % 10 != 5 || year % 10 != 0))
                    {
                        toMaxSalary = toMaxSalary * 0.99;
                    }
                    year++;
                }
                Console.WriteLine($"Current salary: {currentSalary:F2}");
                Console.WriteLine($"{year - 2 - timeService} more years to max salary.");
            }
        }
    }
}
