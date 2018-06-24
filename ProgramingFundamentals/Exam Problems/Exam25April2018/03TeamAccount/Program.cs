using System;
using System.Collections.Generic;
using System.Linq;

namespace _03TeamAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gamesList = new List<string>();
            string[] games = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < games.Length; i++)
            {
                gamesList.Add(games[i]);
            }

            string input = Console.ReadLine();

            while (input != "Play!")
            {
                string[] inputText = input.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                string commands = inputText[0];
                string gameName = inputText[1];
                
                if (commands == "Install")
                {
                    if (!gamesList.Contains(gameName))
                    {
                        gamesList.Add(gameName);
                    }
                }
                else if (commands == "Uninstall")
                {
                    if (gamesList.Contains(gameName))
                    {
                        gamesList.Remove(gameName);
                    }
                }
                else if (commands == "Update")
                {
                    if (gamesList.Contains(gameName))
                    {
                        gamesList.Remove(gameName);
                        gamesList.Add(gameName);
                    }
                }
                else if (commands == "Expansion")
                {
                    if (gamesList.Contains(gameName))
                    {
                        gameName = inputText[1];
                        string expansion = inputText[2];
                        string gameExpansion = gameName + ":" + expansion;
                        int index = gamesList.IndexOf(gameName) + 1;
                        gamesList.Insert(index, gameExpansion);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", gamesList));
        }
    }
}
