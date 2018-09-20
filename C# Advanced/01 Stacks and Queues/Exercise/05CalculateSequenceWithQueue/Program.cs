using System;
using System.Collections.Generic;

namespace _05CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long startNumber = long.Parse(Console.ReadLine());

            Queue<long> collectionNumbers = new Queue<long>();
            Queue<long> working = new Queue<long>();

            collectionNumbers.Enqueue(startNumber);
            working.Enqueue(startNumber);
            long s1 = startNumber;

            for (int i = 0; i < 50; i++)
            {
                long s2 = s1 + 1;
                collectionNumbers.Enqueue(s2);
                working.Enqueue(s2);

                long s3 = 2 * s1 + 1;
                collectionNumbers.Enqueue(s3);
                working.Enqueue(s3);

                long s4 = s1 + 2;
                collectionNumbers.Enqueue(s4);
                working.Enqueue(s4);

                working.Dequeue();
                s1 = working.Peek();
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(collectionNumbers.Dequeue() + " ");
            }


        }
    }
}
