using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>();
            foreach (var item in input)
            {
                stack.Push(item);
            }

            while (stack.Count > 1)
            {
                int leftoperand = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int rightoperand = int.Parse(stack.Pop());
                switch (operation)
                {
                    case "+":
                        stack.Push((leftoperand + rightoperand).ToString());
                        break;

                    case "-":
                        stack.Push((leftoperand - rightoperand).ToString());
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
