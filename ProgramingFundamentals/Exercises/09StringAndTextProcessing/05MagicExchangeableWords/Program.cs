using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputWords = Console.ReadLine().Split(' ').ToArray();
            string firstWord = inputWords[0];
            string secondWord = inputWords[1];

            int w1 = firstWord.ToCharArray().Distinct().Count();
            int w2 = secondWord.ToCharArray().Distinct().Count();

            if (w1 == w2)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
