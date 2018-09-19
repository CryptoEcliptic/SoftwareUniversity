using System;
using System.Collections.Generic;

namespace _04MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> indexesOpenBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexesOpenBrackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int openBracketIndex = indexesOpenBrackets.Pop();
                    int length = i - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, length));
                }
            }

        }
    }
}
