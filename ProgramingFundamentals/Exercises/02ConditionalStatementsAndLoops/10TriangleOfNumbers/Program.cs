using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write(i);
                for (int j = 2; j <= i; j++)
                {
                    Console.Write($" {i}");
                }

                Console.WriteLine();
            }
        }
    }
}
