using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06CalculateTriangleArea
{
    class Program
    {
        static double TriangleArea(double width, double height)
        {
            double area = (width * height) / 2;
            return area;
        }
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = TriangleArea(width, height);
            Console.WriteLine(area);
        }
    }
}
