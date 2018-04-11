using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfKegs = int.Parse(Console.ReadLine());
            double biggestKegVolume = 0; // Temporary variable to accept the value of kegVolume
            double PI = Math.PI;
            string kegModel = ""; // Temporary variable to accept the value of currentKegModel
            for (int i = 1; i <= numberOfKegs; i++)
            {
                string currnetKegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                double kegHeight = double.Parse(Console.ReadLine());
                double kegVolume = PI * kegRadius * kegRadius * kegHeight;
                if (kegVolume > biggestKegVolume)
                {
                    biggestKegVolume = kegVolume;
                    kegModel = currnetKegModel;
                }
            }
            Console.WriteLine(kegModel);
        }
    }
}
