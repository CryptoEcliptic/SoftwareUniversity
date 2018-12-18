using System;
using System.Collections.Generic;
using System.Linq;

namespace _033GenericSwapMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> items = new List<string>();
           
            int numberInputs = int.Parse(Console.ReadLine());
             
            for (int i = 0; i < numberInputs; i++)
            {
                string input = Console.ReadLine();
                items.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sourceIndex = indexes[0];
            int destinationIndex = indexes[1];

            Box<string> box = new Box<string>(items);
            box.Swap(sourceIndex, destinationIndex);

            Console.WriteLine(box.ToString());
        }
    }
}
