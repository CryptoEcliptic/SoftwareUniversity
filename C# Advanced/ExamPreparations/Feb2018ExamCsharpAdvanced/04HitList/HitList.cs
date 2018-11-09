using System;
using System.Collections.Generic;
using System.Linq;

namespace _04HitList
{
    class HitList
    {
        static void Main(string[] args)
        {
            var peopleData = new Dictionary<string, Dictionary<string, string>>();
            int targetInfoIndex = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] personInfo = input
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = personInfo[0];
                string[] keysAndValues = personInfo[1]
                    .Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                FillDictionary(peopleData, name, keysAndValues);

                input = Console.ReadLine();
            }
            string[] targetKill = Console.ReadLine().Split(' ');
            string targertName = targetKill[1];
            int infoIndex = 0;
            foreach (var person in peopleData.Where(x => x.Key == targertName))
            {
                Console.WriteLine($"Info on {person.Key}:");
                foreach (var personalData in person.Value.OrderBy(x => x.Key))
                {
                    infoIndex += personalData.Key.Length + personalData.Value.Length;
                    Console.WriteLine($"---{personalData.Key}: {personalData.Value}");
                }
            }
            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                int difference = targetInfoIndex - infoIndex;
                Console.WriteLine($"Need {difference} more info.");
            }
        }

        private static void FillDictionary(Dictionary<string, Dictionary<string, string>> peopleData, string name, string[] keysAndValues)
        {
            if (!peopleData.ContainsKey(name))
            {
                peopleData.Add(name, new Dictionary<string, string>());

                for (int i = 0; i < keysAndValues.Length - 1; i++)
                {
                    string innerKey = keysAndValues[i];
                    string innerValue = keysAndValues[i + 1];
                    if (!peopleData[name].ContainsKey(innerKey))
                    {
                        peopleData[name].Add(innerKey, innerValue);
                    }
                    else
                    {
                        peopleData[name][innerKey] = innerValue;
                    }
                    i++;
                }
            }
            else
            {
                for (int i = 0; i < keysAndValues.Length - 1; i++)
                {
                    string innerKey = keysAndValues[i];
                    string innerValue = keysAndValues[i + 1];
                    if (!peopleData[name].ContainsKey(innerKey))
                    {
                        peopleData[name].Add(innerKey, innerValue);
                    }
                    else
                    {
                        peopleData[name][innerKey] = innerValue;
                    }
                    i++;
                }
            }
        }
    }
}
