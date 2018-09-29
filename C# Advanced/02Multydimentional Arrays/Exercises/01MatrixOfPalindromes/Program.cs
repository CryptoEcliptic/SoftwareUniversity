using System;
using System.Linq;
using System.Text;

namespace _03MultidimwntionalArraysExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputParams = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            int lines = inputParams[0];
            int columns = inputParams[1];

            string[,] matrix = new string[lines, columns];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] letters = new char[3];
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(alphabet[row]);

                    sb.Append(alphabet[col + row]);

                    sb.Append(alphabet[row]);
                    

                    matrix[row, col] = sb.ToString();
                    sb.Clear();
                    
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
