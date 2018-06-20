using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04MorseCodeUpgraded
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] encryptedText = Console.ReadLine().Split('|').ToArray();
            List<char> result = new List<char>();

            for (int i = 0; i < encryptedText.Length; i++)
            {
                char symbol = '\0';
                int zeroesCount = 0;
                int oneCount = 0;
                int counts = 0;
                int currentSum = 0;
                string currentLetter = encryptedText[i];

                for (int j = 0; j < currentLetter.Length; j++)
                {
                    if (currentLetter[j] == '0')
                    {
                        zeroesCount++;
                    }
                    else if (currentLetter[j] == '1')
                    {
                        oneCount++;
                    }
                }

                Regex getSequences = new Regex(@"0{2,}|1{2,}"); // Counting the sequence of equal elements below
                var matchedSequences = getSequences.Matches(currentLetter);
                foreach (Match sequence in matchedSequences)
                {
                    counts += sequence.Length;
                }

                currentSum = (zeroesCount * 3) + (oneCount * 5) + counts;
                symbol = Convert.ToChar(currentSum);
                result.Add(symbol);
            }
            Console.WriteLine(string.Join("", result));

        }
    }
}
