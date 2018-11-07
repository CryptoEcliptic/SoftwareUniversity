using System;
using System.Collections.Generic;
using System.Linq;

namespace _11PartyReservationFilterModule
{
    class PRFM
    {
        static void Main(string[] args)
        {
            var guestsNames = Console.ReadLine()
                  .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                  .ToList();

            
            string input = Console.ReadLine();
            List<string> filters = new List<string>();

            while (input != "Print")
            {
                var commands = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Add filter")
                {
                    filters.Add(commands[1] + " " + commands[2]);
                }
                else if (commands[0] == "Remove filter")
                {
                    filters.Remove(commands[1] + " " + commands[2]);
                }      
                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                var commands = filter.Split(' ');
                string criteria = commands[0];
                string element = commands[commands.Length - 1];
                if (criteria == "Starts")
                {
                    guestsNames = guestsNames.Where(x => !x.StartsWith(element)).ToList();

                }
                else if (criteria == "Ends")
                {
                    guestsNames = guestsNames.Where(x => !x.EndsWith(element)).ToList();

                }
                else if (criteria == "Length")
                {
                    int length = int.Parse(element);
                    guestsNames = guestsNames.Where(x => x.Length != length).ToList();
                }
                else if (criteria == "Contains")
                {
                    guestsNames = guestsNames.Where(x => !x.Contains(element)).ToList();
                }
            }

            if (guestsNames.Any())
            {
                Console.WriteLine(string.Join(" ", guestsNames));
            }
            
        }
    }
}
