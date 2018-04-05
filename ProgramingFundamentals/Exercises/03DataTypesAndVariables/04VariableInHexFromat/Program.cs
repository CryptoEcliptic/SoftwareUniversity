using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04VariableInHexFromat
{
    class Program
    {
        static void Main(string[] args)
        {
            int hexOne = Convert.ToInt32(Console.ReadLine(), 16);
            Console.WriteLine(hexOne);
        }
    }
}
