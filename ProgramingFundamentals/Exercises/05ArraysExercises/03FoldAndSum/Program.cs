using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int k = input.Length / 4;
            int[] leftPart = input.Take(k).ToArray();
            int[] middlePart = input.Skip(k).Take(2 * k).ToArray();
            int[] rightPart = input.Skip(3 * k).Take(k).ToArray();

            leftPart = leftPart.Reverse().ToArray();
            rightPart = rightPart.Reverse().ToArray();
            int[] result = new int[2 * k];
            for (int i = 0; i < k; i++)
            {
                result[i] = leftPart[i] + middlePart[i];
                result[i + k] = middlePart[i + k] + rightPart[i];   
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
