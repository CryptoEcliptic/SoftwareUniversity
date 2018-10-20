using System;
using System.IO;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 1;
            using (StreamReader reader = new StreamReader(@"..\..\..\..\resources\text.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\..\output.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineNumber}: {line}");
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
