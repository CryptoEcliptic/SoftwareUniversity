using System;
using System.Collections.Generic;
using System.Linq;

namespace _02CryptoMaster
{
    class CryptoMaster
    {
        static void Main(string[] args)
        {
            //"1, -2, -3, 4, -5, 6, -7, -8";
            //"1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0";
            int[] inputNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int longestSequence = 1;
            
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                
                for (int j = 1; j < inputNumbers.Length; j++)
                {
                    int currentIndex = i;
                    int nextIndex = (currentIndex + j) % inputNumbers.Length;
                    int currentSequence = 1;

                    while (inputNumbers[currentIndex] < inputNumbers[nextIndex])
                    {
                        currentSequence++;
                        if (currentSequence > longestSequence)
                        {
                            longestSequence = currentSequence;
                        }
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + j) % inputNumbers.Length;
                    }     
                }
            }
            Console.WriteLine(longestSequence);
        }
    }
}
