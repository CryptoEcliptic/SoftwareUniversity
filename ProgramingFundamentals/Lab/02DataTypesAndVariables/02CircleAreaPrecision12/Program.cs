using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleAreaPrecision12
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double circleArea = (Math.PI * radius * radius);
            Console.WriteLine(Math.Round(circleArea, 12));
        }
    }
}
