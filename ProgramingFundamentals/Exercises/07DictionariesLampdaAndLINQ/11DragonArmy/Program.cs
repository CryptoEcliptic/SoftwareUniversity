using System;
using System.Collections.Generic;
using System.Linq;

namespace _10DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInputs = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, List<double>>> dragonStatus = new Dictionary<string, SortedDictionary<string, List<double>>>();

            for (int i = 0; i < numberInputs; i++)
            {
                string[] input = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
                string type = input[0];
                string name = input[1];
                double damage = input[2].Equals("null") ? 45 : double.Parse(input[2]);
                double health = (input[3].Equals("null")) ? 250 : double.Parse(input[3]);
                double armor = (input[4].Equals("null")) ? 10 : double.Parse(input[4]);

                List<double> stats = new List<double>();
                stats.Add(damage);
                stats.Add(health);
                stats.Add(armor);

                if (!dragonStatus.ContainsKey(type))
                {
                    SortedDictionary<string, List<double>> current = new SortedDictionary<string, List<double>>();
                    current.Add(name, stats);
                    dragonStatus.Add(type, current);
                }
                else
                {
                    if (!dragonStatus[type].ContainsKey(name))
                    {
                        dragonStatus[type].Add(name, stats);
                    }
                    else if (dragonStatus[type].ContainsKey(name))
                    {
                        dragonStatus[type][name] = stats;
                    }
                }
            }
            foreach (var type in dragonStatus)
            {
                double dmg = 0;
                double hlth = 0;
                double arm = 0;
                SortedDictionary<string, List<double>> nameWithStats = dragonStatus[type.Key];
                foreach (var inner in nameWithStats)
                {
                    dmg += nameWithStats[inner.Key][0];
                    hlth += nameWithStats[inner.Key][1];
                    arm += nameWithStats[inner.Key][2];
                }
                Console.WriteLine($"{type.Key}::({(dmg / nameWithStats.Count):f2}/{(hlth / nameWithStats.Count):f2}/{(arm / nameWithStats.Count):f2})");

                foreach (var item in nameWithStats)
                {
                    Console.WriteLine($"-{item.Key} -> damage: {item.Value[0]}, health: {item.Value[1]}, armor: {item.Value[2]}");
                }
                
            }
        }
    }
}
