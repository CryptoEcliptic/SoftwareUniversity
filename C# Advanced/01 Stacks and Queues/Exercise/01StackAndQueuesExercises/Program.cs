using System;
using System.Collections.Generic;

namespace _01StackAndQueuesExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();

            Stack<string> collectionStack = new Stack<string>(numbers);
            int length = collectionStack.Count;

            for (int i = 0; i < length; i++)
            {
                Console.Write(collectionStack.Pop() + " ");
            }
            Console.WriteLine();
            
        }
    }
}
