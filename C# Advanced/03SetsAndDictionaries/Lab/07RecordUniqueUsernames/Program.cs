using System;
using System.Collections.Generic;

namespace _06RecordUniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < inputLines; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
