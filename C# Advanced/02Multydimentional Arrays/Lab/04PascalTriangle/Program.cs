using System;

namespace _04PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long currentWidth = 1;
            long[][] triangle = new long[height][];

            for (long i = 0; i < height; i++)
            {
                triangle[i] = new long[i + 1];
                triangle[i][0] = 1;
                triangle[i][i] = 1;
                currentWidth++;
                if (i >= 2)
                {
                    for (long j = 1; j < i; j++)
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }
            }

            for (long row = 0; row < triangle.Length; row++)
            {
                for (long col = 0; col < triangle[row].Length; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
