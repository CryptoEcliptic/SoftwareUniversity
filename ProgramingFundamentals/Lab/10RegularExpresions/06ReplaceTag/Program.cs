using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06ReplaceTag
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            while (inputText != "end")
            {
                string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                string replacement = @"[URL href=$1]$2[/URL]";
                string replacedText = Regex.Replace(inputText, pattern, replacement);

                Console.WriteLine(replacedText);

                inputText = Console.ReadLine();
            }
        }
    }
}
