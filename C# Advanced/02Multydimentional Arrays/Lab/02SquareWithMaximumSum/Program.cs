using System;
using System.Linq;

namespace _02SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                int[] lineInput = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = lineInput[j];
                }
            }
            int biggestSum = 0;
            int rowIndex = 0; int colindex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
                {
                    int tempSum = matrix[rows, columns] + matrix[rows, columns + 1] +
                        matrix[rows + 1, columns] + matrix[rows + 1, columns + 1];

                    if (tempSum > biggestSum)
                    {
                        biggestSum = tempSum;
                        rowIndex = rows;
                        colindex = columns;
                    }
                }
            }
            Console.WriteLine(matrix[rowIndex, colindex] + " " + matrix[rowIndex, colindex + 1]);
            Console.WriteLine(matrix[rowIndex + 1, colindex] + " " + matrix[rowIndex + 1, colindex + 1]);
            Console.WriteLine(biggestSum);
        }
    }
}
