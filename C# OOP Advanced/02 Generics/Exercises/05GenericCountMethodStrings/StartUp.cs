using System;
using System.Collections.Generic;

namespace _05GenericCountMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> elements = new List<string>();

            int numberInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInputs; i++)
            {
                string element = Console.ReadLine();
                elements.Add(element);
            }

            string comparedElement = Console.ReadLine();

            Box<string> box = new Box<string>();
            box.CountGreaterElements(elements, comparedElement);
        }
    }
}
