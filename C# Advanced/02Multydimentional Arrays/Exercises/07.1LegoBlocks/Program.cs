using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._1LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraysLines = int.Parse(Console.ReadLine());

            int[][] firstArray = new int[arraysLines][];
            int[][] secondArray = new int[arraysLines][];

            FillFirstArray(arraysLines, firstArray);
            FillSecondArray(arraysLines, secondArray);
            ReverseSecondArray(secondArray);


            int[][] matrix = new int[arraysLines][];
            GatheredArrays(arraysLines, firstArray, secondArray, matrix);

            int rowLenght = firstArray[0].Length + secondArray[0].Length;
            bool isMatrix = true;
            int elements = 0;
            for (int i = 0; i < arraysLines; i++)
            {
                int currentLenght = firstArray[i].Length + secondArray[i].Length;
                elements += matrix[i].Count();
                if (currentLenght != rowLenght)
                {
                    isMatrix = false;
                }
            }
            if (isMatrix)
            {
                PrintMatrix(matrix);
            }
            else if (isMatrix == false)
            {
                Console.WriteLine($"The total number of cells is: {elements}");
            }
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {

                Console.WriteLine("[" + (String.Join(", ", matrix[i])) + "]");
            }
        }

        private static void GatheredArrays(int arraysLines, int[][] firstArray, int[][] secondArray, int[][] matrix)
        {
            for (int i = 0; i < arraysLines; i++)
            {
                matrix[i] = new int[firstArray[i].Length + secondArray[i].Length];
                int index = 0;

                for (int j = 0; j < firstArray[i].Length; j++)
                {
                    matrix[i][index] = firstArray[i][j];
                    index++;
                }
                for (int k = 0; k < secondArray[i].Length; k++)
                {
                    matrix[i][index] = secondArray[i][k];
                    index++;
                }

            }
        }

        private static void ReverseSecondArray(int[][] secondArray)
        {
            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j <= secondArray[i].Length / 2; j++)
                {
                    secondArray[i] = secondArray[i].Reverse().ToArray();
                }
            }
        }

        private static void FillSecondArray(int arraysLines, int[][] secondArray)
        {
            for (int i = 0; i < arraysLines; i++)
            {
                int[] inputNumbers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                secondArray[i] = new int[inputNumbers.Length];
                for (int j = 0; j < secondArray[i].Length; j++)
                {
                    secondArray[i][j] = inputNumbers[j];
                }
            }
        }

        private static void FillFirstArray(int arraysLines, int[][] firstArray)
        {
            for (int i = 0; i < arraysLines; i++)
            {
                int[] inputNumbers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                firstArray[i] = new int[inputNumbers.Length];
                for (int j = 0; j < firstArray[i].Length; j++)
                {
                    firstArray[i][j] = inputNumbers[j];
                }
            }
        }
    }
}
