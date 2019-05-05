namespace _02RequestParser
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
           const string notFound = "{0} 404 NotFound\nContent-Length: {1}\nContent-Type: text/plain\n\nNotFound";
           const string successfullRequestMessage = "{0} 200 OK\nContent-Length: {1}\nContent-Type: text/plain\n\nOK";

            var paths = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] args = input.Split("/", StringSplitOptions.RemoveEmptyEntries);

                string path = args[0];
                string method = args[1];

                if (!paths.ContainsKey(path))
                {
                    paths.Add(path, new List<string>());
                }
                if (!paths[path].Contains(method))
                {
                    paths[path].Add(method);
                }

                input = Console.ReadLine();
            }

            string[] request = Console.ReadLine().Split(" ".ToCharArray());
            string requestMethod = request[0].ToLower();
            string requestedPath = request[1].TrimStart('/');
            string version = request[2];

            if (!paths.ContainsKey(requestedPath))
            {
                Console.WriteLine(notFound, version, "NotFound".Length);
                return;
            }
            if (!paths[requestedPath].Contains(requestMethod))
            {
                Console.WriteLine(notFound, version, "NotFound".Length);
                return;
            }

            Console.WriteLine(successfullRequestMessage, version, "OK".Length);
        }
    }
}
