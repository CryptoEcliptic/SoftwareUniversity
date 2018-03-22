using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDays = int.Parse(Console.ReadLine());
            double startKilometers = double.Parse(Console.ReadLine());
            double currentKilometers = startKilometers;
            double finalKilometers = 0;
            for (int i = 1; i <= numberDays; i++)
            {
                int percentGrade = int.Parse(Console.ReadLine());
                currentKilometers = currentKilometers + ((currentKilometers * percentGrade) / 100);
                finalKilometers += currentKilometers;
            }
            finalKilometers += startKilometers; 
            if (finalKilometers < 1000)
            {
                Console.WriteLine("Sorry Mrs. Ivanova, you need to run {0} more kilometers", Math.Ceiling(1000 - finalKilometers));
            }
            else if (finalKilometers >= 1000)
            {
                Console.WriteLine("You've done a great job running {0} more kilometers!", Math.Ceiling(finalKilometers - 1000));
            }
        }
    }
}
