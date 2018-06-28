using System;
using System.Collections.Generic;
using System.Linq;

namespace _04AnonymousCache
{
    class Program
    {
        static void Main(string[] args)
        {
            //90 points judge
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> dataCollection = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, Dictionary<string, long>> cash = new Dictionary<string, Dictionary<string, long>>();

            while (input != "thetinggoesskrra")
            {
                string dataSet = input;
                string dataKey = null;
                int dataSize = 0;
                if (input.Contains("->"))
                {
                    string[] inputInfo = input
                        .Split("->| ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    dataKey = inputInfo[0];
                    dataSize = int.Parse(inputInfo[1]);
                    dataSet = inputInfo[2];
                }
                if (!dataCollection.ContainsKey(dataSet) && dataKey == null)
                {
                    dataCollection.Add(dataSet, new Dictionary<string, long>());
                }

                else if (dataCollection.ContainsKey(dataSet) && !dataCollection[dataSet].ContainsKey(dataKey))
                {
                    dataCollection[dataSet].Add(dataKey, dataSize);
                }

                if (!dataCollection.ContainsKey(dataSet) && dataKey != null)
                {
                    if (!cash.ContainsKey(dataSet))
                    {
                        Dictionary<string, long> current = new Dictionary<string, long>();
                        current.Add(dataKey, dataSize);
                        cash.Add(dataSet, current);
                    }
                    else
                    {
                        cash[dataSet].Add(dataKey, dataSize);
                    }
                }
                bool hasMatch = false;
                foreach (var item in dataCollection.Keys) //compare the keys of the two different dictionaries by foreaching dict.Keys
                {
                    if (cash.ContainsKey(item))
                    {
                        hasMatch = true;
                    }
                }
                if (hasMatch)
                {
                    dataCollection[dataSet] = cash[dataSet]; //the main dictionary accepts other dictionary key and value
                }

                input = Console.ReadLine();
            }
            KeyValuePair<string, Dictionary<string, long>> result = dataCollection.OrderByDescending(x => x.Value.Sum(d => d.Value)).First();
            //First order by descending ant then prinring the first value (the greater one)
            Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Sum(x => x.Value)}");

            foreach (var kvp in result.Value)
            {
                Console.WriteLine($"$.{kvp.Key}");
            }

        }
    }
}
