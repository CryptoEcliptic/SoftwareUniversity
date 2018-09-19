using System;
using System.Linq;
using System.Collections.Generic;

namespace _02BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split()
                 .Select(int.Parse)
                 .ToArray();

            int pushElements = commands[0];
            int popElements = commands[1];
            int lookFor = commands[2];

            int[] numbers = Console.ReadLine().Split()
                 .Select(int.Parse)
                 .ToArray();
            Stack<int> stack = new Stack<int>();

            if (numbers.Count() >= pushElements)
            {
                for (int i = 0; i < pushElements; i++)
                {
                    stack.Push(numbers[i]);
                }
            }
            if (stack.Count >= popElements)
            {
                for (int i = 0; i < popElements; i++)
                {
                    stack.Pop();
                }
            }
            if (stack.Contains(lookFor))
            {
                Console.WriteLine("true");
            }
            else if(!stack.Contains(lookFor) && stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
