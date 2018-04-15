using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine().ToLower();

            double volumeCube = Math.Pow(side, 3);
            double faceDiagonalsCube = Math.Sqrt(2 * Math.Pow(side, 2));
            double spaceDiagonalsCube = Math.Sqrt(3 * Math.Pow(side, 2));
            double surfaceAreaCube = 6 * Math.Pow(side, 2);
            if (parameter == "face")
            {
                Console.WriteLine($"{faceDiagonalsCube:f2}");
            }
            else if (parameter == "space")
            {
                Console.WriteLine($"{spaceDiagonalsCube:f2}");
            }
            else if (parameter == "volume")
            {
                Console.WriteLine($"{volumeCube:f2}");
            }
            else if (parameter == "area")
            {
                Console.WriteLine($"{surfaceAreaCube:f2}");
            }
        }
    }
}
