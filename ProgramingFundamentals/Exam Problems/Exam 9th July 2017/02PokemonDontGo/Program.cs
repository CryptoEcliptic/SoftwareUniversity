using System;
using System.Collections.Generic;
using System.Linq;

namespace _02PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputSequence = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> result = new List<int>();
            int totalSum = 0;
            int elementKey = 0;

            while (inputSequence.Count > 0)
            {

                int indexes = int.Parse(Console.ReadLine());

                if (indexes < 0)
                {
                    elementKey = inputSequence[0];
                    result.Add(inputSequence[0]);
                    inputSequence[0] = inputSequence[inputSequence.Count - 1];
                }
                else if (indexes > inputSequence.Count - 1)
                {
                    elementKey = inputSequence[inputSequence.Count - 1];
                    result.Add(inputSequence[inputSequence.Count - 1]);
                    inputSequence[inputSequence.Count - 1] = inputSequence[0];
                }

                else
                {
                    elementKey = inputSequence[indexes];
                    result.Add(inputSequence[indexes]);
                    inputSequence.RemoveAt(indexes);
                }

                for (int i = 0; i < inputSequence.Count; i++)
                {
                    if (inputSequence[i] <= elementKey)
                    {
                        inputSequence[i] += elementKey;
                    }
                    else if (inputSequence[i] > elementKey)
                    {
                        inputSequence[i] = inputSequence[i] - elementKey;
                    }
                }
            }
            for (int i = 0; i < result.Count; i++)
            {
                totalSum += result[i];
            }
            Console.WriteLine(totalSum);
        }
    }
}
