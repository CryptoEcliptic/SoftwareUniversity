using System;
using System.Collections.Generic;

namespace _01UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());
            HashSet<string> usernamesDb = new HashSet<string>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string username = Console.ReadLine();
                usernamesDb.Add(username);
            }

            foreach (var name in usernamesDb)
            {
                Console.WriteLine(name);
            }
        }
    }
}
