using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _01DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateInput = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateInput, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);  
        }
    }
}
