using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            string space = @"(%20|\+)+";
            var pattern = new Regex (@"([^=&?\n]+)=([^=&?\n]+)");

            while (inputText != "END")
            {       
                var data = pattern.Matches(inputText);
                Dictionary<string, List<string>> collectionData = new Dictionary<string, List<string>>(); ;
                foreach (Match item in data)
                {
                    string field = item.Groups[1].ToString();
                    field = Regex.Replace(field, space, " ").Trim();
                    string value = item.Groups[2].ToString();
                    value = Regex.Replace(value, space, " ").Trim();

                    if (!collectionData.ContainsKey(field))
                    {
                        collectionData.Add(field, new List<string>());
                    }
                    collectionData[field].Add(value); 
                }

                foreach (var output in collectionData)
                {
                    Console.Write($"{output.Key}=[{string.Join(", ", output.Value)}]");
                }
                Console.WriteLine();
                inputText = Console.ReadLine();
            } 
        }
    }
}
