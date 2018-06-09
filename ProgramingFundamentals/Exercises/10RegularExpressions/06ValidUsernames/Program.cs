using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNames = Console.ReadLine();
            string pattern = @"\b[A-Za-z]\w{2,24}\b";
            MatchCollection namesInPattern = Regex.Matches(inputNames, pattern);
            int maxLength = 0;
            string currentMaxLengthUsernames = "";

            for (int i = 0; i < namesInPattern.Count - 1; i++)
            {
                Match firstName = namesInPattern[i];
                Match secondName = namesInPattern[i + 1];
                int sum = firstName.Length + secondName.Length;
                if (sum > maxLength)
                {
                    maxLength = sum;
                    currentMaxLengthUsernames = "";
                    currentMaxLengthUsernames = firstName + "\n" + secondName;
                }
            }
            Console.WriteLine(currentMaxLengthUsernames);
           
        }
    }
}
