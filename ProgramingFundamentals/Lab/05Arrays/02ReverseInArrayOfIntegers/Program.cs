using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ReverseInArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberElements = int.Parse(Console.ReadLine());
            int[] numbers = new int[numberElements];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int[] reversedNumbers = numbers.Reverse().ToArray();
            foreach (var reversedNumber in reversedNumbers)
            {
                Console.Write(reversedNumber + " ");
            }
        }
    }
}
