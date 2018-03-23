using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Sheriff
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 3 * n;
            int hieght = 2 * n + 8;
            int halfN = n / 2;

            int firstAndLastDots = (3 * n) / 2;
            Console.WriteLine("{0}x{0}", new string('.', firstAndLastDots));
            Console.WriteLine("{0}/x\\{0}", new string('.', firstAndLastDots - 1));
            Console.WriteLine("{0}x|x{0}", new string('.', firstAndLastDots - 1));
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                int internalX = n + i;
                int internalDots = halfN - i;
                Console.WriteLine("{0}{1}|{1}{0}", new string('.', internalDots), new string('x', internalX));
            }
            int internalXlow = (3 * n) / 2 - 1;
            for (int i = 1; i <= halfN; i++)
            { 
                Console.WriteLine("{0}{1}|{1}{0}", new string('.', i), new string('x', internalXlow));
                internalXlow--;
            }
            Console.WriteLine("{0}/x\\{0}", new string('.', firstAndLastDots - 1));
            Console.WriteLine("{0}\\x/{0}", new string('.', firstAndLastDots - 1));
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                int internalX = n + i;
                int internalDots = halfN - i;
                Console.WriteLine("{0}{1}|{1}{0}", new string('.', internalDots), new string('x', internalX));
            }
            int internalXfinal = (3 * n) / 2 - 1;
            for (int i = 1; i <= halfN; i++)
            {
                Console.WriteLine("{0}{1}|{1}{0}", new string('.', i), new string('x', internalXfinal));
                internalXfinal--;
            }
            Console.WriteLine("{0}x|x{0}", new string('.', firstAndLastDots - 1));
            Console.WriteLine("{0}\\x/{0}", new string('.', firstAndLastDots - 1));
            Console.WriteLine("{0}x{0}", new string('.', firstAndLastDots));
        }
    }
}
