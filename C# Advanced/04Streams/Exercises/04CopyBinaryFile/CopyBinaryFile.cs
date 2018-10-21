using System;
using System.IO;

namespace _04CopyBinaryFile
{
    class CopyBinaryFile
    {
        const string imagePath = @"..\..\..\..\Resources\copyMe.png";
        const string destinationPath = @"..\..\..\result.png";
        static void Main(string[] args)
        {

            using (var readFile = new FileStream(imagePath, FileMode.Open))
            {
                using (var createCopy = new FileStream(destinationPath, FileMode.Create))
                {
                    byte[] buffer = new byte[readFile.Length];
                    while (true)
                    {
                        int readBytes = readFile.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        createCopy.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
