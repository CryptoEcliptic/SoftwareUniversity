using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] controlNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string inputText = Console.ReadLine();
            string pattern = @"\|<(.*?)(?=\||$)";

            MatchCollection text = Regex.Matches(inputText, pattern);
            List<string> toPrint = new List<string>();

            foreach (Match word in text)
            {
                var selectedElement = word.Groups[1].Value.Skip(controlNumbers[0]).Take(controlNumbers[1]).ToArray();
                var concatinated = string.Concat(selectedElement);
                toPrint.Add(concatinated);
            }
            Console.WriteLine(string.Join(", ", toPrint));
            
        }
    }
}
