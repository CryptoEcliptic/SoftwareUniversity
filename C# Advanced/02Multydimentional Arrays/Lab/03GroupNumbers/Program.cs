using System;
using System.Linq;

namespace _03GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] size = new int[3];
            foreach (var number in numbers)
            {
                size[Math.Abs(number % 3)]++;
            }

            int[][] jagged = new int[3][];
            for (int i = 0; i < size.Length; i++)
            {
                jagged[i] = new int[size[i]];
            }

            int[] index = new int[3];
            foreach (var number in numbers)
            {
                int reminder = Math.Abs(number % 3);
                jagged[reminder][index[reminder]] = number;
                index[reminder]++;
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
