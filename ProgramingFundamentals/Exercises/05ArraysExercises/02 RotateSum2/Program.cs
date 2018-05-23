using System;
using System.Linq;

namespace _02_RotateAndSumWithList
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] sum = new int[input.Count];

            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                input.Insert(0, input[input.Count - 1]);
                input.RemoveAt(input.Count - 1);

                for (int j = 0; j < input.Count; j++)
                {
                    sum[j] = sum[j] + input[j];
                }
            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
