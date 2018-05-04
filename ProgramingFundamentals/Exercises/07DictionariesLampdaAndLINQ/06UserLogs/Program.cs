using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> site = new Dictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();
            string ipAdress = null;
            string user = null;

            while (input[0] != "end")
            {
                string[] ipInput = input[0].Split('=').ToArray();
                ipAdress = ipInput[1];
                string[] userInput = input[2].Split('=').ToArray();
                user = userInput[1];

                if (!site.ContainsKey(user))
                {
                    Dictionary<string, int> current = new Dictionary<string, int>();
                    current.Add(ipAdress, 1);
                    site.Add(user, current);
                }
                else
                {
                    if (!site[user].ContainsKey(ipAdress))
                    {
                        site[user].Add(ipAdress, 1);
                    }
                    else
                    {
                        site[user][ipAdress]++;
                    }
                }
                input = Console.ReadLine()
                .Split(' ')
                .ToArray();
            }
            foreach (var currentUser in site.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{currentUser.Key}: ");
                List<string> addingDots = new List<string>();
                foreach (var adress in currentUser.Value)
                {
                    addingDots.Add($"{adress.Key} => {adress.Value}");
                }
                Console.WriteLine(string.Join(", ", addingDots) + ".");
            }
        }
    }
}
