using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04MovieTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new Dictionary<string, Dictionary<string, int>>();
            int sumSecondsofAllMovies = 0;

            string preferedGenre = Console.ReadLine();
            string shortOrLong = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "POPCORN!")
            {
                string[] movie = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string movieName = movie[0];
                string genre = movie[1];
                string[] duration = movie[2].Split(":");
                int totalSeconds = ConvertDurationToSeconds(duration);
                sumSecondsofAllMovies += totalSeconds;

                FillingDictionary(movies, movieName, genre, totalSeconds);

                input = Console.ReadLine();
            }
            var formattedTimeOfAllMovies = TimeSpan.FromSeconds(sumSecondsofAllMovies);

            movies = movies
                .Where(x => x.Key == preferedGenre)
                .ToDictionary(x => x.Key, y => y.Value); //Leaving only the movies from the preffered genre.

            string desiredMovie = null;
            TimeSpan movieDuration = new TimeSpan();

            foreach (var movie in movies)
            {
                if (input == "Yes")
                {
                    break;
                }
                if (shortOrLong == "Short")
                {
                    OrderedPrinter(ref input, ref desiredMovie, ref movieDuration, movie);
                }
                else
                {
                    OrderedByDescendingPrinter(ref input, ref desiredMovie, ref movieDuration, movie);
                }
            }
            Console.WriteLine($"We're watching {desiredMovie} - {movieDuration}");
            Console.WriteLine($"Total Playlist Duration: {formattedTimeOfAllMovies}");
        }

        private static void OrderedByDescendingPrinter(ref string input, ref string desiredMovie, ref TimeSpan movieDuration, KeyValuePair<string, Dictionary<string, int>> movie)
        {
            foreach (var name in movie.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(name.Key);

                input = Console.ReadLine();
                if (input == "Yes")
                {
                    desiredMovie = name.Key;
                    movieDuration = TimeSpan.FromSeconds(name.Value);
                    break;
                }
            }
        }

        private static void OrderedPrinter(ref string input, ref string desiredMovie, ref TimeSpan movieDuration, KeyValuePair<string, Dictionary<string, int>> movie)
        {
            foreach (var name in movie.Value.OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(name.Key);

                input = Console.ReadLine();
                if (input == "Yes")
                {
                    desiredMovie = name.Key;
                    movieDuration = TimeSpan.FromSeconds(name.Value);
                    break;
                }
            }
        }

        private static int ConvertDurationToSeconds(string[] duration)
        {
            int hours = int.Parse(duration[0]);
            int minutes = int.Parse(duration[1]);
            int seconds = int.Parse(duration[2]);
            int totalSeconds = (seconds + (minutes * 60) + hours * 3600);
            return totalSeconds;
        }

        private static void FillingDictionary(Dictionary<string, Dictionary<string, int>> movies, string movieName, string genre, int duration)
        {
            if (!movies.ContainsKey(genre))
            {
                Dictionary<string, int> innerDict = new Dictionary<string, int>();
                innerDict.Add(movieName, duration);
                movies.Add(genre, innerDict);
            }
            else if (movies.ContainsKey(genre) && !movies[genre].ContainsKey(movieName))
            {
                movies[genre].Add(movieName, duration);
            }
        }
    }
}
