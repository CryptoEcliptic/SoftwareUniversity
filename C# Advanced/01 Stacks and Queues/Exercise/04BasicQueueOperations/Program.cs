using System;
using System.Collections.Generic;
using System.Linq;

namespace _04BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            int add = commands[0];
            int remove = commands[1];
            int findElement = commands[2];

            Queue<int> queue = new Queue<int>();

            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();

            if (numbers.Count() >= add)
            {
                for (int i = 0; i < add; i++)
                {
                    queue.Enqueue(numbers[i]);
                }
            }
            if (queue.Count >= remove)
            {
                for (int i = 0; i < remove; i++)
                {
                    queue.Dequeue();
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(findElement))
            {
                Console.WriteLine("true");
            }
            else if (!queue.Contains(findElement))
            {
                Console.WriteLine(queue.Min());
            }
            
        }
    }
}
