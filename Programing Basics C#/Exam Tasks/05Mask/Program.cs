using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Mask
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int doubleN = 2 * n;
            for (int i = 0; i < n - 1; i++)
            {
                string upperExternalBlank = new string(' ', n - 2 - i);
                string upperInternalBlanks = new string(' ', i);
                string upperMiddleBlanks = new string(' ', 2);
                Console.WriteLine($"{upperExternalBlank}/{upperInternalBlanks}|{upperMiddleBlanks}|{upperInternalBlanks}\\");
            }
            Console.WriteLine("{0}", new string('-', doubleN + 2));

            string figuresBlanks = new string(' ', n / 2 - 1);
            string betweenFiguresBlanks = new string(' ', n + 1);
            string mainPartBlanks = new string(' ', doubleN);
            Console.WriteLine($"|{figuresBlanks}_{betweenFiguresBlanks}_{figuresBlanks}|");
            Console.WriteLine($"|{figuresBlanks}@{betweenFiguresBlanks}@{figuresBlanks}|");

            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine($"|{mainPartBlanks}|");
            }
            Console.WriteLine("|{0}OO{0}|", new string(' ', n - 1));
            Console.WriteLine("|{0}/  \\{0}|", new string(' ', n - 2));
            Console.WriteLine("|{0}||||{0}|", new string(' ', n - 2));
            int apostrophes = doubleN;
            for (int i = 1; i <= n + 1; i++)
            {
                
                Console.WriteLine("{0}{1}{2}", new string('\\', i), new string('`', apostrophes), new string('/', i));
                apostrophes -= 2; 
            }
        }
    }
}
