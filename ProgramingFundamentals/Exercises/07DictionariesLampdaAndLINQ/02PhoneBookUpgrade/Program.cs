using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02PhoneBookUpgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();

            while (input[0] != "END")
            {
                if (input[0] == "A")
                {
                    if (!phonebook.ContainsKey(input[1]))
                    {
                        phonebook.Add(input[1], input[2]);
                    }
                    else if (phonebook.ContainsKey(input[1]))
                    {
                        phonebook[input[1]] = input[2];
                    }
                }

                else if (input[0] == "S")
                {
                    if (!phonebook.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"Contact {input[1]} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine($"{input[1]} -> {phonebook[input[1]]}");
                    }
                }

                else if (input[0] == "ListAll")
                {
                    foreach (var contacts in phonebook)
                    {
                        Console.WriteLine($"{contacts.Key} -> {contacts.Value}");
                    }
                }

                input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
        }
    }
}
