using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            int numberLines = int.Parse(Console.ReadLine());
            string blockchain = null;

            for (int i = 0; i < numberLines; i++)
            {
                blockchain += Console.ReadLine();
            }
                                  
            string regexPattern = @"{[^\]\[{]+}|\[[^{}\[]+\]";
            MatchCollection matches = Regex.Matches(blockchain, regexPattern);
            List<string> validBlocks = new List<string>();

            foreach (Match match in matches)
            {
                validBlocks.Add(match.ToString());
            }

            List<string> charsValues = new List<string>();
            int currentBlockLength = 0;
            for (int i = 0; i < validBlocks.Count; i++)
            {
                string nums = "";
                currentBlockLength = validBlocks[i].Length;

                string digitPattern = @"[0-9]{3}";
                MatchCollection validDigits = Regex.Matches(validBlocks[i], digitPattern);

                foreach (var dig in validDigits)
                {
                    var current = int.Parse(dig.ToString()) - currentBlockLength;
                    charsValues.Add(current.ToString());
                }
            }

            foreach (var letter in charsValues)
            {
                int let = int.Parse(letter);
                Console.Write(string.Join("" ,Convert.ToChar(let)));
            }
            Console.WriteLine();
        }
    }
}
