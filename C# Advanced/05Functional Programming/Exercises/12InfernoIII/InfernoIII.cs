using System;
using System.Collections.Generic;
using System.Linq;

namespace _12InfernoIII
{
    class InfernoIII
    {
        static void Main(string[] args)
        {
            var gems = Console.ReadLine()
                  .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();

            string input = Console.ReadLine();
            List<string> commands = new List<string>();
            while (input != "Forge")
            {
                var command = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Exclude")
                {
                    commands.Add(command[1] + " " + command[2]);
                }
                else if (command[0] == "Reverse")
                {
                    commands.RemoveAt(commands.Count - 1);
                }

                input = Console.ReadLine();
            }
            commands.Reverse();

            foreach (var com in commands)
            {
                string[] splitCommand = com.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = splitCommand[1];
                int value = int.Parse(splitCommand[splitCommand.Length - 1]);

                if (direction == "Right")
                {
                    for (int i = 0; i < gems.Count; i++)
                    {
                        if (i < gems.Count - 1 && gems[i] + gems[i + 1] == value)
                        {
                            gems.RemoveAt(i);
                            i--;
                        }
                        else if (i == gems.Count - 1 && gems[i] == value)
                        {
                            gems.RemoveAt(i);
                        }
                    }
                }
                else if (direction == "Left" && splitCommand[2] == "Right")
                {
                    for (int i = 1; i < gems.Count; i++)
                    {
                        if (i < gems.Count - 1 && gems[i] + gems[i - 1] + gems[i + 1] == value)
                        {
                            gems.Remove(gems[i]);
                        }

                        else if (i == gems.Count - 1 && gems[i] + gems[i - 1] == value)
                        {
                            gems.Remove(gems[i]);
                        }
                    }
                }
                else if (direction == "Left") 
                {
                    for (int i = 0; i < gems.Count; i++)
                    {
                        if (i == 0 && gems[i] == value)
                        {
                            gems.RemoveAt(i);
                            i--;
                        }
                        else if (i > 0 && gems[i] + gems[i - 1] == value)
                        {
                            gems.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", gems));
        }
    }
}
