using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char symbolOmitted = char.Parse(Console.ReadLine());

            for (char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (i != symbolOmitted && j != symbolOmitted && k != symbolOmitted)
                        {
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }
        }
    }
}
