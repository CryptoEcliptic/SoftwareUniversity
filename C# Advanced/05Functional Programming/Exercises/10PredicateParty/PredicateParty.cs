using System;
using System.Collections.Generic;
using System.Linq;

namespace _10PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                 .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();
            int guestsCount = guests.Count;
            string[] commands = Console.ReadLine()
                 .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            while (commands[0] != "Party!")
            {
                string action = commands[0].ToLower();
                string criteria = commands[1].ToLower();

                switch (action)
                {
                    case "remove":

                        RemovingGuests(guests, commands, criteria);

                        break;

                    case "double":
                        guestsCount = DoublingGuests(guests, commands, criteria);
                        break;
                    default:
                        break;
                }

                commands = Console.ReadLine()
                 .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            }
            //guests.Sort(); If sorting is applied First test fails. Without sorting zero test fails!!!
            if (guests.Any())
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
                
            }
           

        }

        private static int DoublingGuests(List<string> guests, string[] commands, string criteria)
        {
            int guestsCount = guests.Count;
            if (criteria == "startswith")
            {
                string startString = commands[2];
                for (int i = 0; i < guestsCount; i++)
                {
                    if (guests[i].StartsWith(startString))
                    {
                        guests.Add(guests[i]);
                    }
                }
            }

            else if (criteria == "endswith")
            {
                string endString = commands[2];
                for (int i = 0; i < guestsCount; i++)
                {
                    if (guests[i].EndsWith(endString))
                    {
                        guests.Add(guests[i]);
                    }
                }
            }

            else if (criteria == "length")
            {
                int length = int.Parse(commands[2]);
                for (int i = 0; i < guestsCount; i++)
                {
                    if (guests[i].Length == length)
                    {
                        guests.Add(guests[i]);

                    }
                }
            }

            return guestsCount;
        }

        private static void RemovingGuests(List<string> guests, string[] commands, string criteria)
        {
            if (criteria == "startswith")
            {
                string startString = commands[2];
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].StartsWith(startString))
                    {
                        guests.RemoveAt(i);
                        i--;
                    }
                }
            }
            else if (criteria == "endswith")
            {
                string endString = commands[2];
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].EndsWith(endString))
                    {
                        guests.RemoveAt(i);
                        i--;
                    }
                }
            }
            else if (criteria == "length")
            {
                int length = int.Parse(commands[2]);
                for (int i = 0; i < guests.Count; i++)
                {
                    if (guests[i].Length == length)
                    {
                        guests.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}
