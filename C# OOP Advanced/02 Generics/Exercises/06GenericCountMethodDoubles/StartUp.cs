using System;
using System.Collections.Generic;

namespace _06GenericCountMethodDoubles
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            List<double> elements = new List<double>();

            int numberInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInputs; i++)
            {
               double element = double.Parse(Console.ReadLine());
               elements.Add(element);
            }

            double comparedElement = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();
            box.CountGreaterElements(elements, comparedElement);
        }
    }
}
