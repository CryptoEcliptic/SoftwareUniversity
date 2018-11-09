using System;
using System.Linq;

namespace _02._Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rowsCount][];

            int[] samCoordinates = InitializeMatrix(matrix);

            string command = Console.ReadLine();

            foreach (var move in command)
            {
                UpdateEnemies(matrix);
                CheckEnemies(matrix);
                MoveSam(move, matrix, samCoordinates);
                ChekNikoladze(matrix);
            }
        }

        private static void ChekNikoladze(char[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Contains('N') && matrix[i].Contains('S'))
                {
                    matrix[i][Array.IndexOf(matrix[i], 'N')] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    PrintMatrix(matrix);
                }
            }
        }

        private static void MoveSam(char move, char[][] matrix, int[] coordinates)
        {
            switch (move)
            {
                case 'U':
                    matrix[coordinates[0]][coordinates[1]] = '.';
                    matrix[--coordinates[0]][coordinates[1]] = 'S';
                    break;
                case 'D':
                    matrix[coordinates[0]][coordinates[1]] = '.';
                    matrix[++coordinates[0]][coordinates[1]] = 'S';
                    break;
                case 'L':
                    matrix[coordinates[0]][coordinates[1]] = '.';
                    matrix[coordinates[0]][--coordinates[1]] = 'S';
                    break;
                case 'R':
                    matrix[coordinates[0]][coordinates[1]] = '.';
                    matrix[coordinates[0]][++coordinates[1]] = 'S';
                    break;
                default:
                    break;
            }
        }

        private static void CheckEnemies(char[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Contains('b') && matrix[i].Contains('S'))
                {
                    if (Array.IndexOf(matrix[i], 'b') < Array.IndexOf(matrix[i], 'S'))
                    {
                        matrix[i][Array.IndexOf(matrix[i], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {i}, {Array.IndexOf(matrix[i], 'X')}");
                        PrintMatrix(matrix);
                    }
                }
                else if (matrix[i].Contains('d') && matrix[i].Contains('S'))
                {
                    if (Array.IndexOf(matrix[i], 'd') > Array.IndexOf(matrix[i], 'S'))
                    {
                        matrix[i][Array.IndexOf(matrix[i], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {i}, {Array.IndexOf(matrix[i], 'X')}");
                        PrintMatrix(matrix);
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(String.Join("", line));
            }
            Environment.Exit(0);
        }

        private static void UpdateEnemies(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'b')
                    {
                        if (j == matrix[i].Length - 1)
                        {
                            matrix[i][j] = 'd';
                        }
                        else
                        {
                            matrix[i][j] = '.';
                            matrix[i][++j] = 'b';
                        }
                    }
                    else if (matrix[i][j] == 'd')
                    {
                        if (j == 0)
                        {
                            matrix[i][j] = 'b';
                        }
                        else
                        {
                            matrix[i][j] = '.';
                            matrix[i][j - 1] = 'd';
                        }
                    }
                }
            }
        }

        private static int[] InitializeMatrix(char[][] matrix)
        {
            int[] coordinates = null;
            for (int i = 0; i < matrix.Length; i++)
            {
                string line = Console.ReadLine();

                matrix[i] = line.ToCharArray();

                if (matrix[i].Contains('S'))
                {
                    coordinates = new int[] { i, Array.IndexOf(matrix[i], 'S') };
                }
            }

            return coordinates;
        }
    }
}