using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            char[] convertedText = inputText.ToCharArray();
            Array.Reverse(convertedText);

            Console.WriteLine(convertedText);
        }
    }
}
