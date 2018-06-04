using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputDate = Console.ReadLine();
            var pattern = @"\b(?<date>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            var formattedDate = Regex.Matches(inputDate, pattern);

            foreach (Match print in formattedDate)
            {
                var day = print.Groups["date"].Value;
                var month = print.Groups["month"].Value;
                var year = print.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
