using System;
using System.Collections.Generic;
using System.Linq;

namespace _04GenericSwapMethodIntegers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> items = new List<int>();

            int numberInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInputs; i++)
            {
                int input = int.Parse(Console.ReadLine());
                items.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sourceIndex = indexes[0];
            int destinationIndex = indexes[1];

            Box<int> box = new Box<int>(items);
            box.Swap(sourceIndex, destinationIndex);

            Console.WriteLine(box.ToString());
        }
    }
}
