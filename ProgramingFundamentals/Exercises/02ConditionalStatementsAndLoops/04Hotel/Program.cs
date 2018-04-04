using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double doubleRoomPrice = 0;
            double suitePrice = 0;
            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                doubleRoomPrice = 65;
                suitePrice = 75;
                if (nightsCount > 7) studioPrice = 50 * 0.95;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 60;
                doubleRoomPrice = 72;
                suitePrice = 82;
                if (nightsCount > 14) doubleRoomPrice = 72 * 0.90;
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                studioPrice = 68;
                doubleRoomPrice = 77;
                suitePrice = 89;
                if (nightsCount > 14) suitePrice = 89 * 0.85;
            }
            studioPrice *= nightsCount;
            doubleRoomPrice *= nightsCount;
            suitePrice *= nightsCount;
            if (nightsCount > 7 && (month == "September" || month == "October")) studioPrice = studioPrice * (nightsCount - 1) / nightsCount;
            Console.WriteLine($"Studio: {studioPrice:f2} lv.\r\nDouble: {doubleRoomPrice:f2} lv.\r\nSuite: {suitePrice:f2} lv.");
           
        }
    }
}
