using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char one = word[word.Length - 1]; //Defining last symbol of the word.
            char two = word[word.Length - 2]; // Defining the symbol before the last one.
            if (one == 'y')
            {
                word = word.Remove(word.Length - 1);
                Console.WriteLine(word + "ies");
            }
            else if (one == 'o' || one == 's' || one == 'x' || one == 'z' || (one == 'h' && two == 'c' || two == 's'))
            {
                Console.WriteLine(word + "es");
            }
            else
            {
                Console.WriteLine(word + "s");
            }
        }
    }
}
