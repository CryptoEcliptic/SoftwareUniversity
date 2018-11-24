using System;

namespace _02ClassBoxDataValidation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
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
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            

           
        }
    }
}
