using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03Ticket_Trouble
{
    class TicketTrouble
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string inputText = Console.ReadLine();

            string pattern = @"(?=){.+(?<destination>\[[A-Z]{3} [A-Z]{2}\]).+(?<seat>\[[A-Z][0-9]{1,2}\]).+}
            |(?=)\[.+(?<destinat>{[A-Z]{3} [A-Z]{2}}).+(?<sets>{[A-Z][0-9]{1,2}}).+\]";
            var matches = Regex.Matches(inputText, pattern);
            

        }
    }
}
