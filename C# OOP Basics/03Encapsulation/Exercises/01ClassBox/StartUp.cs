using System;

namespace _01ClassBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = new Box(length, width, height);
            box.CalculateLateralSurface();
            box.CalculateSurface();
            box.CalculateVolume();

            Console.WriteLine(box.ToString());
        }
    }
}
