using System;
using System.Collections.Generic;
using System.Linq;

namespace _05CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continentData =
                new Dictionary<string, Dictionary<string, List<string>>>();


            for (int i = 0; i < inputCount; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!continentData.ContainsKey(continent))
                {
                    Dictionary<string, List<string>> temporary = new Dictionary<string, List<string>>();
                    List<string> temp = new List<string>();
                    temp.Add(city);
                    temporary.Add(country, temp);
                    continentData.Add(continent, temporary);
                }
                else
                {
                    if (continentData.ContainsKey(continent))
                    {
                        if (!continentData[continent].ContainsKey(country))
                        {
                            List<string> temp = new List<string>();
                            temp.Add(city);
                            continentData[continent].Add(country, temp);

                        }
                        else if (continentData[continent].ContainsKey(country))
                        {
                            //if (!continentData[continent][country].Contains(city)) //With this check 1-4 test fails
                            //{ //Why??? With this if check negotiate the possibility of adding same city twice
                                continentData[continent][country].Add(city);
                            //}
                        }

                    }
                }
            }
            foreach (var continent in continentData)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($" {country.Key} -> ");
                    Console.WriteLine(string.Join(", ", country.Value));
                }
            }
        }
    }
}
