using System;
using System.Linq;

namespace _04MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputParams = Console.ReadLine()
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int lines = inputParams[0];
            int columns = inputParams[1];

            int[,] matrix = new int[lines, columns];
            int[,] internalMatrix = new int[3, 3];
            int bestSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine()
                   .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int[,] currentMatrix = new int[3, 3];
                    int currentSum = 0;

                    for (int i = row; i <= row + 2; i++)
                    {
                        for (int j = col; j <= col + 2; j++)
                        {
                            currentMatrix[i - row, j - col] = matrix[i, j];
                            currentSum = currentSum + currentMatrix[i - row, j - col];

                            if (currentSum > bestSum)
                            {
                                bestSum = currentSum;
                                internalMatrix = currentMatrix;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");
            for (int row = 0; row < internalMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < internalMatrix.GetLength(1); col++)
                {
                    Console.Write(internalMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
