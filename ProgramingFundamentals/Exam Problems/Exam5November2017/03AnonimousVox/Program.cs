using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03AnonimousVox
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            string[] values = Console.ReadLine().Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            string result = null;
            string pattern = @"([a-zA-Z]+)(.+)(\1)";
            int indexPlaceholder = 0;
            MatchCollection matches = Regex.Matches(inputText, pattern);

            foreach (Match item in matches)
            {    
                result = item.Groups[1].Value + values[indexPlaceholder] + item.Groups[3].Value;
                inputText = inputText.Replace(item.Value, result);
                indexPlaceholder++;

            }
            Console.WriteLine(inputText);

        }
    }
}
