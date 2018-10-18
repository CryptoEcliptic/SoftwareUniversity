using System;
using System.IO;

namespace _01ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("C:\\Users\\Name\\source\\repos\\04StreamsLab\\01ReadFile\\Program.cs"))
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
