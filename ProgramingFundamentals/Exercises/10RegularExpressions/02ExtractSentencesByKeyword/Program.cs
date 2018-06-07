using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string[] inputText = Console.ReadLine()
                .Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (var sentence in inputText)
            {
                var words = Regex.Split(sentence, @"[^A-Za-z0-9]+");
                foreach (var word in words)
                {
                    if (word == keyword)
                    {
                        Console.WriteLine(sentence.Trim());
                        break;
                    }
                }
            }
           
        }
    }
}
