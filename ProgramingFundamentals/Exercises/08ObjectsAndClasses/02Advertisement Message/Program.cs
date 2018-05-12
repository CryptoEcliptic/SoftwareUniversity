using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            String[] events = new string[] { "Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!" };
            String[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            String[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random phrase = new Random();
            Random event1 = new Random();
            Random author = new Random();
            Random town = new Random();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int phraseIndex = phrase.Next(0, phrases.Length);
                int eventIndex = event1.Next(0, events.Length);
                int authorIndex = author.Next(0, authors.Length);
                int citiesIndex = town.Next(0, cities.Length);
                Console.WriteLine($"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} - {cities[citiesIndex]}");
            }
        }
    }
}
