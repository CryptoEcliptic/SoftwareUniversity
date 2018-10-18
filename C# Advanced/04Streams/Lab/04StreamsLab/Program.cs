using System;
using System.IO;

namespace _01ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("Program.cs"))
            {
                int lineNumber = 1;
                string line = stream.ReadLine();
                while (line != null)
                {

                    Console.WriteLine($"Line {lineNumber}: {line}");
                    line = stream.ReadLine();
                    lineNumber++;
                }
            }
        }
    }
}
