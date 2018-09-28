using System;
using System.Linq;

namespace _05PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            CreateAndFillMatrix(matrix);

            int sumDiagonals = 0;
            sumDiagonals = SumMatrixDiagonal(matrix, sumDiagonals);

            Console.WriteLine(sumDiagonals);
        }

        private static int SumMatrixDiagonal(int[,] matrix, int sumDiagonals)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    sumDiagonals += matrix[i, j];
                    break;
                }
            }

            return sumDiagonals;
        }

        private static void CreateAndFillMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = inputNumbers[j];
                }
            }
        }
    }
}
