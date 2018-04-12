using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05TemperatureConversion
{
    class Program
    {
        static double FarenheitToCelsius(double degrees)
        {
            double celsius = (degrees - 32) * 5 / 9;
            return celsius;
        }
        static void Main(string[] args)
        {
            double farenheit = double.Parse(Console.ReadLine());
            double celsius = FarenheitToCelsius(farenheit);
            Console.WriteLine($"{celsius:f2}");
        }
    }
}
