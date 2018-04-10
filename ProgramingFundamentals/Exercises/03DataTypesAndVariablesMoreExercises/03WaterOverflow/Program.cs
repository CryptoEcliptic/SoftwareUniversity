using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int reservoirCapacity = 255;
            int capacityLeft = reservoirCapacity;

            for (int i = 1; i <= numberOfLines; i++)
            {
                int littersFilled = int.Parse(Console.ReadLine());

                if (capacityLeft - littersFilled >= 0)
                {
                    capacityLeft -= littersFilled;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            int filledWater = reservoirCapacity - capacityLeft;
            Console.WriteLine(filledWater);
        }
    }
}
