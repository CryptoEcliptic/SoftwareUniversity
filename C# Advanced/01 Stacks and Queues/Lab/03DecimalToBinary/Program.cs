using System;
using System.Collections.Generic;

namespace _03DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputDecimal = int.Parse(Console.ReadLine());

            if (inputDecimal == 0)
            {
                Console.WriteLine(0);
            }

            Stack<int> stack = new Stack<int>();

            while (inputDecimal > 0)
            {
                stack.Push(inputDecimal % 2);
                inputDecimal = inputDecimal / 2;

            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();

        }
    }
}
