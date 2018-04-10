using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04TouristInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string unit = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());
            double outputValue = 0;
            string outputUnit = null;
            switch (unit)
            {
                case "miles":
                    outputUnit = "kilometers";
                    outputValue = value * 1.6;
                    break;
                case "inches":
                    outputUnit = "centimeters";
                    outputValue = value * 2.54;
                    break;
                case "feet":
                    outputUnit = "centimeters";
                    outputValue = value * 30;
                    break;
                case "yards":
                    outputUnit = "meters";
                    outputValue = value * 0.91;
                    break;
                case "gallons":
                    outputUnit = "liters";
                    outputValue = value * 3.8;
                    break;
            }
            Console.WriteLine($"{value} {unit} = {outputValue:f2} {outputUnit}");
        }
    }
}
