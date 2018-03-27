using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int figureWidth = 4 * n - 4;
            int blanks = 4 * n - 8;
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("*\\");
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*\\");
                }
                Console.Write("{0}", new string(' ', blanks - 4 * i));
                for (int k = 0; k <= i; k++)
                {
                    Console.Write("/*");
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= figureWidth / 2; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine();
            string leftArrows = new string('<', figureWidth / 2 - 3);
            string rightArrows = new string('>', figureWidth / 2 - 3);
            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine($"{leftArrows}*|**|*{rightArrows}");
            }
            for (int i = 1; i <= figureWidth / 2; i++)
            {
                Console.Write("/\\");
            }
            Console.WriteLine();
            blanks = 4;
            for (int i = n - 2; i >=1 ; i--)
            {
                Console.Write("*/");
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write("*/");
                }
                Console.Write(new string(' ', blanks));
                for (int k = i; k >= 1; k--)
                {
                    Console.Write("\\*");
                }
                blanks += 4;
                Console.WriteLine();
            }

        }
    }
}
