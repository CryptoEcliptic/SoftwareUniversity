using System;
using System.Collections.Generic;
using System.Linq;

namespace _04MobaChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dataPlayers = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] playInput = input
                    .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                    string player = playInput[0];
                    string position = playInput[1];
                    int skill = int.Parse(playInput[2]);

                    if (!dataPlayers.ContainsKey(player))
                    {
                        Dictionary<string, int> current = new Dictionary<string, int>();
                        current.Add(position, skill);
                        dataPlayers.Add(player, current);
                    }
                    else
                    {
                        if (dataPlayers.ContainsKey(player))
                        {
                            if (dataPlayers[player].Values.Max() < skill)
                            {
                                dataPlayers[player].Add(position, skill);
                            }
                            else
                            {
                                dataPlayers[player].Add(position, skill);
                            }

                        }
                    }

                }
                else if (input.Contains("vs"))
                {
                    string[] playInput = input
                   .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
                    string player1 = playInput[0];
                    string player2 = playInput[2];

                    if (dataPlayers.ContainsKey(player1) && dataPlayers.ContainsKey(player2))
                    {
                        bool hasCommonPosition = false;

                        foreach (var item in dataPlayers[player1])
                        {
                            if (dataPlayers[player2].ContainsKey(item.Key))
                            {
                                hasCommonPosition = true;
                            }
                        }
                        if (hasCommonPosition)
                        {
                            int player1Skills = dataPlayers[player1].Values.Sum();
                            int player2Skills = dataPlayers[player2].Values.Sum();

                            if (player1Skills > player2Skills)
                            {
                                dataPlayers.Remove(player2);
                            }
                            else if (player2Skills > player1Skills)
                            {
                                dataPlayers.Remove(player1);
                            }
                            
                        }
                        
                    }
                    else
                    {
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var players in dataPlayers.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{players.Key}: {players.Value.Values.Sum()} skill");

                foreach (var item in players.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }

            }
        }
    }
}
