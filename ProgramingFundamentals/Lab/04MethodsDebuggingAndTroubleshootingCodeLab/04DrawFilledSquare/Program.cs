using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04DrawFilledSquare
{
    class Program
    {
        static void TopLine(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }
        static void CentralLines(int n)
        {
            Console.Write('-');
            for (int i = 1; i <= n - 1; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine('-');
        }
        static void BottomLine(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            TopLine(n);
            for (int i = 1; i <= n - 2; i++)
            {
                CentralLines(n);
            }
            BottomLine(n);
        }
    }
}
