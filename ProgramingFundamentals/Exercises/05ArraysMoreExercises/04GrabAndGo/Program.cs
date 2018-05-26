using System;
using System.Linq;

namespace _04GrabAndGo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int keyNumber = int.Parse(Console.ReadLine());
            int countNumbers = 0;
            
            long sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == keyNumber)
                {
                    countNumbers = i;
                }
            }
            for (int i = 0; i < countNumbers; i++)
            {
                sum += input[i];
            }
            if (countNumbers >= 1)
            {
                Console.WriteLine(sum);
            }
            else if (countNumbers == 0)
            {
                Console.WriteLine("No occurrences were found!");
            }

        }
    }
}
    