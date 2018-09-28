using System;

namespace _06SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string inputChars = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = inputChars[j];
                }
            }

            char searchedSymbol = char.Parse(Console.ReadLine());
            int row = -1;
            int col = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (searchedSymbol == matrix[i, j])
                    {
                        row = i;
                        col = j;
                        Console.WriteLine($"({row}, {col})");
                        break;
                    }
                }
            }
            if (row < 0 && col < 0)
            {
                Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
            }
        }
    }
}
