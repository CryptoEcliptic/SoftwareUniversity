using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02OddOccurances
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputText = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> wordOccurances = new Dictionary<string, int>();

            foreach (var word in inputText) // Taking data from the input and put it into Dictionary wordOccurances
            {
                if (wordOccurances.ContainsKey(word))
                {
                    wordOccurances[word]++;
                }
                else
                {
                    wordOccurances[word] = 1;
                }
            }
            var result = new List<string>();
            foreach (var kvp in wordOccurances)
            {
                string word = kvp.Key;
                int times = kvp.Value;
                if (times % 2 == 1)
                {
                    result.Add(word);
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
