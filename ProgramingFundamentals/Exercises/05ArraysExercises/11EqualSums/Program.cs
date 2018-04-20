using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            bool hasEqualsum = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                int[] firstHalf = numbers.Take(i).ToArray();
                int[] secondHalf = numbers.Skip(i + 1).ToArray();
                if (firstHalf.Sum() == secondHalf.Sum())
                {
                    hasEqualsum = true;
                    Console.WriteLine(i);
                    break;
                }
            }
            if (!hasEqualsum)
            {
                Console.WriteLine("no");

            }
        }
    }
}
