using System;
using System.IO;

namespace STREAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 0;
            using (StreamReader reader = new StreamReader(@"../../../../resources/text.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (lineNumber % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
