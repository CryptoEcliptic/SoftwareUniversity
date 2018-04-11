using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11StringConcatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            char delimeter = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            short numberOfLines = short.Parse(Console.ReadLine());
            string oddWords = null;
            string evenWords = null;

            for (int i = 1; i <= numberOfLines; i++)
            {
                string input = Console.ReadLine();
                if (evenOrOdd == "even")
                {
                    if (i % 2 == 0)
                    {
                        evenWords += input + delimeter; //Concatenating the input chars in a string, including delimeter after each input.
                    }                                   // for example: Marya&Gosho&
                }
                if (evenOrOdd == "odd")
                {
                    if (i % 2 == 1)
                    {
                        oddWords += input + delimeter; //Concatenating the input chars in a string, including delimeter after each input.
                    }                                   // for example: Marya&Gosho&
                }
            }
            if (evenOrOdd == "even")
            {
                Console.WriteLine(evenWords.Remove(evenWords.Length - 1)); //Printing the string and removing the last symbol (delimeter)
            }                                                               //Maria&Gosgo& -> Maria&Gosho
            else if (evenOrOdd == "odd")
            {
                Console.WriteLine(oddWords.Remove(oddWords.Length - 1));
            }
        }
    }
}
