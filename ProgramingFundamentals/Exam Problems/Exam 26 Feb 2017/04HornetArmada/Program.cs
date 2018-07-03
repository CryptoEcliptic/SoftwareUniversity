using System;
using System.Linq;
using System.Collections.Generic;

namespace _04HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Legions> dataLegions = new Dictionary<string, Legions>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine()
                    .Split("=->: ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                long lastActivity = long.Parse(input[0]);
                string legion = input[1];
                string type = input[2];
                long count = long.Parse(input[3]);
                
                Legions currentLegion = new Legions();
                currentLegion.LastActivity = lastActivity;
                Dictionary<string, long> currentSoldiers = new Dictionary<string, long>();
                currentSoldiers.Add(type, count);
                currentLegion.Soldiers = currentSoldiers;

                if (!dataLegions.ContainsKey(legion))
                {
                    dataLegions.Add(legion, currentLegion);
                }

                else if (dataLegions.ContainsKey(legion))
                {
                    if (!dataLegions[legion].Soldiers.ContainsKey(type))
                    {
                        if (dataLegions[legion].LastActivity < lastActivity)
                        {
                            dataLegions[legion].LastActivity = lastActivity;
                        }

                        dataLegions[legion].Soldiers.Add(type, count);
                    }

                    else if (dataLegions[legion].Soldiers.ContainsKey(type))
                    {
                        if (dataLegions[legion].LastActivity < lastActivity)
                        {
                            dataLegions[legion].LastActivity = lastActivity;
                        }

                        dataLegions[legion].Soldiers[type] += count;
                    }
                }
            }
            string commands = Console.ReadLine();
            if (commands.Contains("\\"))
            {
                string[] inputCommand1 = commands
                    .Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                long givenActivity = long.Parse(inputCommand1[0]);
                string currentType = inputCommand1[1];


                Dictionary<string, long> found = new Dictionary<string, long>();

                foreach (var legions in dataLegions)
                {
                    long tempAcitvity = legions.Value.LastActivity;
                    if (givenActivity > tempAcitvity)
                    {
                        foreach (var item in legions.Value.Soldiers)
                        {
                            if (item.Key == currentType)
                            {
                                found.Add(legions.Key, item.Value);
                            }

                        }

                    }
                }

                foreach (var item in found.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }

            else
            {
                string soldierType = commands;

                foreach (var legion in dataLegions.OrderByDescending(x => x.Value.LastActivity))
                {
                    Console.WriteLine($"{legion.Value.LastActivity} : {legion.Key}");
                }
            }
        }
    }
    class Legions
    {
        public long LastActivity { get; set; }
        public Dictionary<string, long> Soldiers { get; set; }
    }
}
