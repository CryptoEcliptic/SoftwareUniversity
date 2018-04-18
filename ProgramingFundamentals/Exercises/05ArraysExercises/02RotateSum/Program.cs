using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02RotateSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] sum = new int[inputNumbers.Length];
            for (int i = 0; i < rotations; i++)
            {
                int lastDigit = inputNumbers[inputNumbers.Length - 1];
                for (int j = inputNumbers.Length - 1 ; j > 0; j--)
                {
                    inputNumbers[j] = inputNumbers[j - 1];
                    sum[j] += inputNumbers[j];
                }
                inputNumbers[0] = lastDigit;
                sum[0] += inputNumbers[0];
            }

            for (int i = 0; i < sum.Length; i++)
            {
                Console.Write(sum[i] + " ");
            }
        }
    }
}
