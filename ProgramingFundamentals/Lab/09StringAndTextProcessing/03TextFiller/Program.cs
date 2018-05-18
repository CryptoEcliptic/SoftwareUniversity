using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03TextFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string inputText = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                var stars = new string('*', word.Length);
                inputText = inputText.Replace(word, stars);
            }
            Console.WriteLine($"{inputText}");
        }
    }
}
