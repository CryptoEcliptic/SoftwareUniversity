using System;
using System.Linq;

namespace _09JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int position = 0;
            int sum = input[0];
            int currentIndex = input[0];

            while (true)
            {
                if (position + currentIndex < input.Length)
                {
                    position += currentIndex;
                }
                else if (position - currentIndex >= 0)
                {
                    position = position - currentIndex;
                }
                else
                {
                    break;
                }
                sum += input[position];
                currentIndex = input[position];
            }
            Console.WriteLine(sum);
        }
    }
}
