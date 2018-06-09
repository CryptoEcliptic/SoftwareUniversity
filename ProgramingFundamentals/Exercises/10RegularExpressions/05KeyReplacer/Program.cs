using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05KeyReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordKey = Console.ReadLine();
            string inputText = Console.ReadLine();
            string pattern = @"(?<startKey>[A-Za-z]+)[|<\\](?<middleGroup>[A-Za-z0-9]+)[\|<\\](?<endKey>[A-Za-z]+)";

            var keys = Regex.Match(wordKey, pattern);
            string startKey = keys.Groups[1].ToString();
            string endKey = keys.Groups[3].ToString();

            var textPattern = $"{startKey}(.*?){endKey}";
            var match = Regex.Matches(inputText, textPattern);
            StringBuilder sb = new StringBuilder();

            foreach (Match words in match)
            {
                sb.Append(words.Groups[1].ToString());
            }
            var result = sb.Length != 0 ? sb.ToString() : "Empty result"; 
            Console.WriteLine(result);
            

        }
    }
}
