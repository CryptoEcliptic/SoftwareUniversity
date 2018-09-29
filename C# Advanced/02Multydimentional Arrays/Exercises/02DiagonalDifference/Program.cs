using System;
using System.Linq;
using System.Collections.Generic;

namespace _02DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeMatrix, sizeMatrix];
            int sumPrimary = 0;
            int sumSecondary = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().
                    Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    sumPrimary += matrix[i, j];
                    break;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(0) - i - 1; j >= 0; j--)
                {
                    sumSecondary += matrix[i, j];
                    break;
                }
            }
            int absoluteDifference = Math.Abs(sumPrimary - sumSecondary);
            Console.WriteLine(absoluteDifference);
        }
    }
}
