using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, Vlogger>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string userName = tokens[0];
                string command = tokens[1];
                string joinedOrFollowed = tokens[2];
                if (command == "joined")
                {
                    if (!database.ContainsKey(userName))
                    {
                        Vlogger blogger = new Vlogger();
                        blogger.Following = new List<string>();
                        blogger.Followers = new List<string>();
                        database.Add(userName, blogger);
                    }
                }

                else if (command == "followed")
                {
                    if (database.ContainsKey(userName) && database.ContainsKey(joinedOrFollowed))
                    {
                        if (userName != joinedOrFollowed && !database[userName].Following.Contains(joinedOrFollowed))
                        {
                            database[userName].Following.Add(joinedOrFollowed);
                            database[joinedOrFollowed].Followers.Add(userName);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {database.Count} vloggers in its logs.");

            int count = 1;
            foreach (var user in database.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{count}. {user.Key} : {user.Value.Followers.Count} followers, {user.Value.Following.Count} following");

                if (count == 1)
                {
                    foreach (var item in user.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                count++;
            }
        }
    }

    public class Vlogger
    {
        public string Name;
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }

    }
}
