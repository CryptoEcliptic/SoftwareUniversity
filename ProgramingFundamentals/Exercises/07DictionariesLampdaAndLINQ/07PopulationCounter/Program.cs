using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split('|').ToArray();

            Dictionary<string, Dictionary<string, long>> countryData = new Dictionary<string, Dictionary<string, long>>();
            string country = null;
            string city = null;
            long totalPopulation = 0;
            long cityPopulation = 0;

            while (inputData[0] != "report")
            {
                city = inputData[0];
                country = inputData[1];
                cityPopulation = long.Parse(inputData[2]);

                if (!countryData.ContainsKey(country))
                {
                    Dictionary<string, long> currentCity = new Dictionary<string, long>();
                    currentCity.Add(city, cityPopulation);
                    countryData.Add(country, currentCity);
                }
                else
                {
                    if (!countryData[country].ContainsKey(city))
                    {
                        countryData[country].Add(city, cityPopulation);
                    }
                }
                inputData = Console.ReadLine().Split('|').ToArray();
            }
            foreach (var information in countryData.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{information.Key} (total population: {information.Value.Values.Sum()})");

                foreach (var cityInfo in information.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{cityInfo.Key}: {cityInfo.Value}");
                }
            }
        }
    }
}
