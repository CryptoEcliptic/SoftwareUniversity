using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05ClosestTwoPoints
{
   
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPoints = int.Parse(Console.ReadLine());
            var allPoints = new List<Point>(); //List for collenting all points
            var minDistance = double.MaxValue;
            Point firstMinPoint = null;
            Point secondMinPoint = null;

            for (int i = 0; i < numberOfPoints; i++) // Importing all points in the list allPoints.
            {
                var currentPoint = ReadPoint();
                allPoints.Add(currentPoint);
            }
            for (int i = 0; i < numberOfPoints; i++) //Nested loops for comparing distance between first and second point
            {
                for (int j = i+1; j < numberOfPoints; j++)
                {
                    var firstPoint = allPoints[i];
                    var secondPoint = allPoints[j];
                    var currentDistance = Distance(firstPoint, secondPoint);

                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        firstMinPoint = firstPoint;
                        secondMinPoint = secondPoint;
                    }
                }
            }
            Console.WriteLine($"{minDistance:f3}");
            Console.WriteLine(firstMinPoint.Display());
            Console.WriteLine(secondMinPoint.Display());

        }
        static Point ReadPoint() //Method for reading from the console X/Y
        {
            var input = Console.ReadLine().Split(' ');
            var point = new Point
            {
                X = int.Parse(input[0]),
                Y = int.Parse(input[1])
            };
            return point;

        }
        static double Distance (Point firstOne, Point secondOne) //Method for calculating distance between X and Y
        {
            var diffX = firstOne.X - secondOne.X;
            var powX = diffX * diffX;
            var diffY = firstOne.Y - secondOne.Y;
            var powY = diffY * diffY;
            double squareSide = powY + powX;
            double result = Math.Sqrt(squareSide);
            return result;
        }
    }
}
