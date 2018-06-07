using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([A-Z]{2})([\d]*\.[\d]*)([A-Za-z]+)\|";
            Dictionary<string, Weather> weatherCollection = new Dictionary<string, Weather>();

            while (input != "end")
            {
               var weatherPattern = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string city = weatherPattern.Groups[1].ToString();
                    string averageTemperatures = weatherPattern.Groups[2].ToString();
                    string weatherType = weatherPattern.Groups[3].ToString();

                    Weather dataWeather = new Weather();
                    dataWeather.Temperature = double.Parse(averageTemperatures);
                    dataWeather.TypeWeather = weatherType;
                    weatherCollection[city] = dataWeather; //Adding city once. Then changing only the values
                   
                }
                input = Console.ReadLine();
            }
            foreach (var weather in weatherCollection.OrderBy(x=> x.Value.Temperature))
            {
                Console.WriteLine($"{weather.Key} => {weather.Value.Temperature:f2} => {weather.Value.TypeWeather} ");
            }
        }
    }
}
