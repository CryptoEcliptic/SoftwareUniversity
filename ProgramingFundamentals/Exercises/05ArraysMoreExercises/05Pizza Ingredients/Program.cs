using System;
using System.Collections.Generic;
using System.Linq;

namespace _05Pizza_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int length = int.Parse(Console.ReadLine());
            int count = 0;

            List<string> usedIngredients = new List<string>();

            for (int i = 0; i < ingredients.Length && count < 10; i++)
            {
                if (ingredients[i].Length == length)
                {
                    usedIngredients.Add(ingredients[i]);
                    Console.WriteLine($"Adding {ingredients[i]}.");
                    count++;
                }
            }
            Console.WriteLine($"Made pizza with total of {count} ingredients.");
            Console.WriteLine($"The ingredients are: { string.Join(", ", usedIngredients)}.");
        }
    }
}
