using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04DistanceBetweenPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(' ');
            var firstInputData = new Point
            {
                X = double.Parse(firstInput[0]),
                Y = double.Parse(firstInput[1])
            };

            var secondInput = Console.ReadLine().Split(' ');
            var secondInputData = new Point
            {
                X = double.Parse(secondInput[0]),
                Y = double.Parse(secondInput[1])
            };

            double distance = Distance(firstInputData, secondInputData);
            Console.WriteLine($"{distance:f3}");
        }
        public static double Distance(Point first, Point second)
        {
            var xDif = first.X - second.X;
            var xPow = xDif * xDif; 
            
            var yDif = first.Y - second.Y;
            var yPow = yDif * yDif;

            double sideC = xPow + yPow;
            double distance = Math.Sqrt(sideC);
            return distance;
        }
    }
}
