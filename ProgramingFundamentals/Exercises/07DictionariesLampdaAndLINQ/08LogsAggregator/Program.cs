using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesInput = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, int>> ipCollection = new SortedDictionary<string, SortedDictionary<string, int>>();
            string userName = null;
            string ipAdress = null;

            while (linesInput > 0)
            {
                string[] inputInfo = Console.ReadLine().Split(' ').ToArray();
                ipAdress = inputInfo[0];
                userName = inputInfo[1];
                int count = int.Parse(inputInfo[2]);

                if (!ipCollection.ContainsKey(userName))
                {
                    ipCollection.Add(userName, new SortedDictionary<string, int>());
                }

                if (!ipCollection[userName].ContainsKey(ipAdress))
                {
                    ipCollection[userName].Add(ipAdress, count);
                }
                else
                {
                    ipCollection[userName][ipAdress] += count;
                }
                linesInput--;
            }

            foreach (var kvp in ipCollection)
            {
                int totalCounts = ipCollection[kvp.Key].Values.Sum();
                List<string> listOfIp = kvp.Value.Keys.ToList();
                Console.WriteLine($"{kvp.Key}: {totalCounts} [{string.Join(", ", listOfIp)}]");
            }
        }
    }
}
