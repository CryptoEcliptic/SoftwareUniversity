using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emailList = new Dictionary<string, string>();
            string command = Console.ReadLine();
            string name = null;
            while (command != "stop")
            {
                name = command;
                string email = Console.ReadLine();
                if (!emailList.ContainsKey(name))
                {
                    emailList.Add(name, email);
                }
                command = Console.ReadLine();
            }
            foreach (var kvp in emailList)
            {
                if (!(kvp.Value.EndsWith("us") || kvp.Value.EndsWith("uk")))
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
