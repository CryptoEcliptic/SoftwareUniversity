using System;
using System.Collections.Generic;

namespace _09Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            long a = 0;
            long b = 1;
            Stack<long> stack = new Stack<long>();
            stack.Push(a);
            stack.Push(b);

            for (int i = 1; i < number; i++)
            {
                long first = stack.Pop();
                long second = stack.Pop();

                stack.Push(first);
                stack.Push(first + second);
            }

            Console.WriteLine(stack.Pop());
           
        }
    }
}
