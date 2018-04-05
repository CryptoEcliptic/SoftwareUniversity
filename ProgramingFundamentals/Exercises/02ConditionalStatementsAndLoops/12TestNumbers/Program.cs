using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxSumBoundary = int.Parse(Console.ReadLine());
            int totalSum = 0;
            int count = 0;
            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    totalSum += (i * j) * 3;
                    count++;
                    if (totalSum >= maxSumBoundary)
                    {
                        Console.WriteLine($"{count} combinations\r\nSum: {totalSum} >= {maxSumBoundary}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{count} combinations\r\nSum: {totalSum}");
        }
    }
}
