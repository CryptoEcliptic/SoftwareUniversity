using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06ChristmassToy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int doubleN = 2 * n;
            int halfN = n / 2;

            string startEndDashes = new string('-', doubleN);
            string startEndStars = new string('*', n);
            Console.WriteLine($"{startEndDashes}{startEndStars}{startEndDashes}");
            int loopDashes = doubleN - 2;
            int loopStars = 1;
           int loopAmpersans = n + 2;
            for (int i = 0; i < halfN; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', loopDashes - 2 * i), new string('*', loopStars + i), 
                    new string('&', loopAmpersans + 2 * i));

            }
            for (int i = 0; i < halfN; i++)
            {
                Console.WriteLine("{0}**{1}**{0}", new string('-', (n - 1) - i), new string('~', (3 * n - 2) + 2 * i));
            }
            Console.WriteLine("{0}*{1}*{0}", new string('-', halfN), new string('|', 4 * n - 2));
            for (int i = 0; i < halfN; i++)
            {
                Console.WriteLine("{0}**{1}**{0}", new string('-', halfN + i), new string('~', (4 * n - 4) - 2 * i));
            }
            for (int i = 0; i < halfN; i++)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', n + 2 * i), new string('*', n / 2 - i), new string('&', (2 * n - 2 * i)));
            }
            Console.WriteLine($"{startEndDashes}{startEndStars}{startEndDashes}");
        }
    }
}
