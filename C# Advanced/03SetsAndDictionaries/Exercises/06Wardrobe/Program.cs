using System;
using System.Collections.Generic;
using System.Linq;

namespace _06Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {

            int inputCount = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string colour = input[0];
                string[] clothesSameColour = input[1].Split(',').ToArray();


                if (!wardrobe.ContainsKey(colour))
                {
                    FillUniqueColours(wardrobe, clothesSameColour, colour);
                }
                else if (wardrobe.ContainsKey(colour))
                {
                    FillExistingColours(wardrobe, clothesSameColour, colour);
                }
            }
            string[] clotheToFind = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string colorToFind = clotheToFind[0];
            string typeClotheToFind = clotheToFind[1];
            PrintResult(wardrobe, colorToFind, typeClotheToFind);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, int>> wardrobe, string colorToFind, string typeClotheToFind)
        {
            foreach (var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes:");

                foreach (var clothe in colour.Value)
                {
                    if (colour.Key == colorToFind && clothe.Key == typeClotheToFind)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }
                }
            }
        }

        private static void FillExistingColours(Dictionary<string, Dictionary<string, int>> wardrobe, string[] input, string colour)
        {
            for (int j = 0; j < input.Length; j++)
            {
                string currentClothe = input[j];
                if (!wardrobe[colour].ContainsKey(currentClothe))
                {
                    wardrobe[colour].Add(currentClothe, 1);
                }
                else
                {
                    wardrobe[colour][currentClothe]++;
                }
            }
        }

        private static void FillUniqueColours(Dictionary<string, Dictionary<string, int>> wardrobe, string[] input, string colour)
        {
            Dictionary<string, int> temporary = new Dictionary<string, int>();
            for (int j = 0; j < input.Length; j++)
            {
                string currentClothe = input[j];
                if (!temporary.ContainsKey(currentClothe))
                {
                    temporary.Add(currentClothe, 1);
                }
                else
                {
                    temporary[currentClothe]++;
                }
            }
            wardrobe.Add(colour, temporary);
        }
    }
}
