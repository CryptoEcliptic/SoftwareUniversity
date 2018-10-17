using System;
using System.Collections.Generic;

namespace _04EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Dictionary<int, int> collectionNumbers = new Dictionary<int, int>();
            
            for (int i = 0; i < numberOfInputs; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                if (!collectionNumbers.ContainsKey(inputNumber))
                {
                    collectionNumbers.Add(inputNumber, 1);
                }
                else
                {
                    collectionNumbers[inputNumber]++;
                }
            }
            foreach (var num in collectionNumbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
