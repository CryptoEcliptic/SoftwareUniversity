using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = inputNumbers.Length / 4;
            var leftPart = inputNumbers.Take(k).Reverse().ToArray();
            var middlePart = inputNumbers.Skip(k).Take(2 * k).ToArray();
            var rightPart = inputNumbers.Skip(3 * k).Take(k).Reverse().ToArray();
            var concatenatedNumber = leftPart.Concat(rightPart).ToArray();

            var sum = concatenatedNumber.Select((x, index) => x + middlePart[index]);

            Console.WriteLine(string.Join(" ", sum));
 


        }
    }
}
