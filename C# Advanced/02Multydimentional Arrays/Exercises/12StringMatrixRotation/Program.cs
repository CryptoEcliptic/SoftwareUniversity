using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string rotate = Console.ReadLine();
            string[] rotationtextList = rotate.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int degrees = int.Parse(rotationtextList[1]);

            string text = Console.ReadLine();
            List<string> textList = new List<string>();
            int longestWord = 0;

            while (text != "END")
            {
                textList.Add(text);
                if (longestWord < text.Length)
                {
                    longestWord = text.Length;
                }
                text = Console.ReadLine();
            }

            for (int i = 0; i < textList.Count; i++)
            {
                if (textList[i].Length < longestWord)
                {
                    textList[i] = textList[i] + new string(' ', longestWord - textList[i].Length);
                }
            }

            if (degrees == 180 || degrees % 360 == 180)
            {
                Rotate180(textList);
            }

            char[,] rotate90 = new char[longestWord, textList.Count];
            CreateRotatedMatrix(textList, longestWord, rotate90);

            if (degrees == 270 || degrees % 360 == 270)
            {
                Rotate270(rotate90);
            }

            if (degrees == 90 || degrees % 360 == 90)
            {
                Rotate90(rotate90);
            }

            if (degrees == 0 || degrees % 360 == 0)
            {
                foreach (var rotate360 in textList)
                {
                    Console.WriteLine(rotate360);
                }

            }
        }
        private static void Rotate90(char[,] rotate90)
        {
            for (int i = 0; i < rotate90.GetLength(0); i++)
            {
                for (int j = rotate90.GetLength(1) - 1; j >= 0; j--)
                {
                    Console.Write(rotate90[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotate270(char[,] rotate90)
        {
            for (int i = rotate90.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < rotate90.GetLength(1); j++)
                {
                    Console.Write(rotate90[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void CreateRotatedMatrix(List<string> textList, int longestWord, char[,] rotate90)
        {
            for (int row = 0; row < longestWord; row++)
            {
                for (int col = 0; col < textList.Count; col++)
                {
                    rotate90[row, col] = textList[col][row];
                }
            }
        }

        private static void Rotate180(List<string> textList)
        {
            for (int i = textList.Count - 1; i >= 0; i--)
            {
                for (int j = textList[i].Length - 1; j >= 0; j--)
                {
                    Console.Write(textList[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
