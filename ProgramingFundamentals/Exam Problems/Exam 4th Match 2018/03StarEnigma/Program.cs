using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());

            string star = @"[sStTaArR]";
            string messagePattern = @"@(?<planet>[a-zA-Z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>[AD])![^@\-!:>]*->(?<soldiers>\d+)";
            var planets = new SortedDictionary<string, List<string>>();

            planets.Add("A", new List<string>());
            planets.Add("D", new List<string>());

            for (int currentMessage = 0; currentMessage < messagesCount; currentMessage++)
            {
                string message = Console.ReadLine();

                int key = 0;
                StringBuilder newMessage = new StringBuilder();

                foreach (Match starMatch in Regex.Matches(message, star))
                {
                    key++;
                }

                foreach (char symbol in message)
                {
                    newMessage.Append(Convert.ToChar(symbol - key));
                }

                string decodedMessage = newMessage.ToString();
                Match validMessage = Regex.Match(decodedMessage, messagePattern);

                if (validMessage.Success)
                {
                    string attackType = validMessage.Groups["attackType"].Value;
                    string planet = validMessage.Groups["planet"].Value;

                    planets[attackType].Add(planet);
                }
            }

            foreach (var pair in planets)
            {
                if (pair.Key == "A")
                {
                    Console.WriteLine($"Attacked planets: {pair.Value.Count}");
                }
                else
                {
                    Console.WriteLine($"Destroyed planets: {pair.Value.Count}");
                }

                foreach (string planet in pair.Value.OrderBy(p => p))
                {
                    Console.WriteLine($"-> {planet}");
                }

            }
        }
    }
}
