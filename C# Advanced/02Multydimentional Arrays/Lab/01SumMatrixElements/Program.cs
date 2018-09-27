using System;
using System.Linq;

namespace MultyDimentionalArraysLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLines = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None)
                 .Select(int.Parse)
                 .ToArray();

            int[,] matrix = new int[inputLines[0], inputLines[1]];

            for (int i = 0; i < inputLines[0]; i++)
            {
                int[] rowValues = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < inputLines[1]; j++)
                {
                    matrix[i, j] = rowValues[j];
                }
            }
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
