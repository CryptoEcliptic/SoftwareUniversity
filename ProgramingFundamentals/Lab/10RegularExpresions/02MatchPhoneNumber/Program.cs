using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            string pattern = @"\+359 [2] \d{3} \d{4}|\+359-[2]-\d{3}-\d{4}\b";
            MatchCollection phoneNumber = Regex.Matches(inputNumber, pattern);

            var printResult = phoneNumber
                 .Cast<Match>()
                 .Select(x => x.Value.Trim())
                 .ToArray();
            Console.WriteLine(string.Join(", ", printResult));
        }
    }
}
