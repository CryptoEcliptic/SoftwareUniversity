using System;
using System.Linq;

namespace _07Hideout
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool hasFound = false;
            int maxCount = 0;
            int maxPosition = 0;
            while (true)
            {
                if (hasFound == true)
                {
                    break;
                }
                string[] elements = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                char searchedSymbol = char.Parse(elements[0]);
                int number = int.Parse(elements[1]);

                int position = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == searchedSymbol)
                    {
                        position = i;
                        int actualCount = 0;
                        for (int j = i; j < input.Length; j++)
                        {
                            if (input[j] != searchedSymbol)
                            {
                                break;
                            }
                            actualCount++;
                            if (actualCount > maxCount)
                            {
                                maxCount = actualCount;
                                maxPosition = position;
                            }
                            if (maxCount >= number)
                            {
                                hasFound = true;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Hideout found at index {maxPosition} and it is with size {maxCount}!");
        }
    }
}
