using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputWords = Console.ReadLine().Split(' ').ToArray();
            var random = new Random();

            for (int i = 0; i < inputWords.Length; i++)
            {
                var currentWord = inputWords[i];
                var randomIndex = random.Next(0, inputWords.Length);
                var randomWord = inputWords[randomIndex];
                inputWords[i] = randomWord;
                inputWords[randomIndex] = currentWord;
            }
            foreach (var words in inputWords)
            {
                Console.WriteLine(words);
            }
        }
    }
}
