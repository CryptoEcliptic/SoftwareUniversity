using System;
using System.Collections.Generic;
using System.Linq;

namespace _02KaminoFactory
{
    class Program
    {       
        static void Main(string[] args)
        {
            //90% Result
            int lengthSequence = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            List<int[]> sequence = new List<int[]>();

            while (input != "Clone them!")
            {
                int[] dna = input.Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                if (dna.Length == lengthSequence)
                {
                    sequence.Add(dna);
                }

                input = Console.ReadLine();
            }

            int lengthDNA = 1;
            int maxLengthDNA = 1;
            int indexSequence = 0;
            int lineIndex = 0;
            int sequenceIndex = 0;
            int minSequenceIndex = 0;
            List<int> indexJ = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                indexSequence = i;
                int[] currentSequence = sequence[i];

                for (int j = 1; j < currentSequence.Length; j++)
                {
                    if (currentSequence[j] == 1 && currentSequence[j - 1] == 1)
                    {
                        lengthDNA++;
                    }

                    if (lengthDNA > maxLengthDNA)
                    {
                        maxLengthDNA = lengthDNA;
                        lineIndex = indexSequence;
                        minSequenceIndex = j - 1;

                    }
                    if (minSequenceIndex > sequenceIndex)
                    {
                        lineIndex = indexSequence;
                    }
                    lengthDNA = 1;
                }
            }
            int sum = sequence[lineIndex].Where(temp => temp.Equals(1))
                    .Select(temp => temp)
                    .Count();

            Console.WriteLine($"Best DNA sample {lineIndex + 1} with sum: {sum}.");
            Console.WriteLine(string.Join(" ", sequence[lineIndex]));
        }
    }
}
