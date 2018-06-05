using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputEmails = Console.ReadLine();
            string pattern = @"(^| )[A-Za-z0-9][A-Za-z0-9.\-_]*@[A-Z-a-z-]+(\.[a-z]+)+";
            MatchCollection emails = Regex.Matches(inputEmails, pattern);

            foreach (Match mail in emails)
            {
                Console.WriteLine(mail.Value.Trim());
            }
        }
    }
}
