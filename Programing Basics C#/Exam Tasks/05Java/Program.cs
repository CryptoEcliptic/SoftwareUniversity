using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Java
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string UpperBlanks = new string(' ', n);
            for (int i = 1; i <= n; i++) //loop for upper waves of the figure
            {
                Console.WriteLine($"{UpperBlanks}~ ~ ~");
            }

            int figureWidth = 3 * n + 6;
            string doubleDashes = new string('=', figureWidth - 1);
            Console.WriteLine($"{doubleDashes}");

            int doubleN4 = 2 * n + 4;
            string mainJavaWaves = new string('~', n);
            string mainWaves = new string('~', doubleN4);
            string mainBlanks = new string(' ', n - 1);    
            for (int i = 1; i <= n - 2; i++) //loop for the main body with if condition for JAVA label. 
            {
                if (i == n / 2)
                {
                    Console.WriteLine($"|{mainJavaWaves}JAVA{mainJavaWaves}|{mainBlanks}|");
                }
                else
                {
                    Console.WriteLine($"|{mainWaves}|{mainBlanks}|");
                }
            }
            Console.WriteLine($"{doubleDashes}");
            for (int i = 0; i < n; i++) // loop for the lower part of the figure with @ symbols.
            {
                Console.WriteLine("{0}\\{1}/", new string(' ', i), new string('@', doubleN4 - 2 * i));
            }
            Console.WriteLine("{0}", new string('=', 2 * n + 6));
        }
    }
}
