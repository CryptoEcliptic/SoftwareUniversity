using System;

namespace _05DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier dates = new DateModifier(startDate, endDate);

            dates.CalculateDifference();
        }
    }
}
