using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05ParallelepipedFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int wavesNumber = n - 2;
            int startandEndDots = 2 * n + 1;
            int rightDots = 2 * n;

            Console.WriteLine("+{0}+{1}", new string('~', wavesNumber), new string('.', startandEndDots));
            for (int i = 0; i <= 2 * n; i++)
            {
                int leftDots = i;
                Console.WriteLine("|{0}\\{1}\\{2}", new string('.', leftDots), new string('~', wavesNumber), new string('.', rightDots));
                rightDots--;
            }

            int lowerRightDots = 2 * n;
            for (int i = 0; i <= 2 * n; i++)
            {
                int lowerleftDots = i;
                Console.WriteLine("{0}\\{1}|{2}|", new string('.', lowerleftDots), new string('.', lowerRightDots), new string('~', wavesNumber));
                
                lowerRightDots--;
            }
            Console.WriteLine("{0}+{1}+", new string('.', startandEndDots), new string('~', wavesNumber));
        }
    }
}
