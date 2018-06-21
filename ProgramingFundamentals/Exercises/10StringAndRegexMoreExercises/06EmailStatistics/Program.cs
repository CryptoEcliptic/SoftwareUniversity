using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06EmailStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> emailData = new Dictionary<string, List<string>>();
            int numberInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInputs; i++)
            {
                string inputText = Console.ReadLine();
                string pattern = @"^(?<user>[A-Za-z]{5,})@(?<domain>[a-z]{3,}\.[com|bg|org]+)$";
                Match validMail = Regex.Match(inputText, pattern);
                string userName = validMail.Groups["user"].Value;
                string domain = validMail.Groups["domain"].Value;

                if (validMail.Success)
                {
                    if (!emailData.ContainsKey(domain))
                    {
                        List<string> current = new List<string>();
                        current.Add(userName);
                        emailData.Add(domain, current);
                    }
                    else
                    {
                        if (!emailData[domain].Contains(userName))
                        {

                            emailData[domain].Add(userName);
                        }
                    }
                }
            }
            foreach (var item in emailData.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var user in item.Value)
                {
                    Console.WriteLine($"### {user}");
                }
            }
        }
    }
}
