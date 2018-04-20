using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int totalSequence = 0;
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int currentSequence = 0;

                for (int j = i; j < numbers.Length; j++)
                {
                    if (currentNumber == numbers[j])
                    {
                        currentSequence++;
                        if (currentSequence > totalSequence)
                        {
                            totalSequence = currentSequence;
                            result = currentNumber;
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
