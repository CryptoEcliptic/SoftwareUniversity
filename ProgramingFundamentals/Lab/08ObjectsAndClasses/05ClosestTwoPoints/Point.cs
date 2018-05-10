using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05ClosestTwoPoints
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Display()
        {
            return $"({X}, {Y})";
        }
    }
    
}
