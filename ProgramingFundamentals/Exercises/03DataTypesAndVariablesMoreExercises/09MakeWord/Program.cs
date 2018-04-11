using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09MakeWord
{
    class Program
    {
        static void Main(string[] args)
        {
            short numberOfLines = short.Parse(Console.ReadLine());
            string word = null;
            for (int i = 0; i < numberOfLines; i++)
            {
                char input = char.Parse(Console.ReadLine());
                word += input;
            }
            Console.WriteLine("The word is: " + word);
        }
    }
}
