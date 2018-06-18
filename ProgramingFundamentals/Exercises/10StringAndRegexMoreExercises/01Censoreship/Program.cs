using System;

namespace _01Censoreship
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();
            string result = input.Replace(word, new string('*', word.Length));
            Console.WriteLine(result);
        }
    }
}
