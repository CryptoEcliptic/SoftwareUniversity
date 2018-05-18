using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = Console.ReadLine()
                .Split(new char[] { ' ', ',', '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> result = new List<string>();

            foreach (var palindromes in inputText) // Checking and finding all palindromes
            {
                bool palindrome = IsPalindrome(palindromes);
                if (palindrome)
                {
                    result.Add(palindromes); // Adding palindromes in a list.
                }
            }
            Console.WriteLine(string.Join(", ", result.Distinct().OrderBy(x => x)));

        }
        private static bool IsPalindrome(string input) // Method for finding palindromes
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
