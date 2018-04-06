using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            float distanceMeters = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float totalTimeSeconds = (hours * 3600) + (minutes * 60) + seconds; //What is the total time in seconds. Used for calculation spped m/s.
            float totalHours = hours + (minutes / 60) + (seconds / 3600); // real number for total time in hours. Used for speed Per Hour.
            float speedMetersPerSecond = distanceMeters / totalTimeSeconds;
            float speedKilometersPerHour = (distanceMeters / 1000) / totalHours;
            float speedMilesPerHour = (distanceMeters / 1609) / totalHours;

            Console.WriteLine(speedMetersPerSecond);
            Console.WriteLine(speedKilometersPerHour);
            Console.WriteLine(speedMilesPerHour);
        }
    }
}
