using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SinoTheWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InstalledUICulture);
            int numberSteps = int.Parse(Console.ReadLine()) % 86400; // if the input is more than a day. 1 day holds 86400 seconds
            int stepTime = int.Parse(Console.ReadLine()) % 86400;

            long travelTimeSeconds = numberSteps * stepTime;

            string arrivalTime = time.AddSeconds(travelTimeSeconds).ToString("HH:mm:ss");
            Console.WriteLine($"Time Arrival: {arrivalTime}");
        }
    }
}
