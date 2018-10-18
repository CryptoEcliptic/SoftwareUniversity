using System;
using System.IO;


namespace _02WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var readStream = new StreamReader("C:\\Users\\Name\\source\\repos\\04StreamsLab\\01ReadFile\\Program.cs"))
            {
                using (var writeStream = new StreamWriter("reversed.txt"))
                {
                    string line = readStream.ReadLine();
                    while (line != null)
                    {

                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            writeStream.Write(line[i]);
                        }
                        writeStream.WriteLine();


                        line = readStream.ReadLine();

                    }
                }
               
            }
        }
    }
}
