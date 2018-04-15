using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFigure = Console.ReadLine().ToLower();

            if (typeFigure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double triangleArea = (height * side) / 2;
                Console.WriteLine($"{triangleArea:f2}");
            }
            else if (typeFigure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double squareArea = side * side;
                Console.WriteLine($"{squareArea:f2}");
            }
            else if (typeFigure == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double rectangleArea = width * height;
                Console.WriteLine($"{rectangleArea:f2}");
            }
            else if (typeFigure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double circleArea = Math.PI * (radius * radius);
                Console.WriteLine($"{circleArea:f2}");
            }

        }
    }
}
