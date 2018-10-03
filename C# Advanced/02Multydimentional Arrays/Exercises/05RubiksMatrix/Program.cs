using System;
using System.Linq;

namespace _05RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentionsOfMatrix = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimentionsOfMatrix[0];
            int columns = dimentionsOfMatrix[1];

            int commandsCount = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, columns];
            int[,] modelMatrix = new int[rows, columns];

            FillMatrix(matrix, rows, columns);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    modelMatrix[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int index = int.Parse(commands[0]);
                string direction = commands[1];
                int moves = int.Parse(commands[2]);

                ShuffleMatrix(matrix, index, direction, moves);
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != modelMatrix[i, j])
                    {
                        EqualizeValue(matrix, modelMatrix, ref i, ref j);
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }
        private static void EqualizeValue(int[,] matrix, int[,] bluePrint, ref int coordX, ref int coordY)
        {
            var swap = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == bluePrint[coordX, coordY])
                    {
                        Console.WriteLine($"Swap ({coordX}, {coordY}) with ({i}, {j})");
                        swap = matrix[coordX, coordY];
                        matrix[coordX, coordY] = matrix[i, j];
                        matrix[i, j] = swap;
                        return;
                    }
                }
            }
        }

        private static void ShuffleMatrix(int[,] matrix, int index, string direction, int moves)
        {
            int last = 0;
            switch (direction)
            {
                case "up":
                    for (int i = 0; i < moves % matrix.GetLength(0); i++)
                    {
                        last = matrix[0, index];
                        for (int j = 0, k = 1; j < matrix.GetLength(0) - 1; j++, k++)
                        {
                            matrix[j, index] = matrix[k, index];
                        }
                        matrix[matrix.GetLength(0) - 1, index] = last;
                    }
                    break;


                case "down":
                    for (int i = 0; i < moves % matrix.GetLength(0); i++)
                    {
                        last = matrix[matrix.GetLength(0) - 1, index];
                        for (int j = matrix.GetLength(0) - 1, k = matrix.GetLength(0) - 2; j >= 1; j--, k--)
                        {
                            matrix[j, index] = matrix[k, index];
                        }
                        matrix[0, index] = last;
                    }
                    break;

                case "left":
                    for (int i = 0; i < moves % matrix.GetLength(1); i++)
                    {
                        last = matrix[index, 0];
                        for (int j = 0, k = 1; j < matrix.GetLength(1) - 1; j++, k++)
                        {
                            matrix[index, j] = matrix[index, k];
                        }
                        matrix[index, matrix.GetLength(1) - 1] = last;
                    }

                    break;

                case "right":
                    for (int i = 0; i < moves % matrix.GetLength(1); i++)
                    {
                        last = matrix[index, matrix.GetLength(1) - 1];
                        for (int j = matrix.GetLength(1) - 1, k = matrix.GetLength(1) - 2; j >= 1; j--, k--)
                        {
                            matrix[index, j] = matrix[index, k];
                        }
                        matrix[index, 0] = last;

                    }
                    break;

                default:
                    break;
            }
        }

        private static void FillMatrix(int[,] matrix, int rows, int columns)
        {
            int counter = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = counter++;
                }
            }
        }
    }
}
