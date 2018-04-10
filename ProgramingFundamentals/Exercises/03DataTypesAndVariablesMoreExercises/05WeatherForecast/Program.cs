using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberText = Console.ReadLine();
            string weather = null;
            try
            {
                sbyte.Parse(numberText);
                weather = "Sunny";
            }
            catch (Exception)
            {
                try
                {
                    int.Parse(numberText);
                    weather = "Cloudy";
                }
                catch (Exception)
                {
                    try
                    {
                        long.Parse(numberText);
                        weather = "Windy";
                    }
                    catch (Exception)
                    {
                        decimal.Parse(numberText);
                        weather = "Rainy";
                    }
                }
            }
            Console.WriteLine(weather);
        }
    }
}
