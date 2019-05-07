using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _02SliceFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            const string SourcePath = @"../../../source/video_demo.3gp";
            const string DestinationPath = @"../../../destination/";

            int parts = int.Parse(Console.ReadLine());

            SliceAsync(SourcePath, DestinationPath, parts);

            //Thread.Sleep(10000);

            while (true)
            {
                if (Console.ReadLine() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter exit to quit.");
                }
            }
        }

        static void SliceAsync(string sourceFile, string destinationDirectory, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourceFile, destinationDirectory, parts);
            });
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            //Thread.Sleep(10000);

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);

                long partLength = (sourceFile.Length / parts) + 1;
                long currentByte = 0;

                for (int i = 1; i <= parts; i++)
                {
                    string filePath = string.Format("{0}/Part-{1}{2}", destinationDirectory, i, fileInfo.Extension);

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[512];

                        while (currentByte <= partLength * i)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }

                Console.WriteLine("Slice complete.");
            }
        }
    }
}
