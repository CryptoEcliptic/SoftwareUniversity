using System;
using System.Linq;

namespace _02ManipulateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = Console.ReadLine().Split(' ').ToArray();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string commands = Console.ReadLine();

                if (commands == "Distinct")
                {
                    inputText = inputText.Distinct().ToArray();
                }
                else if (commands == "Reverse")
                {
                    Array.Reverse(inputText);
                }
                else
                {
                    string[] replace = commands.Split(' ').ToArray(); //easy replacement

                    inputText[int.Parse(replace[1])] = replace[2];
                }
            }
            Console.WriteLine(string.Join(", ", inputText));
        }
    }
}
