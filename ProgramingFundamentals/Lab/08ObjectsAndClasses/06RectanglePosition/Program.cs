using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06RectanglePosition
{

    class Program
    {
        static void Main(string[] args)
        {
            var first = ReadRectangle();
            var second = ReadRectangle();
            var result = first.IsInside(second);
            if (result == true)
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
          
           
        }
       static Rectangle ReadRectangle()
        {
            var rectData = Console.ReadLine().Split(' ');

            return new Rectangle
            {
                Left = int.Parse(rectData[0]),
                Top = int.Parse(rectData[1]),
                Width = int.Parse(rectData[2]),
                Height = int.Parse(rectData[3])
            };
        }
    }
}
