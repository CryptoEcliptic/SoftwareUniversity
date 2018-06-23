using System;
using System.Collections.Generic;
using System.Linq;

namespace _02MemoryView
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = null;

            while (input != "Visual Studio crash")
            {
                result += input + " ";
                input = Console.ReadLine();
            }

            string[] numbersString = result.Split(' ').ToArray(); ;

            List<string> words = new List<string>();
            for (int i = 0; i < numbersString.Length - 5; i++)
            {
                if (numbersString[i] == "32656" && numbersString[i + 1] == "19759" && numbersString[i + 2] == "32763"
                    && numbersString[i + 3] == "0" && numbersString[i + 5] == "0")
                {
                    int currentLength = int.Parse(numbersString[i + 4]);
                    string currentWord = null;

                    for (int j = i + 6; j <= i + 6 + currentLength; j++)
                    {
                        currentWord += (char)int.Parse(numbersString[j]);

                    }
                    words.Add(currentWord);
                }
            }
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }

        }
    }
}

