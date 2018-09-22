using System;
using System.Collections.Generic;
using System.Linq;

namespace _07BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>();

            if (input.Length %2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            char[] opening = new[] {'{', '(', '[' };
            char[] closing = new[] {'}', ')', ']' };

            foreach (var item in input)
            {
                if (opening.Contains(item))
                {
                    stack.Push(item);
                }
                else if (closing.Contains(item))
                {
                    char lastElement = stack.Pop();
                    int openingIndex = Array.IndexOf(opening, lastElement);
                    int closingIndex = Array.IndexOf(closing, item);
                    if (openingIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }
            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
