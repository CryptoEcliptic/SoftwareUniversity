using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09SerbianUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            int price = 0;
            int tickets = 0;
            int income = 0;
            string venue;
            string performer;
            Dictionary<string, Dictionary<string, int>> concerts = new Dictionary<string, Dictionary<string, int>>();

            while (input[0] != "End")
            {
                if (!IsValidVenue(input))
                {
                    input = Console.ReadLine().Split(' ').ToArray();
                    continue;
                }
                int member = 0;
                List<string> singer = new List<string>();
                for (int i = 0; i < input.Length; i++)
                {
                    if (!input[i].StartsWith("@"))
                    {
                        singer.Add(input[i]);
                    }
                    else
                    {
                        member = i;
                        break;
                    }
                }
                performer = (string.Join(" ", singer));

                List<string> place = new List<string>();
                for (int i = member; i < input.Length - 2; i++)
                {
                    place.Add(input[i]);
                }
                venue = (string.Join(" ", place));
                venue = venue.Remove(0, 1);
                price = int.Parse(input[input.Length - 2]);
                tickets = int.Parse(input[input.Length - 1]);
                income = price * tickets;
                if (!concerts.ContainsKey(venue))
                {
                    Dictionary<string, int> currentConcert = new Dictionary<string, int>();
                    currentConcert.Add(performer, income);
                    concerts.Add(venue, currentConcert);
                }
                else
                {
                    if (!concerts[venue].ContainsKey(performer))
                    {
                        concerts[venue].Add(performer, income);
                    }
                    else
                    {
                        concerts[venue][performer] += income;
                    }
                }
                input = Console.ReadLine().Split(' ').ToArray();
            }

            foreach (var city in concerts)
            {
                Console.WriteLine($"{city.Key}");
                foreach (var concer in city.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {concer.Key} -> {concer.Value}");
                }
            }
        }
        static bool IsValidVenue(string[] text)
        {
            bool isValidVenue = false;
            int indexer = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].StartsWith("@"))
                {
                    isValidVenue = true;
                    indexer = i;
                }
            }
            if (indexer < 1 || indexer > 3)
            {
                isValidVenue = false;
            }
            if (indexer < text.Length - 5 || indexer > text.Length - 3)
            {
                isValidVenue = false;
            }
            try
            {
                int.Parse(text[text.Length - 1]);
                int.Parse(text[text.Length - 2]);
            }
            catch (Exception)
            {
                isValidVenue = false;
            }
            return isValidVenue;
        }
    }
}
