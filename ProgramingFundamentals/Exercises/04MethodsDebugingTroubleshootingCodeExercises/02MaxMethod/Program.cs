using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02MaxMethod
{
    class Program
    {
        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        static void Main(string[] args)
        {
            int firtsInput = int.Parse(Console.ReadLine());
            int secondInput = int.Parse(Console.ReadLine());
            int thirdInput = int.Parse(Console.ReadLine());
            int maximalInput = GetMax(firtsInput, secondInput);
            maximalInput = GetMax(maximalInput, thirdInput);

            Console.WriteLine(maximalInput);
        }
    }
}
