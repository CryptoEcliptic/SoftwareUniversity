using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distanceFor1000flaps = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());


            int flapsPerSecond = 100;
            double distance = (wingFlaps / 1000) * distanceFor1000flaps;
            long timeInSeconds = wingFlaps / flapsPerSecond;
            long timeBreaks = (wingFlaps / endurance) * 5;
            long totalTime = timeInSeconds + timeBreaks;
            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{totalTime} s.");
        }
    }
}
