using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine()) + 30;

            if (minutes >= 60)
            {
                hours++;
                minutes -= 60;
            }
            if (hours >= 24)
            {
                hours -= 24;
            }
            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}
