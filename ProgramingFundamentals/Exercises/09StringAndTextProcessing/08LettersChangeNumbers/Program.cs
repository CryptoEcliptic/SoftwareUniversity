using System;
using System.Linq;

namespace _08LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = Console.ReadLine().
                  Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();


            decimal result = 0.0M;
            for (int i = 0; i < inputText.Length; i++)
            {
                char[] upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXZ".ToCharArray();
                char[] lowerCase = "abcdefghijklmnopqrstuvwxz".ToCharArray();

                string currentWord = inputText[i].ToString();
                char firstLetter = currentWord[0];
                char lastLetter = currentWord[currentWord.Length - 1];
                decimal digits = decimal.Parse(currentWord.Substring(1, currentWord.Length - 2));

                if (firstLetter < 'a' - 1)
                {
                    decimal divide = firstLetter - 'A' + 1;
                    result += digits / divide;
                }
                else
                {
                    decimal multiply = firstLetter - 'a' + 1;
                    result += digits * multiply;
                }
                if (upperCase.Contains(lastLetter))
                {
                    decimal substract = lastLetter - 'A' + 1;
                    result -= substract;
                }
                else
                {
                    decimal addding = lastLetter - 'a' + 1;
                    result += addding;
                }
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
