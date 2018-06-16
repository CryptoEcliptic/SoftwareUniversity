using System;
using System.Linq;

namespace _06ByteFlip
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(' ')
                 .Where(x => x.Length == 2)
                 .ToArray();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char[] reversed = input[i].ToCharArray(); // converting the input To char[]
                Array.Reverse(reversed); // reversing the char[]
                Console.Write(System.Convert.ToChar(System.Convert.ToUInt32(new string(reversed), 16)));
            }
            Console.WriteLine();
        }
    }
}
