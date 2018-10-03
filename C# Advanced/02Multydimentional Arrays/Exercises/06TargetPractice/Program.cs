using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06TargetPractice
{
    class Program
    {
        private static int rows;
        private static int columns;

        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            rows = dimentions[0];
            columns = dimentions[1];

            var matrix = new char[rows, columns];

            var snake = Console.ReadLine().ToCharArray();
            var shotParams = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var impactRow = shotParams[0];
            var impactColumn = shotParams[1];
            var radius = shotParams[2];

            var snakeIndex = 0;

            FillMatrix(snakeIndex, snake, matrix);
            Shoot(impactRow, impactColumn, radius, matrix);
            StartFallin(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static void StartFallin(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                List<char> list = new List<char>();
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    if (matrix[row, col] != ' ')
                    {
                        list.Add(matrix[row, col]);
                    }
                }

                for (int i = list.Count; i < matrix.GetLength(0); i++)
                {
                    list.Add(' ');
                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, col] = list[list.Count - 1 - row];
                }
            }
        }

        private static void Shoot(int impactRow, int impactColumn, int radius, char[,] matrix)
        {
            matrix[impactRow, impactColumn] = ' ';
            //Calculate radius
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if ((row - impactRow) * (row - impactRow) + (col - impactColumn) * (col - impactColumn)
                        <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void FillMatrix(int snakeIndex, char[] snake, char[,] matrix)
        {

            for (int rowIndex = rows; rowIndex > 0; rowIndex--)
            {

                for (int colIndex = columns; colIndex > 0; colIndex--) //right to left
                {
                    if (snakeIndex <= snake.Length - 1)
                    {
                        matrix[rowIndex - 1, colIndex - 1] = snake[snakeIndex];
                        snakeIndex++;
                    }
                    else
                    {
                        colIndex++;
                        snakeIndex = 0;
                    }
                }

                //left to right
                rowIndex--;
                if (rowIndex == 0)
                {
                    break;
                }
                for (int colIndex = 0; colIndex < columns; colIndex++)
                {
                    if (snakeIndex <= snake.Length - 1)
                    {
                        matrix[rowIndex - 1, colIndex] = snake[snakeIndex];
                        snakeIndex++;
                    }
                    else
                    {
                        colIndex--;
                        snakeIndex = 0;
                    }
                }
            }
        }
    }
}
